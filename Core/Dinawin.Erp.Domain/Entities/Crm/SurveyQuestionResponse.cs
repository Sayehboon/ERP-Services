using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت پاسخ سوال نظرسنجی
/// Survey Question Response entity
/// </summary>
public class SurveyQuestionResponse : BaseEntity
{
    /// <summary>
    /// شناسه پاسخ نظرسنجی
    /// Survey response ID
    /// </summary>
    public Guid SurveyResponseId { get; set; }

    /// <summary>
    /// شناسه سوال
    /// Question ID
    /// </summary>
    public Guid QuestionId { get; set; }

    /// <summary>
    /// پاسخ سوال
    /// Question answer
    /// </summary>
    public string? Answer { get; set; }

    /// <summary>
    /// پاسخ نظرسنجی
    /// Survey response
    /// </summary>
    public SurveyResponse? SurveyResponse { get; set; }

    /// <summary>
    /// سوال
    /// Question
    /// </summary>
    public SurveyQuestion? Question { get; set; }
}

/// <summary>
/// پیکربندی موجودیت پاسخ سوال نظرسنجی
/// Survey Question Response entity configuration
/// </summary>
public class SurveyQuestionResponseConfiguration : IEntityTypeConfiguration<SurveyQuestionResponse>
{
    public void Configure(EntityTypeBuilder<SurveyQuestionResponse> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Answer).HasMaxLength(2000);

        builder.HasOne(e => e.SurveyResponse)
            .WithMany()
            .HasForeignKey(e => e.SurveyResponseId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Question)
            .WithMany()
            .HasForeignKey(e => e.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.SurveyResponseId);
        builder.HasIndex(e => e.QuestionId);
    }
}
