namespace Dinawin.Erp.Application.Features.Accounting.Accounts.Commands.UpdateAccountStatus;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpdateAccountStatusCommand(Guid Id, bool IsActive) : IRequest<bool>;

public class UpdateAccountStatusCommandHandler : IRequestHandler<UpdateAccountStatusCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateAccountStatusCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateAccountStatusCommand request, CancellationToken cancellationToken)
    {
        var account = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        if (account == null) return false;

        account.IsActive = request.IsActive;
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
