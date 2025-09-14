using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskStatistics;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت آمار وظایف
/// </summary>
public sealed class GetTaskStatisticsQueryHandler : IRequestHandler<GetTaskStatisticsQuery, TaskStatisticsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت آمار وظایف
    /// </summary>
    public GetTaskStatisticsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت آمار وظایف
    /// </summary>
    public async Task<TaskStatisticsDto> Handle(GetTaskStatisticsQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _context.Tasks.ToListAsync(cancellationToken);

        var statistics = new TaskStatisticsDto
        {
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            GeneratedAt = DateTime.UtcNow
        };

        // محاسبه آمار کلی
        statistics.Overview = await CalculateOverviewStatistics(tasks, cancellationToken);

        // محاسبه آمار بر اساس وضعیت
        statistics.StatusStatistics = await CalculateStatusStatistics(tasks);

        // محاسبه آمار بر اساس اولویت
        statistics.PriorityStatistics = await CalculatePriorityStatistics(tasks);

        // محاسبه آمار بر اساس نوع وظیفه
        statistics.TypeStatistics = await CalculateTypeStatistics(tasks);

        // محاسبه آمار بر اساس کاربر
        statistics.UserStatistics = await CalculateUserStatistics(tasks, cancellationToken);

        // محاسبه آمار بر اساس پروژه
        statistics.ProjectStatistics = await CalculateProjectStatistics(tasks, cancellationToken);

        // محاسبه آمار بر اساس تاریخ
        statistics.DateStatistics = await CalculateDateStatistics(tasks, request.FromDate, request.ToDate);

        // محاسبه آمار عملکرد
        statistics.Performance = await CalculatePerformanceStatistics(tasks);

        return statistics;
    }

    /// <summary>
    /// محاسبه آمار کلی
    /// </summary>
    private async Task<TaskOverviewStatisticsDto> CalculateOverviewStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks, CancellationToken cancellationToken)
    {
        var totalTasks = tasks.Count;
        var activeTasks = tasks.Count(t => t.Status != "Completed" && t.Status != "Cancelled");
        var completedTasks = tasks.Count(t => t.Status == "Completed");
        var cancelledTasks = tasks.Count(t => t.Status == "Cancelled");
        var overdueTasks = tasks.Count(t => t.EndDate.HasValue && 
                                           t.EndDate.Value < DateTime.UtcNow && 
                                           t.Status != "Completed");

        var completionPercentage = totalTasks > 0 ? (decimal)completedTasks / totalTasks * 100m : 0m;
        var averageProgress = totalTasks > 0 ? (decimal)tasks.Average(t => (double)t.ProgressPercentage) : 0m;

        // آمار زیروظایف
        var totalSubTasks = await _context.SubTasks
            .CountAsync(st => tasks.Select(t => t.Id).Contains(st.TaskId), cancellationToken);

        var completedSubTasks = await _context.SubTasks
            .CountAsync(st => tasks.Select(t => t.Id).Contains(st.TaskId) && st.Status == "Completed", cancellationToken);

        var subTaskCompletionPercentage = totalSubTasks > 0 ? (decimal)completedSubTasks / totalSubTasks * 100m : 0m;

        return new TaskOverviewStatisticsDto
        {
            TotalTasks = totalTasks,
            ActiveTasks = activeTasks,
            CompletedTasks = completedTasks,
            CancelledTasks = cancelledTasks,
            OverdueTasks = overdueTasks,
            CompletionPercentage = completionPercentage,
            AverageProgress = averageProgress,
            TotalSubTasks = totalSubTasks,
            CompletedSubTasks = completedSubTasks,
            SubTaskCompletionPercentage = subTaskCompletionPercentage
        };
    }

    /// <summary>
    /// محاسبه آمار بر اساس وضعیت
    /// </summary>
    private Task<List<TaskStatusStatisticsDto>> CalculateStatusStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks)
    {
        var totalTasks = tasks.Count;
        if (totalTasks == 0) return Task.FromResult(new List<TaskStatusStatisticsDto>());

        var statusGroups = tasks.GroupBy(t => t.Status)
            .Select(g => new TaskStatusStatisticsDto
            {
                Status = g.Key,
                StatusPersian = GetStatusPersian(g.Key),
                Count = g.Count(),
                Percentage = (decimal)g.Count() / totalTasks * 100m,
                AverageProgress = (decimal)g.Average(t => t.ProgressPercentage)
            })
            .OrderByDescending(s => s.Count)
            .ToList();

        return Task.FromResult(statusGroups);
    }

    /// <summary>
    /// محاسبه آمار بر اساس اولویت
    /// </summary>
    private Task<List<TaskPriorityStatisticsDto>> CalculatePriorityStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks)
    {
        var totalTasks = tasks.Count;
        if (totalTasks == 0) return Task.FromResult(new List<TaskPriorityStatisticsDto>());

        var priorityGroups = tasks.GroupBy(t => t.Priority)
            .Select(g => new TaskPriorityStatisticsDto
            {
                Priority = g.Key,
                PriorityPersian = GetPriorityPersian(g.Key),
                Count = g.Count(),
                Percentage = (decimal)g.Count() / totalTasks * 100m,
                AverageProgress = (decimal)g.Average(t => (double)t.ProgressPercentage)
            })
            .OrderByDescending(p => p.Count)
            .ToList();

        return Task.FromResult(priorityGroups);
    }

    /// <summary>
    /// محاسبه آمار بر اساس نوع وظیفه
    /// </summary>
    private Task<List<TaskTypeStatisticsDto>> CalculateTypeStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks)
    {
        var totalTasks = tasks.Count;
        if (totalTasks == 0) return Task.FromResult(new List<TaskTypeStatisticsDto>());

        var typeGroups = tasks.GroupBy(t => t.TaskType)
            .Select(g => new TaskTypeStatisticsDto
            {
                TaskType = g.Key ?? string.Empty,
                TaskTypePersian = GetTaskTypePersian(g.Key ?? string.Empty),
                Count = g.Count(),
                Percentage = (decimal)g.Count() / totalTasks * 100m,
                AverageProgress = (decimal)g.Average(t => (double)t.ProgressPercentage)
            })
            .OrderByDescending(t => t.Count)
            .ToList();

        return Task.FromResult(typeGroups);
    }

    /// <summary>
    /// محاسبه آمار بر اساس کاربر
    /// </summary>
    private Task<List<TaskUserStatisticsDto>> CalculateUserStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks, CancellationToken cancellationToken)
    {
        var userGroups = tasks.Where(t => t.AssignedTo.HasValue)
            .GroupBy(t => t.AssignedTo.Value)
            .Select(g => new TaskUserStatisticsDto
            {
                UserId = g.Key,
                UserName = "کاربر " + g.Key.ToString().Substring(0, 8), // در واقعیت باید از دیتابیس دریافت شود
                TotalTasks = g.Count(),
                CompletedTasks = g.Count(t => t.Status == "Completed"),
                InProgressTasks = g.Count(t => t.Status == "InProgress"),
                OverdueTasks = g.Count(t => t.EndDate.HasValue && 
                                          t.EndDate.Value < DateTime.UtcNow && 
                                          t.Status != "Completed"),
                CompletionPercentage = g.Count() > 0 ? (decimal)g.Count(t => t.Status == "Completed") / g.Count() * 100m : 0m,
                AverageProgress = (decimal)g.Average(t => (double)t.ProgressPercentage)
            })
            .OrderByDescending(u => u.TotalTasks)
            .ToList();

        return Task.FromResult(userGroups);
    }

    /// <summary>
    /// محاسبه آمار بر اساس پروژه
    /// </summary>
    private Task<List<TaskProjectStatisticsDto>> CalculateProjectStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks, CancellationToken cancellationToken)
    {
        var projectGroups = tasks.Where(t => t.ProjectId.HasValue)
            .GroupBy(t => t.ProjectId.Value)
            .Select(g => new TaskProjectStatisticsDto
            {
                ProjectId = g.Key,
                ProjectName = "پروژه " + g.Key.ToString().Substring(0, 8), // در واقعیت باید از دیتابیس دریافت شود
                TotalTasks = g.Count(),
                CompletedTasks = g.Count(t => t.Status == "Completed"),
                InProgressTasks = g.Count(t => t.Status == "InProgress"),
                OverdueTasks = g.Count(t => t.EndDate.HasValue && 
                                          t.EndDate.Value < DateTime.UtcNow && 
                                          t.Status != "Completed"),
                CompletionPercentage = g.Count() > 0 ? (decimal)g.Count(t => t.Status == "Completed") / g.Count() * 100m : 0m,
                AverageProgress = (decimal)g.Average(t => (double)t.ProgressPercentage)
            })
            .OrderByDescending(p => p.TotalTasks)
            .ToList();

        return Task.FromResult(projectGroups);
    }

    /// <summary>
    /// محاسبه آمار بر اساس تاریخ
    /// </summary>
    private Task<List<TaskDateStatisticsDto>> CalculateDateStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks, DateTime? fromDate, DateTime? toDate)
    {
        var startDate = fromDate ?? tasks.Min(t => t.CreatedAt).Date;
        var endDate = toDate ?? DateTime.UtcNow.Date;

        var dateStatistics = new List<TaskDateStatisticsDto>();
        var currentDate = startDate;

        while (currentDate <= endDate)
        {
            var dayTasks = tasks.Where(t => t.CreatedAt.Date == currentDate).ToList();
            
            dateStatistics.Add(new TaskDateStatisticsDto
            {
                Date = currentDate,
                CreatedTasks = dayTasks.Count,
                CompletedTasks = dayTasks.Count(t => t.Status == "Completed"),
                UpdatedTasks = dayTasks.Count(t => t.UpdatedAt.Date == currentDate)
            });

            currentDate = currentDate.AddDays(1);
        }

        return Task.FromResult(dateStatistics);
    }

    /// <summary>
    /// محاسبه آمار عملکرد
    /// </summary>
    private Task<TaskPerformanceStatisticsDto> CalculatePerformanceStatistics(List<Dinawin.Erp.Domain.Entities.Users.WorkTask> tasks)
    {
        var completedTasks = tasks.Where(t => t.Status == "Completed" && 
                                            t.StartDate.HasValue && 
                                            t.EndDate.HasValue).ToList();

        var averageCompletionTime = completedTasks.Any() ? 
            (decimal)completedTasks.Average(t => (t.EndDate!.Value - t.StartDate!.Value).TotalDays) : 0m;

        var overdueTasks = tasks.Where(t => t.EndDate.HasValue && 
                                          t.EndDate.Value < DateTime.UtcNow && 
                                          t.Status != "Completed").ToList();

        var averageDelay = overdueTasks.Any() ? 
            (decimal)overdueTasks.Average(t => (DateTime.UtcNow - t.EndDate!.Value).TotalDays) : 0m;

        var onTimeTasks = 0; // بدون فیلدهای برنامه‌ریزی‌شده، امکان محاسبه دقیق نیست

        var onTimeCompletionPercentage = tasks.Count(t => t.Status == "Completed") > 0 ? 
            (decimal)onTimeTasks / tasks.Count(t => t.Status == "Completed") * 100m : 0m;

        var overduePercentage = tasks.Count > 0 ? (decimal)overdueTasks.Count / tasks.Count * 100m : 0m;

        var lastWeek = DateTime.UtcNow.AddDays(-7);
        var lastMonth = DateTime.UtcNow.AddDays(-30);

        return Task.FromResult(new TaskPerformanceStatisticsDto
        {
            AverageCompletionTime = averageCompletionTime,
            AverageDelay = averageDelay,
            OnTimeCompletionPercentage = onTimeCompletionPercentage,
            OverduePercentage = overduePercentage,
            CompletedLastWeek = tasks.Count(t => t.Status == "Completed" && t.EndDate.HasValue && t.EndDate.Value >= lastWeek),
            CompletedLastMonth = tasks.Count(t => t.Status == "Completed" && t.EndDate.HasValue && t.EndDate.Value >= lastMonth),
            CreatedLastWeek = tasks.Count(t => t.CreatedAt >= lastWeek),
            CreatedLastMonth = tasks.Count(t => t.CreatedAt >= lastMonth)
        });
    }

    /// <summary>
    /// تبدیل وضعیت انگلیسی به فارسی
    /// </summary>
    private static string GetStatusPersian(string status)
    {
        return status.ToLower() switch
        {
            "pending" => "در انتظار",
            "in_progress" => "در حال انجام",
            "completed" => "تکمیل شده",
            "cancelled" => "لغو شده",
            "on_hold" => "متوقف",
            "review" => "در حال بررسی",
            "approved" => "تایید شده",
            "rejected" => "رد شده",
            _ => status
        };
    }

    /// <summary>
    /// تبدیل اولویت انگلیسی به فارسی
    /// </summary>
    private static string GetPriorityPersian(string priority)
    {
        return priority.ToLower() switch
        {
            "low" => "کم",
            "medium" => "متوسط",
            "high" => "بالا",
            "urgent" => "فوری",
            "critical" => "بحرانی",
            _ => priority
        };
    }

    /// <summary>
    /// تبدیل نوع وظیفه انگلیسی به فارسی
    /// </summary>
    private static string GetTaskTypePersian(string taskType)
    {
        return taskType.ToLower() switch
        {
            "bug" => "باگ",
            "feature" => "ویژگی",
            "improvement" => "بهبود",
            "documentation" => "مستندات",
            "test" => "تست",
            "maintenance" => "نگهداری",
            "research" => "تحقیق",
            "design" => "طراحی",
            _ => taskType
        };
    }
}
