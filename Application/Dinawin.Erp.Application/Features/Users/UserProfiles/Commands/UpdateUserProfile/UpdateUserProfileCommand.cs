namespace Dinawin.Erp.Application.Features.Users.UserProfiles.Commands.UpdateUserProfile;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpdateUserProfileCommand(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? Email,
    string? Phone,
    string? AvatarUrl,
    bool IsActive
) : IRequest<bool>;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateUserProfileCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _db.UserProfiles.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (profile == null) return false;

        profile.FirstName = request.FirstName;
        profile.LastName = request.LastName;
        profile.Email = request.Email;
        profile.Phone = request.Phone;
        profile.AvatarUrl = request.AvatarUrl;
        profile.IsActive = request.IsActive;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
