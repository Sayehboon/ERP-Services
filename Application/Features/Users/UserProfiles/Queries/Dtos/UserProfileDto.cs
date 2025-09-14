namespace Dinawin.Erp.Application.Features.Users.UserProfiles.Queries.Dtos;

public class UserProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string AvatarUrl { get; set; }
    public bool IsActive { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
