using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("UserProfiles", "Users");
        builder.Property(p => p.FirstName).HasMaxLength(100);
        builder.Property(p => p.LastName).HasMaxLength(100);
        builder.Property(p => p.Email).HasMaxLength(255);
        builder.Property(p => p.Phone).HasMaxLength(20);
        builder.Property(p => p.AvatarUrl).HasMaxLength(500);
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<UserProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(p => p.Email).HasDatabaseName("IX_UserProfiles_Email");
        builder.HasIndex(p => p.UserId).IsUnique().HasDatabaseName("IX_UserProfiles_UserId");
    }
}
