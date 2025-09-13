using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;

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
