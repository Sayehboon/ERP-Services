namespace Dinawin.Erp.Application.Features.Users.UserProfiles.Queries.GetUserProfileById;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Users.UserProfiles.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetUserProfileByIdQuery(Guid Id) : IRequest<UserProfileDto?>;

public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDto?>
{
    private readonly IApplicationDbContext _db;
    public GetUserProfileByIdQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<UserProfileDto?> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        return await _db.UserProfiles.AsNoTracking()
            .Where(p => p.Id == request.Id)
            .Select(p => new UserProfileDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Phone = p.Phone,
                AvatarUrl = p.AvatarUrl,
                IsActive = p.IsActive,
                UserId = p.UserId,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
