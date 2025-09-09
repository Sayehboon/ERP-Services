using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerTransactions;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تراکنش‌های مشتری
/// </summary>
public sealed class GetCustomerTransactionsQueryHandler : IRequestHandler<GetCustomerTransactionsQuery, IEnumerable<CustomerTransactionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تراکنش‌های مشتری
    /// </summary>
    public GetCustomerTransactionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت تراکنش‌های مشتری
    /// </summary>
    public async Task<IEnumerable<CustomerTransactionDto>> Handle(GetCustomerTransactionsQuery request, CancellationToken cancellationToken)
    {
        // دریافت تراکنش‌های فروش
        var saleTransactions = await GetSaleTransactions(request, cancellationToken);

        // دریافت تراکنش‌های پرداخت
        var paymentTransactions = await GetPaymentTransactions(request, cancellationToken);

        // دریافت تراکنش‌های برگشت
        var returnTransactions = await GetReturnTransactions(request, cancellationToken);

        // ترکیب و مرتب‌سازی تمام تراکنش‌ها
        var allTransactions = saleTransactions
            .Concat(paymentTransactions)
            .Concat(returnTransactions)
            .OrderByDescending(t => t.TransactionDate)
            .Take(request.MaxResults)
            .ToList();

        return allTransactions;
    }

    /// <summary>
    /// دریافت تراکنش‌های فروش
    /// </summary>
    private async Task<List<CustomerTransactionDto>> GetSaleTransactions(GetCustomerTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.SalesOrders
            .Include(s => s.Customer)
            .Where(s => s.CustomerId == request.CustomerId);

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
            query = query.Where(s => s.OrderDate >= request.FromDate.Value);
        if (request.ToDate.HasValue)
            query = query.Where(s => s.OrderDate <= request.ToDate.Value);

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
            query = query.Where(s => s.TotalAmount >= request.MinAmount.Value);
        if (request.MaxAmount.HasValue)
            query = query.Where(s => s.TotalAmount <= request.MaxAmount.Value);

        var sales = await query.ToListAsync(cancellationToken);

        return sales.Select(sale => new CustomerTransactionDto
        {
            Id = sale.Id,
            CustomerId = sale.CustomerId,
            CustomerName = sale.Customer?.Name ?? string.Empty,
            TransactionType = "SaleOrder",
            TransactionTypePersian = "سفارش فروش",
            TransactionDate = sale.OrderDate,
            Amount = sale.TotalAmount,
            Currency = sale.Currency,
            ExchangeRate = null,
            AmountInBaseCurrency = null,
            ReferenceNumber = sale.OrderNumber,
            ReferenceType = "SalesOrder",
            ReferenceId = sale.Id,
            Description = $"سفارش فروش - {sale.OrderNumber}",
            Status = sale.Status,
            StatusPersian = GetStatusPersian(sale.Status),
            CreatedBy = null,
            CreatedByName = null,
            CreatedAt = sale.CreatedAt,
            UpdatedAt = sale.UpdatedAt
        }).ToList();
    }

    /// <summary>
    /// دریافت تراکنش‌های پرداخت
    /// </summary>
    private async Task<List<CustomerTransactionDto>> GetPaymentTransactions(GetCustomerTransactionsQuery request, CancellationToken cancellationToken)
    {
        // در مدل فعلی پرداخت فروش تعریف نشده است
        await Task.CompletedTask;
        return new List<CustomerTransactionDto>();
    }

    /// <summary>
    /// دریافت تراکنش‌های برگشت
    /// </summary>
    private async Task<List<CustomerTransactionDto>> GetReturnTransactions(GetCustomerTransactionsQuery request, CancellationToken cancellationToken)
    {
        // در مدل فعلی برگشت فروش تعریف نشده است
        await Task.CompletedTask;
        return new List<CustomerTransactionDto>();
    }

    /// <summary>
    /// تبدیل وضعیت انگلیسی به فارسی
    /// </summary>
    private static string GetStatusPersian(string status)
    {
        return status.ToLower() switch
        {
            "draft" => "پیش‌نویس",
            "pending" => "در انتظار تایید",
            "approved" => "تایید شده",
            "confirmed" => "تایید شده",
            "completed" => "تکمیل شده",
            "cancelled" => "لغو شده",
            "failed" => "ناموفق",
            "success" => "موفق",
            _ => status
        };
    }
}
