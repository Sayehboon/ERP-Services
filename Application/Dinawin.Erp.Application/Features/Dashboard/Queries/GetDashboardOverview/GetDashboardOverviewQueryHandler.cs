using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetDashboardOverview;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت نمای کلی داشبورد
/// </summary>
public sealed class GetDashboardOverviewQueryHandler : IRequestHandler<GetDashboardOverviewQuery, DashboardOverviewDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت نمای کلی داشبورد
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetDashboardOverviewQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت نمای کلی داشبورد
    /// </summary>
    public async Task<DashboardOverviewDto> Handle(GetDashboardOverviewQuery request, CancellationToken cancellationToken)
    {
        var fromDate = request.FromDate ?? DateTime.UtcNow.AddMonths(-12);
        var toDate = request.ToDate ?? DateTime.UtcNow;
        var currentMonth = DateTime.UtcNow.Month;
        var currentYear = DateTime.UtcNow.Year;
        var lastMonth = currentMonth == 1 ? 12 : currentMonth - 1;
        var lastMonthYear = currentMonth == 1 ? currentYear - 1 : currentYear;

        // آمار فروش
        var salesOverview = await GetSalesOverviewAsync(fromDate, toDate, currentMonth, currentYear, lastMonth, lastMonthYear, cancellationToken);

        // آمار خرید
        var purchaseOverview = await GetPurchaseOverviewAsync(fromDate, toDate, currentMonth, currentYear, lastMonth, lastMonthYear, cancellationToken);

        // آمار موجودی
        var inventoryOverview = await GetInventoryOverviewAsync(cancellationToken);

        // آمار مالی
        var financialOverview = await GetFinancialOverviewAsync(cancellationToken);

        // آمار مشتریان
        var customerOverview = await GetCustomerOverviewAsync(currentMonth, currentYear, cancellationToken);

        // آمار تامین‌کنندگان
        var vendorOverview = await GetVendorOverviewAsync(currentMonth, currentYear, cancellationToken);

        // آمار وظایف
        var taskOverview = await GetTaskOverviewAsync(cancellationToken);

        // نمودارهای ماهانه
        var monthlySalesChart = await GetMonthlySalesChartAsync(fromDate, toDate, cancellationToken);
        var monthlyPurchaseChart = await GetMonthlyPurchaseChartAsync(fromDate, toDate, cancellationToken);

        // نمودار موجودی بر اساس دسته‌بندی
        var inventoryByCategoryChart = await GetInventoryByCategoryChartAsync(cancellationToken);

        // نمودار وضعیت وظایف
        var taskStatusChart = await GetTaskStatusChartAsync(cancellationToken);

        return new DashboardOverviewDto
        {
            SalesOverview = salesOverview,
            PurchaseOverview = purchaseOverview,
            InventoryOverview = inventoryOverview,
            FinancialOverview = financialOverview,
            CustomerOverview = customerOverview,
            VendorOverview = vendorOverview,
            TaskOverview = taskOverview,
            MonthlySalesChart = monthlySalesChart,
            MonthlyPurchaseChart = monthlyPurchaseChart,
            InventoryByCategoryChart = inventoryByCategoryChart,
            TaskStatusChart = taskStatusChart
        };
    }

    private async Task<SalesOverviewDto> GetSalesOverviewAsync(DateTime fromDate, DateTime toDate, int currentMonth, int currentYear, int lastMonth, int lastMonthYear, CancellationToken cancellationToken)
    {
        var totalOrders = await _context.SalesOrders.CountAsync(cancellationToken);
        var pendingOrders = await _context.SalesOrders.CountAsync(so => so.Status == "در حال انجام", cancellationToken);
        var completedOrders = await _context.SalesOrders.CountAsync(so => so.Status == "تکمیل شده", cancellationToken);
        var totalSales = await _context.SalesOrders.SumAsync(so => so.TotalAmount, cancellationToken);
        
        var monthlySales = await _context.SalesOrders
            .Where(so => so.OrderDate.Month == currentMonth && so.OrderDate.Year == currentYear)
            .SumAsync(so => so.TotalAmount, cancellationToken);

        var lastMonthSales = await _context.SalesOrders
            .Where(so => so.OrderDate.Month == lastMonth && so.OrderDate.Year == lastMonthYear)
            .SumAsync(so => so.TotalAmount, cancellationToken);

        var salesGrowthPercentage = lastMonthSales > 0 ? (decimal)((monthlySales - lastMonthSales) / lastMonthSales) * 100m : 0m;

        return new SalesOverviewDto
        {
            TotalOrders = totalOrders,
            PendingOrders = pendingOrders,
            CompletedOrders = completedOrders,
            TotalSales = totalSales,
            MonthlySales = monthlySales,
            SalesGrowthPercentage = salesGrowthPercentage
        };
    }

    private async Task<PurchaseOverviewDto> GetPurchaseOverviewAsync(DateTime fromDate, DateTime toDate, int currentMonth, int currentYear, int lastMonth, int lastMonthYear, CancellationToken cancellationToken)
    {
        var totalOrders = await _context.PurchaseOrders.CountAsync(cancellationToken);
        var pendingOrders = await _context.PurchaseOrders.CountAsync(po => po.Status == "در حال انجام", cancellationToken);
        var completedOrders = await _context.PurchaseOrders.CountAsync(po => po.Status == "تکمیل شده", cancellationToken);
        var totalPurchases = await _context.PurchaseOrders.SumAsync(po => po.TotalAmount, cancellationToken);
        
        var monthlyPurchases = await _context.PurchaseOrders
            .Where(po => po.OrderDate.Month == currentMonth && po.OrderDate.Year == currentYear)
            .SumAsync(po => po.TotalAmount, cancellationToken);

        var lastMonthPurchases = await _context.PurchaseOrders
            .Where(po => po.OrderDate.Month == lastMonth && po.OrderDate.Year == lastMonthYear)
            .SumAsync(po => po.TotalAmount, cancellationToken);

        var purchaseGrowthPercentage = lastMonthPurchases > 0 ? (decimal)((monthlyPurchases - lastMonthPurchases) / lastMonthPurchases) * 100m : 0m;

        return new PurchaseOverviewDto
        {
            TotalOrders = totalOrders,
            PendingOrders = pendingOrders,
            CompletedOrders = completedOrders,
            TotalPurchases = totalPurchases,
            MonthlyPurchases = monthlyPurchases,
            PurchaseGrowthPercentage = purchaseGrowthPercentage
        };
    }

    private async Task<InventoryOverviewDto> GetInventoryOverviewAsync(CancellationToken cancellationToken)
    {
        var totalProducts = await _context.Products.CountAsync(cancellationToken);
        var lowStockProducts = await _context.Inventory.CountAsync(i => i.AvailableQuantity <= i.MinStockAlert, cancellationToken);
        var outOfStockProducts = await _context.Inventory.CountAsync(i => i.AvailableQuantity <= 0, cancellationToken);
        var totalInventoryValue = await _context.Inventory
            .Where(i => i.AverageCost != null)
            .SumAsync(i => i.Quantity * i.AverageCost!.Amount, cancellationToken);
        var totalWarehouses = await _context.Warehouses.CountAsync(cancellationToken);
        var totalBins = await _context.Bins.CountAsync(cancellationToken);

        return new InventoryOverviewDto
        {
            TotalProducts = totalProducts,
            LowStockProducts = lowStockProducts,
            OutOfStockProducts = outOfStockProducts,
            TotalInventoryValue = totalInventoryValue,
            TotalWarehouses = totalWarehouses,
            TotalBins = totalBins
        };
    }

    private async Task<FinancialOverviewDto> GetFinancialOverviewAsync(CancellationToken cancellationToken)
    {
        var totalRevenue = await _context.SalesOrders.SumAsync(so => so.TotalAmount, cancellationToken);
        var totalExpenses = await _context.PurchaseOrders.SumAsync(po => po.TotalAmount, cancellationToken);
        var netProfit = totalRevenue - totalExpenses;
        var totalBankAccounts = await _context.BankAccounts.CountAsync(cancellationToken);
        var totalBankBalance = await _context.BankAccounts.SumAsync(ba => ba.CurrentBalance, cancellationToken);
        var totalCashBoxes = await _context.CashBoxes.CountAsync(cancellationToken);
        var totalCashBalance = await _context.CashBoxes.SumAsync(cb => cb.CurrentBalance, cancellationToken);

        return new FinancialOverviewDto
        {
            TotalRevenue = totalRevenue,
            TotalExpenses = totalExpenses,
            NetProfit = netProfit,
            TotalBankAccounts = totalBankAccounts,
            TotalBankBalance = totalBankBalance,
            TotalCashBoxes = totalCashBoxes,
            TotalCashBalance = totalCashBalance
        };
    }

    private async Task<CustomerOverviewDto> GetCustomerOverviewAsync(int currentMonth, int currentYear, CancellationToken cancellationToken)
    {
        var totalCustomers = await _context.Customers.CountAsync(cancellationToken);
        var activeCustomers = await _context.Customers.CountAsync(c => c.IsActive, cancellationToken);
        var newCustomersThisMonth = await _context.Customers
            .CountAsync(c => c.CreatedAt.Month == currentMonth && c.CreatedAt.Year == currentYear, cancellationToken);
        
        var averageOrderValue = await _context.SalesOrders
            .GroupBy(so => so.CustomerId)
            .Select(g => g.Average(so => so.TotalAmount))
            .DefaultIfEmpty(0)
            .AverageAsync(cancellationToken);

        return new CustomerOverviewDto
        {
            TotalCustomers = totalCustomers,
            ActiveCustomers = activeCustomers,
            NewCustomersThisMonth = newCustomersThisMonth,
            AverageOrderValue = averageOrderValue
        };
    }

    private async Task<VendorOverviewDto> GetVendorOverviewAsync(int currentMonth, int currentYear, CancellationToken cancellationToken)
    {
        var totalVendors = await _context.Vendors.CountAsync(cancellationToken);
        var activeVendors = await _context.Vendors.CountAsync(v => v.IsActive, cancellationToken);
        var newVendorsThisMonth = await _context.Vendors
            .CountAsync(v => v.CreatedAt.Month == currentMonth && v.CreatedAt.Year == currentYear, cancellationToken);
        
        return new VendorOverviewDto
        {
            TotalVendors = totalVendors,
            ActiveVendors = activeVendors,
            NewVendorsThisMonth = newVendorsThisMonth
        };
    }

    private async Task<TaskOverviewDto> GetTaskOverviewAsync(CancellationToken cancellationToken)
    {
        var totalTasks = await _context.Tasks.CountAsync(cancellationToken);
        var activeTasks = await _context.Tasks.CountAsync(t => t.Status != "Completed" && t.Status != "Cancelled", cancellationToken);
        var completedTasks = await _context.Tasks.CountAsync(t => t.Status == "Completed", cancellationToken);
        return new TaskOverviewDto
        {
            TotalTasks = totalTasks,
            ActiveTasks = activeTasks,
            CompletedTasks = completedTasks
        };
    }

    private async Task<List<MonthlyValueDto>> GetMonthlySalesChartAsync(DateTime fromDate, DateTime toDate, CancellationToken cancellationToken)
    {
        return await _context.SalesOrders
            .Where(so => so.OrderDate >= fromDate && so.OrderDate <= toDate)
            .GroupBy(so => new { so.OrderDate.Year, so.OrderDate.Month })
            .Select(g => new MonthlyValueDto { Year = g.Key.Year, Month = g.Key.Month, Value = g.Sum(so => so.TotalAmount) })
            .OrderBy(x => x.Year).ThenBy(x => x.Month)
            .ToListAsync(cancellationToken);
    }

    private async Task<List<MonthlyValueDto>> GetMonthlyPurchaseChartAsync(DateTime fromDate, DateTime toDate, CancellationToken cancellationToken)
    {
        return await _context.PurchaseOrders
            .Where(po => po.OrderDate >= fromDate && po.OrderDate <= toDate)
            .GroupBy(po => new { po.OrderDate.Year, po.OrderDate.Month })
            .Select(g => new MonthlyValueDto { Year = g.Key.Year, Month = g.Key.Month, Value = g.Sum(po => po.TotalAmount) })
            .OrderBy(x => x.Year).ThenBy(x => x.Month)
            .ToListAsync(cancellationToken);
    }

    private async Task<List<CategoryValueDto>> GetInventoryByCategoryChartAsync(CancellationToken cancellationToken)
    {
        return await _context.Inventory
            .GroupBy(i => i.Product.CategoryId)
            .Select(g => new CategoryValueDto { CategoryId = g.Key, Value = g.Sum(i => i.Quantity) })
            .OrderByDescending(x => x.Value)
            .Take(10)
            .ToListAsync(cancellationToken);
    }

    private async Task<List<StatusValueDto>> GetTaskStatusChartAsync(CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .GroupBy(t => t.Status)
            .Select(g => new StatusValueDto { Status = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ToListAsync(cancellationToken);
    }
}
