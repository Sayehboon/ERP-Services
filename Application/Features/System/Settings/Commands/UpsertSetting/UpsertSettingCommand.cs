namespace Dinawin.Erp.Application.Features.System.Settings.Commands.UpsertSetting;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Systems;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpsertSettingCommand(
    string Category,
    string Key,
    string Value,
    string BusinessId = "default",
    Guid? UpdatedBy = null
) : IRequest<bool>;

public class UpsertSettingCommandHandler(IApplicationDbContext db) : IRequestHandler<UpsertSettingCommand, bool>
{
    public async Task<bool> Handle(UpsertSettingCommand request, CancellationToken cancellationToken)
    {
        var existingSetting = await db.SystemSettings
            .FirstOrDefaultAsync(s => s.Category == request.Category && 
                                     s.Key == request.Key && 
                                     s.BusinessId == request.BusinessId, 
                                     cancellationToken);

        if (existingSetting != null)
        {
            // Update existing setting
            existingSetting.Value = request.Value;
            existingSetting.UpdatedBy = request.UpdatedBy;
        }
        else
        {
            // Create new setting
            var newSetting = new SystemSetting
            {
                Id = Guid.NewGuid(),
                Category = request.Category,
                Key = request.Key,
                Value = request.Value,
                BusinessId = request.BusinessId,
                UpdatedBy = request.UpdatedBy
            };
            db.SystemSettings.Add(newSetting);
        }

        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
