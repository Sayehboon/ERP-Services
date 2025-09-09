using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت نظرسنجی
/// Survey entity
/// </summary>
public class Survey : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// عنوان نظرسنجی
    /// Survey title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات نظرسنجی
    /// Survey description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع نظرسنجی
    /// Survey type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت نظرسنجی
    /// Survey status
    /// </summary>
    public string Status { get; set; } = "draft"; // draft, active, completed, cancelled

    /// <summary>
    /// تاریخ شروع
    /// Start date
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// End date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// تعداد پاسخ‌ها
    /// Number of responses
    /// </summary>
    public int Responses { get; set; }

    /// <summary>
    /// هدف تعداد پاسخ‌ها
    /// Target number of responses
    /// </summary>
    public int Target { get; set; }

    /// <summary>
    /// نرخ تکمیل
    /// Completion rate
    /// </summary>
    public decimal CompletionRate { get; set; }

    /// <summary>
    /// میانگین امتیاز
    /// Average rating
    /// </summary>
    public decimal AverageRating { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// کاربر ایجادکننده
    /// Created by user
    /// </summary>
    public User? CreatedByUser { get; set; }

    /// <summary>
    /// سوالات نظرسنجی
    /// Survey questions
    /// </summary>
    public ICollection<SurveyQuestion> Questions { get; set; } = new List<SurveyQuestion>();

    /// <summary>
    /// پاسخ‌های نظرسنجی
    /// Survey responses
    /// </summary>
    public ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
}

/// <summary>
/// موجودیت سوال نظرسنجی
/// Survey Question entity
/// </summary>
public class SurveyQuestion : BaseEntity
{
    /// <summary>
    /// شناسه نظرسنجی
    /// Survey ID
    /// </summary>
    public Guid SurveyId { get; set; }

    /// <summary>
    /// متن سوال
    /// Question text
    /// </summary>
    public string QuestionText { get; set; } = string.Empty;

    /// <summary>
    /// نوع سوال
    /// Question type
    /// </summary>
    public string QuestionType { get; set; } = string.Empty; // text, multiple_choice, rating, etc.

    /// <summary>
    /// گزینه‌های سوال
    /// Question options
    /// </summary>
    public string? Options { get; set; } // JSON string for multiple choice options

    /// <summary>
    /// آیا سوال اجباری است
    /// Is question required
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// ترتیب سوال
    /// Question order
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// نظرسنجی
    /// Survey
    /// </summary>
    public Survey? Survey { get; set; }

    /// <summary>
    /// پاسخ‌های سوال
    /// Question responses
    /// </summary>
    public ICollection<SurveyQuestionResponse> QuestionResponses { get; set; } = new List<SurveyQuestionResponse>();
}

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
