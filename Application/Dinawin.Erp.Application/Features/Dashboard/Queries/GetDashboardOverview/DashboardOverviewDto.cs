namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetDashboardOverview;

/// <summary>
/// مدل انتقال داده نمای کلی داشبورد
/// </summary>
public sealed class DashboardOverviewDto
{
    /// <summary>
    /// آمار کلی فروش
    /// </summary>
    public SalesOverviewDto SalesOverview { get; set; } = new();

    /// <summary>
    /// آمار کلی خرید
    /// </summary>
    public PurchaseOverviewDto PurchaseOverview { get; set; } = new();

    /// <summary>
    /// آمار موجودی
    /// </summary>
    public InventoryOverviewDto InventoryOverview { get; set; } = new();

    /// <summary>
    /// آمار مالی
    /// </summary>
    public FinancialOverviewDto FinancialOverview { get; set; } = new();

    /// <summary>
    /// آمار مشتریان
    /// </summary>
    public CustomerOverviewDto CustomerOverview { get; set; } = new();

    /// <summary>
    /// آمار تامین‌کنندگان
    /// </summary>
    public VendorOverviewDto VendorOverview { get; set; } = new();

    /// <summary>
    /// آمار وظایف
    /// </summary>
    public TaskOverviewDto TaskOverview { get; set; } = new();

    /// <summary>
    /// نمودار فروش ماهانه
    /// </summary>
    public List<MonthlyValueDto> MonthlySalesChart { get; set; } = new();

    /// <summary>
    /// نمودار خرید ماهانه
    /// </summary>
    public List<MonthlyValueDto> MonthlyPurchaseChart { get; set; } = new();

    /// <summary>
    /// نمودار موجودی بر اساس دسته‌بندی
    /// </summary>
    public List<CategoryValueDto> InventoryByCategoryChart { get; set; } = new();

    /// <summary>
    /// نمودار وضعیت وظایف
    /// </summary>
    public List<StatusValueDto> TaskStatusChart { get; set; } = new();
}

/// <summary>
/// مدل آمار فروش
/// </summary>
public sealed class SalesOverviewDto
{
    /// <summary>
    /// تعداد کل سفارشات فروش
    /// </summary>
    public int TotalOrders { get; set; }

    /// <summary>
    /// تعداد سفارشات در حال انجام
    /// </summary>
    public int PendingOrders { get; set; }

    /// <summary>
    /// تعداد سفارشات تکمیل شده
    /// </summary>
    public int CompletedOrders { get; set; }

    /// <summary>
    /// مجموع فروش
    /// </summary>
    public decimal TotalSales { get; set; }

    /// <summary>
    /// فروش این ماه
    /// </summary>
    public decimal MonthlySales { get; set; }

    /// <summary>
    /// درصد رشد فروش نسبت به ماه قبل
    /// </summary>
    public decimal SalesGrowthPercentage { get; set; }
}

/// <summary>
/// مدل آمار خرید
/// </summary>
public sealed class PurchaseOverviewDto
{
    /// <summary>
    /// تعداد کل سفارشات خرید
    /// </summary>
    public int TotalOrders { get; set; }

    /// <summary>
    /// تعداد سفارشات در حال انجام
    /// </summary>
    public int PendingOrders { get; set; }

    /// <summary>
    /// تعداد سفارشات تکمیل شده
    /// </summary>
    public int CompletedOrders { get; set; }

    /// <summary>
    /// مجموع خرید
    /// </summary>
    public decimal TotalPurchases { get; set; }

    /// <summary>
    /// خرید این ماه
    /// </summary>
    public decimal MonthlyPurchases { get; set; }

    /// <summary>
    /// درصد رشد خرید نسبت به ماه قبل
    /// </summary>
    public decimal PurchaseGrowthPercentage { get; set; }
}

/// <summary>
/// مدل آمار موجودی
/// </summary>
public sealed class InventoryOverviewDto
{
    /// <summary>
    /// تعداد کل محصولات
    /// </summary>
    public int TotalProducts { get; set; }

    /// <summary>
    /// تعداد محصولات با موجودی کم
    /// </summary>
    public int LowStockProducts { get; set; }

    /// <summary>
    /// تعداد محصولات بدون موجودی
    /// </summary>
    public int OutOfStockProducts { get; set; }

    /// <summary>
    /// ارزش کل موجودی
    /// </summary>
    public decimal TotalInventoryValue { get; set; }

    /// <summary>
    /// تعداد انبارها
    /// </summary>
    public int TotalWarehouses { get; set; }

    /// <summary>
    /// تعداد مکان‌های انبار
    /// </summary>
    public int TotalBins { get; set; }
}

/// <summary>
/// مدل آمار مالی
/// </summary>
public sealed class FinancialOverviewDto
{
    /// <summary>
    /// مجموع درآمد
    /// </summary>
    public decimal TotalRevenue { get; set; }

    /// <summary>
    /// مجموع هزینه
    /// </summary>
    public decimal TotalExpenses { get; set; }

    /// <summary>
    /// سود خالص
    /// </summary>
    public decimal NetProfit { get; set; }

    /// <summary>
    /// تعداد حساب‌های بانکی
    /// </summary>
    public int TotalBankAccounts { get; set; }

    /// <summary>
    /// موجودی کل حساب‌های بانکی
    /// </summary>
    public decimal TotalBankBalance { get; set; }

    /// <summary>
    /// تعداد صندوق‌های نقدی
    /// </summary>
    public int TotalCashBoxes { get; set; }

    /// <summary>
    /// موجودی کل صندوق‌های نقدی
    /// </summary>
    public decimal TotalCashBalance { get; set; }
}

/// <summary>
/// مدل آمار مشتریان
/// </summary>
public sealed class CustomerOverviewDto
{
    /// <summary>
    /// تعداد کل مشتریان
    /// </summary>
    public int TotalCustomers { get; set; }

    /// <summary>
    /// تعداد مشتریان فعال
    /// </summary>
    public int ActiveCustomers { get; set; }

    /// <summary>
    /// تعداد مشتریان جدید این ماه
    /// </summary>
    public int NewCustomersThisMonth { get; set; }

    /// <summary>
    /// میانگین ارزش سفارش مشتریان
    /// </summary>
    public decimal AverageOrderValue { get; set; }
}

/// <summary>
/// مدل آمار تامین‌کنندگان
/// </summary>
public sealed class VendorOverviewDto
{
    /// <summary>
    /// تعداد کل تامین‌کنندگان
    /// </summary>
    public int TotalVendors { get; set; }

    /// <summary>
    /// تعداد تامین‌کنندگان فعال
    /// </summary>
    public int ActiveVendors { get; set; }

    /// <summary>
    /// تعداد تامین‌کنندگان جدید این ماه
    /// </summary>
    public int NewVendorsThisMonth { get; set; }

    /// <summary>
    /// میانگین ارزش سفارش تامین‌کنندگان
    /// </summary>
    public decimal AverageOrderValue { get; set; }
}

/// <summary>
/// مدل آمار وظایف
/// </summary>
public sealed class TaskOverviewDto
{
    /// <summary>
    /// تعداد کل وظایف
    /// </summary>
    public int TotalTasks { get; set; }

    /// <summary>
    /// تعداد وظایف در حال انجام
    /// </summary>
    public int InProgressTasks { get; set; }

    /// <summary>
    /// تعداد وظایف تکمیل شده
    /// </summary>
    public int CompletedTasks { get; set; }

    /// <summary>
    /// تعداد وظایف در انتظار
    /// </summary>
    public int PendingTasks { get; set; }

    /// <summary>
    /// تعداد وظایف با اولویت بالا
    /// </summary>
    public int HighPriorityTasks { get; set; }

    /// <summary>
    /// تعداد وظایف منقضی شده
    /// </summary>
    public int OverdueTasks { get; set; }
    public int ActiveTasks { get; internal set; }
}

/// <summary>
/// مدل داده نمودار ماهانه
/// </summary>
public sealed class MonthlyValueDto
{
    /// <summary>
    /// سال
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// ماه
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// مقدار
    /// </summary>
    public decimal Value { get; set; }
}

/// <summary>
/// مدل داده نمودار دسته‌بندی
/// </summary>
public sealed class CategoryValueDto
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// مقدار
    /// </summary>
    public decimal Value { get; set; }
}

/// <summary>
/// مدل داده نمودار وضعیت
/// </summary>
public sealed class StatusValueDto
{
    /// <summary>
    /// نام وضعیت
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// تعداد
    /// </summary>
    public int Count { get; set; }
}
