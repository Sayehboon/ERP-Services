namespace Dinawin.Erp.Application.Features.System.Settings.Queries.GetSettingsByCategory;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetSettingsByCategoryQuery(string Category, string BusinessId = "default") : IRequest<IReadOnlyList<SystemSettingDto>>;

public class SystemSettingDto
{
    public Guid Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string? Value { get; set; }
    public string BusinessId { get; set; } = string.Empty;
}

public class GetSettingsByCategoryQueryHandler : IRequestHandler<GetSettingsByCategoryQuery, IReadOnlyList<SystemSettingDto>>
{
    private readonly IApplicationDbContext _db;
    public GetSettingsByCategoryQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<SystemSettingDto>> Handle(GetSettingsByCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _db.SystemSettings.AsNoTracking()
            .Where(s => s.Category == request.Category && s.BusinessId == request.BusinessId)
            .Select(s => new SystemSettingDto
            {
                Id = s.Id,
                Category = s.Category,
                Key = s.Key,
                Value = s.Value,
                BusinessId = s.BusinessId
            })
            .ToListAsync(cancellationToken);
    }
}
