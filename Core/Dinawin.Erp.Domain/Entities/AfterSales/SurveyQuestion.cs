using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.AfterSales;

/// <summary>
/// سوالات نظرسنجی
/// Survey Questions
/// </summary>
public class SurveyQuestion : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب و کار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// متن سوال
    /// Question Text
    /// </summary>
    public string QuestionText { get; set; } = string.Empty;

    /// <summary>
    /// نوع سوال
    /// Question Type
    /// </summary>
    public string QuestionType { get; set; } = string.Empty;

    /// <summary>
    /// گزینه های پاسخ
    /// Answer Options
    /// </summary>
    public string? AnswerOptions { get; set; }

    /// <summary>
    /// آیا اجباری است
    /// Is Required
    /// </summary>
    public bool IsRequired { get; set; } = false;

    /// <summary>
    /// ترتیب نمایش
    /// Display Order
    /// </summary>
    public int DisplayOrder { get; set; } = 0;

    /// <summary>
    /// دسته بندی
    /// Category
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// حداقل امتیاز
    /// Minimum Score
    /// </summary>
    public int? MinScore { get; set; }

    /// <summary>
    /// حداکثر امتیاز
    /// Maximum Score
    /// </summary>
    public int? MaxScore { get; set; }

    /// <summary>
    /// وزن سوال
    /// Question Weight
    /// </summary>
    public decimal? Weight { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سوالات نظرسنجی
/// Survey Question entity configuration
/// </summary>
public class SurveyQuestionConfiguration : IEntityTypeConfiguration<SurveyQuestion>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<SurveyQuestion> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.QuestionText)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(e => e.QuestionType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.AnswerOptions)
            .HasMaxLength(2000);

        builder.Property(e => e.Category)
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.Weight)
            .HasPrecision(18, 4);

        builder.HasIndex(e => e.BusinessId);
        builder.HasIndex(e => e.DisplayOrder);
    }
}
