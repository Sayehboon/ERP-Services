using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت پاسخ نظرسنجی
/// Survey Response entity
/// </summary>
public class SurveyResponse : BaseEntity
{
    /// <summary>
    /// شناسه نظرسنجی
    /// Survey ID
    /// </summary>
    public Guid SurveyId { get; set; }

    /// <summary>
    /// شناسه مخاطب
    /// Contact ID
    /// </summary>
    public Guid? ContactId { get; set; }

    /// <summary>
    /// نام پاسخ‌دهنده
    /// Respondent name
    /// </summary>
    public string? RespondentName { get; set; }

    /// <summary>
    /// ایمیل پاسخ‌دهنده
    /// Respondent email
    /// </summary>
    public string? RespondentEmail { get; set; }

    /// <summary>
    /// تاریخ پاسخ
    /// Response date
    /// </summary>
    public DateTime ResponseDate { get; set; }

    /// <summary>
    /// آیا پاسخ تکمیل شده است
    /// Is response completed
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// نظرسنجی
    /// Survey
    /// </summary>
    public Survey? Survey { get; set; }

    /// <summary>
    /// مخاطب
    /// Contact
    /// </summary>
    public Contact? Contact { get; set; }

    /// <summary>
    /// پاسخ‌های سوالات
    /// Question responses
    /// </summary>
    public ICollection<SurveyQuestionResponse> QuestionResponses { get; set; } = new List<SurveyQuestionResponse>();
}
