namespace Dinawin.Erp.Application.Features.Accounting.Accounts.Commands.CreateAccount;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;

public record CreateAccountCommand(
    string Code,
    string Name,
    string Description = null,
    Guid? ParentId = null,
    string BusinessId = "default"
) : IRequest<Guid>;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateAccountCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            ParentId = request.ParentId,
            BusinessId = request.BusinessId,
            IsActive = true
        };

        _db.Accounts.Add(account);
        await _db.SaveChangesAsync(cancellationToken);
        return account.Id;
    }
}
