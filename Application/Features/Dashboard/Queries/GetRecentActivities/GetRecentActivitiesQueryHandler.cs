using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetRecentActivities;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت فعالیت‌های اخیر
/// </summary>
public sealed class GetRecentActivitiesQueryHandler : IRequestHandler<GetRecentActivitiesQuery, IEnumerable<RecentActivityDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت فعالیت‌های اخیر
    /// </summary>
    public GetRecentActivitiesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت فعالیت‌های اخیر
    /// </summary>
    public Task<IEnumerable<RecentActivityDto>> Handle(GetRecentActivitiesQuery request, CancellationToken cancellationToken)
    {
        // در حال حاضر داده‌های نمونه برمی‌گردانیم
        // TODO: پیاده‌سازی واقعی با استفاده از جداول مختلف سیستم
        
        var activities = new List<RecentActivityDto>();

        // تولید داده‌های نمونه
        var random = new Random();
        var activityTypes = new[] { "Sale", "Purchase", "Lead", "Customer", "Product", "Inventory", "Payment" };
        var statuses = new[] { "Completed", "Pending", "In Progress", "Cancelled" };
        var priorities = new[] { "High", "Medium", "Low" };
        var userNames = new[] { "احمد محمدی", "فاطمه احمدی", "علی رضایی", "مریم کریمی", "حسن نوری" };

        for (int i = 0; i < request.Count; i++)
        {
            var activityType = activityTypes[random.Next(activityTypes.Length)];
            var userName = userNames[random.Next(userNames.Length)];
            var timestamp = DateTime.UtcNow.AddHours(-random.Next(1, 72)); // 1 تا 72 ساعت گذشته

            var activity = new RecentActivityDto
            {
                Id = Guid.NewGuid(),
                Type = activityType,
                Title = GetActivityTitle(activityType),
                Description = GetActivityDescription(activityType),
                UserName = userName,
                Timestamp = timestamp,
                Status = statuses[random.Next(statuses.Length)],
                Priority = priorities[random.Next(priorities.Length)],
                ReferenceId = Guid.NewGuid(),
                ReferenceType = activityType
            };

            // اضافه کردن مبلغ برای فعالیت‌های مالی
            if (activityType == "Sale" || activityType == "Purchase" || activityType == "Payment")
            {
                activity.Amount = random.Next(1000000, 500000000); // 1 میلیون تا 500 میلیون
            }

            activities.Add(activity);
        }

        // فیلتر بر اساس نوع فعالیت
        if (!string.IsNullOrWhiteSpace(request.ActivityType))
        {
            activities = activities.Where(a => a.Type == request.ActivityType).ToList();
        }

        // مرتب‌سازی بر اساس زمان (جدیدترین اول)
        return Task.FromResult(activities.OrderByDescending(a => a.Timestamp).Take(request.Count));
    }

    /// <summary>
    /// دریافت عنوان فعالیت بر اساس نوع
    /// </summary>
    private static string GetActivityTitle(string activityType)
    {
        return activityType switch
        {
            "Sale" => "فروش جدید",
            "Purchase" => "خرید جدید",
            "Lead" => "لید جدید",
            "Customer" => "مشتری جدید",
            "Product" => "محصول جدید",
            "Inventory" => "حرکت موجودی",
            "Payment" => "پرداخت جدید",
            _ => "فعالیت جدید"
        };
    }

    /// <summary>
    /// دریافت توضیحات فعالیت بر اساس نوع
    /// </summary>
    private static string GetActivityDescription(string activityType)
    {
        return activityType switch
        {
            "Sale" => "یک فروش جدید ثبت شد",
            "Purchase" => "یک خرید جدید ثبت شد",
            "Lead" => "یک لید جدید اضافه شد",
            "Customer" => "یک مشتری جدید ثبت شد",
            "Product" => "یک محصول جدید اضافه شد",
            "Inventory" => "موجودی انبار به‌روزرسانی شد",
            "Payment" => "یک پرداخت جدید انجام شد",
            _ => "فعالیت جدید انجام شد"
        };
    }
}
