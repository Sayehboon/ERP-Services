using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// جریان ابزار مالی
/// Financial Instrument Flow
/// </summary>
public class InstrumentFlow : BaseEntity
{
    /// <summary>
    /// شناسه ابزار
    /// Instrument ID
    /// </summary>
    public Guid InstrumentId { get; set; }

    /// <summary>
    /// تاریخ جریان
    /// Flow date
    /// </summary>
    public DateTime FlowDate { get; set; }

    /// <summary>
    /// نوع جریان
    /// Flow type
    /// </summary>
    public string FlowType { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// ابزار مرتبط
    /// Related instrument
    /// </summary>
    public Instrument Instrument { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت جریان ابزار مالی
/// Financial Instrument Flow entity configuration
/// </summary>
public class InstrumentFlowConfiguration : IEntityTypeConfiguration<InstrumentFlow>
{
    public void Configure(EntityTypeBuilder<InstrumentFlow> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FlowType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasOne(e => e.Instrument)
            .WithMany(i => i.Flows)
            .HasForeignKey(e => e.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.InstrumentId);
        builder.HasIndex(e => e.FlowDate);
        builder.HasIndex(e => e.FlowType);
    }
}
