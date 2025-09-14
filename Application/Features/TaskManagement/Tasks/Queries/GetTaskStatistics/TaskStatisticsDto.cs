namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskStatistics;

/// <summary>
/// DTO آمار وظایف
/// </summary>
public class TaskStatisticsDto
{
    /// <summary>
    /// تاریخ شروع دوره
    /// </summary>
    public DateTime? FromDate { get; set; }

    /// <summary>
    /// تاریخ پایان دوره
    /// </summary>
    public DateTime? ToDate { get; set; }

    /// <summary>
    /// تاریخ تولید آمار
    /// </summary>
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// آمار کلی
    /// </summary>
    public TaskOverviewStatisticsDto Overview { get; set; } = new();

    /// <summary>
    /// آمار بر اساس وضعیت
    /// </summary>
    public List<TaskStatusStatisticsDto> StatusStatistics { get; set; } = new();

    /// <summary>
    /// آمار بر اساس اولویت
    /// </summary>
    public List<TaskPriorityStatisticsDto> PriorityStatistics { get; set; } = new();

    /// <summary>
    /// آمار بر اساس نوع وظیفه
    /// </summary>
    public List<TaskTypeStatisticsDto> TypeStatistics { get; set; } = new();

    /// <summary>
    /// آمار بر اساس کاربر
    /// </summary>
    public List<TaskUserStatisticsDto> UserStatistics { get; set; } = new();

    /// <summary>
    /// آمار بر اساس پروژه
    /// </summary>
    public List<TaskProjectStatisticsDto> ProjectStatistics { get; set; } = new();

    /// <summary>
    /// آمار بر اساس تاریخ
    /// </summary>
    public List<TaskDateStatisticsDto> DateStatistics { get; set; } = new();

    /// <summary>
    /// آمار عملکرد
    /// </summary>
    public TaskPerformanceStatisticsDto Performance { get; set; } = new();
}

/// <summary>
/// DTO آمار کلی وظایف
/// </summary>
public class TaskOverviewStatisticsDto
{
    /// <summary>
    /// تعداد کل وظایف
    /// </summary>
    public int TotalTasks { get; set; }

    /// <summary>
    /// تعداد وظایف فعال
    /// </summary>
    public int ActiveTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تکمیل شده
    /// </summary>
    public int CompletedTasks { get; set; }

    /// <summary>
    /// تعداد وظایف لغو شده
    /// </summary>
    public int CancelledTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تاخیردار
    /// </summary>
    public int OverdueTasks { get; set; }

    /// <summary>
    /// درصد تکمیل
    /// </summary>
    public decimal CompletionPercentage { get; set; }

    /// <summary>
    /// میانگین پیشرفت
    /// </summary>
    public decimal AverageProgress { get; set; }

    /// <summary>
    /// تعداد زیروظایف
    /// </summary>
    public int TotalSubTasks { get; set; }

    /// <summary>
    /// تعداد زیروظایف تکمیل شده
    /// </summary>
    public int CompletedSubTasks { get; set; }

    /// <summary>
    /// درصد تکمیل زیروظایف
    /// </summary>
    public decimal SubTaskCompletionPercentage { get; set; }
}

/// <summary>
/// DTO آمار بر اساس وضعیت
/// </summary>
public class TaskStatusStatisticsDto
{
    /// <summary>
    /// وضعیت
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت به فارسی
    /// </summary>
    public string StatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// تعداد
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// درصد
    /// </summary>
    public decimal Percentage { get; set; }

    /// <summary>
    /// میانگین پیشرفت
    /// </summary>
    public decimal AverageProgress { get; set; }
}

/// <summary>
/// DTO آمار بر اساس اولویت
/// </summary>
public class TaskPriorityStatisticsDto
{
    /// <summary>
    /// اولویت
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// اولویت به فارسی
    /// </summary>
    public string PriorityPersian { get; set; } = string.Empty;

    /// <summary>
    /// تعداد
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// درصد
    /// </summary>
    public decimal Percentage { get; set; }

    /// <summary>
    /// میانگین پیشرفت
    /// </summary>
    public decimal AverageProgress { get; set; }
}

/// <summary>
/// DTO آمار بر اساس نوع وظیفه
/// </summary>
public class TaskTypeStatisticsDto
{
    /// <summary>
    /// نوع وظیفه
    /// </summary>
    public string TaskType { get; set; } = string.Empty;

    /// <summary>
    /// نوع وظیفه به فارسی
    /// </summary>
    public string TaskTypePersian { get; set; } = string.Empty;

    /// <summary>
    /// تعداد
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// درصد
    /// </summary>
    public decimal Percentage { get; set; }

    /// <summary>
    /// میانگین پیشرفت
    /// </summary>
    public decimal AverageProgress { get; set; }
}

/// <summary>
/// DTO آمار بر اساس کاربر
/// </summary>
public class TaskUserStatisticsDto
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// نام کاربر
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// تعداد کل وظایف
    /// </summary>
    public int TotalTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تکمیل شده
    /// </summary>
    public int CompletedTasks { get; set; }

    /// <summary>
    /// تعداد وظایف در حال انجام
    /// </summary>
    public int InProgressTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تاخیردار
    /// </summary>
    public int OverdueTasks { get; set; }

    /// <summary>
    /// درصد تکمیل
    /// </summary>
    public decimal CompletionPercentage { get; set; }

    /// <summary>
    /// میانگین پیشرفت
    /// </summary>
    public decimal AverageProgress { get; set; }
}

/// <summary>
/// DTO آمار بر اساس پروژه
/// </summary>
public class TaskProjectStatisticsDto
{
    /// <summary>
    /// شناسه پروژه
    /// </summary>
    public Guid ProjectId { get; set; }

    /// <summary>
    /// نام پروژه
    /// </summary>
    public string ProjectName { get; set; } = string.Empty;

    /// <summary>
    /// تعداد کل وظایف
    /// </summary>
    public int TotalTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تکمیل شده
    /// </summary>
    public int CompletedTasks { get; set; }

    /// <summary>
    /// تعداد وظایف در حال انجام
    /// </summary>
    public int InProgressTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تاخیردار
    /// </summary>
    public int OverdueTasks { get; set; }

    /// <summary>
    /// درصد تکمیل
    /// </summary>
    public decimal CompletionPercentage { get; set; }

    /// <summary>
    /// میانگین پیشرفت
    /// </summary>
    public decimal AverageProgress { get; set; }
}

/// <summary>
/// DTO آمار بر اساس تاریخ
/// </summary>
public class TaskDateStatisticsDto
{
    /// <summary>
    /// تاریخ
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// تعداد وظایف ایجاد شده
    /// </summary>
    public int CreatedTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تکمیل شده
    /// </summary>
    public int CompletedTasks { get; set; }

    /// <summary>
    /// تعداد وظایف به‌روزرسانی شده
    /// </summary>
    public int UpdatedTasks { get; set; }
}

/// <summary>
/// DTO آمار عملکرد
/// </summary>
public class TaskPerformanceStatisticsDto
{
    /// <summary>
    /// میانگین زمان تکمیل (روز)
    /// </summary>
    public decimal AverageCompletionTime { get; set; }

    /// <summary>
    /// میانگین تاخیر (روز)
    /// </summary>
    public decimal AverageDelay { get; set; }

    /// <summary>
    /// درصد وظایف به موقع تکمیل شده
    /// </summary>
    public decimal OnTimeCompletionPercentage { get; set; }

    /// <summary>
    /// درصد وظایف تاخیردار
    /// </summary>
    public decimal OverduePercentage { get; set; }

    /// <summary>
    /// تعداد وظایف تکمیل شده در هفته گذشته
    /// </summary>
    public int CompletedLastWeek { get; set; }

    /// <summary>
    /// تعداد وظایف تکمیل شده در ماه گذشته
    /// </summary>
    public int CompletedLastMonth { get; set; }

    /// <summary>
    /// تعداد وظایف ایجاد شده در هفته گذشته
    /// </summary>
    public int CreatedLastWeek { get; set; }

    /// <summary>
    /// تعداد وظایف ایجاد شده در ماه گذشته
    /// </summary>
    public int CreatedLastMonth { get; set; }
}
