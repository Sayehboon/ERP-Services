using Dinawin.Erp.Domain.Common;

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
