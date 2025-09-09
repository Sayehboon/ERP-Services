using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

public class AccPostingRule : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public string SourceTable { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool AutoPost { get; set; }
    public bool RequireApproval { get; set; }
    public string AccountMappingJson { get; set; } = "{}";
}

/// <summary>
/// پیکربندی موجودیت قوانین پست حسابداری
/// Accounting Posting Rule entity configuration
/// </summary>
public class AccPostingRuleConfiguration : IEntityTypeConfiguration<AccPostingRule>
{
    public void Configure(EntityTypeBuilder<AccPostingRule> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.SourceTable).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.AccountMappingJson).IsRequired().HasMaxLength(4000);

        builder.HasIndex(e => e.BusinessId);
        builder.HasIndex(e => e.SourceTable);
    }
}

