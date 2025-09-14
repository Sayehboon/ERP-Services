using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxTransactions;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تراکنش‌های صندوق نقدی
/// </summary>
public sealed class GetCashBoxTransactionsQueryHandler : IRequestHandler<GetCashBoxTransactionsQuery, IEnumerable<CashBoxTransactionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تراکنش‌های صندوق نقدی
    /// </summary>
    public GetCashBoxTransactionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت تراکنش‌های صندوق نقدی
    /// </summary>
    public async Task<IEnumerable<CashBoxTransactionDto>> Handle(GetCashBoxTransactionsQuery request, CancellationToken cancellationToken)
    {
        // دریافت تراکنش‌های پرداخت فروش
        var salePaymentTransactions = await GetSalePaymentTransactions(request, cancellationToken);

        // دریافت تراکنش‌های پرداخت خرید
        var purchasePaymentTransactions = await GetPurchasePaymentTransactions(request, cancellationToken);

        // دریافت تراکنش‌های انتقال بین صندوق‌ها
        var transferTransactions = await GetTransferTransactions(request, cancellationToken);

        // دریافت تراکنش‌های دستی
        var manualTransactions = await GetManualTransactions(request, cancellationToken);

        // ترکیب و مرتب‌سازی تمام تراکنش‌ها
        var allTransactions = salePaymentTransactions
            .Concat(purchasePaymentTransactions)
            .Concat(transferTransactions)
            .Concat(manualTransactions)
            .OrderByDescending(t => t.TransactionDate)
            .Take(request.MaxResults)
            .ToList();

        return allTransactions;
    }

    /// <summary>
    /// دریافت تراکنش‌های پرداخت فروش
    /// </summary>
    private async Task<List<CashBoxTransactionDto>> GetSalePaymentTransactions(GetCashBoxTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.SalePayments
            .Include(sp => sp.Sale)
                .ThenInclude(s => s.Customer)
            .Include(sp => sp.CashBox)
            .Include(sp => sp.CreatedByUser)
            .Include(sp => sp.ApprovedByUser)
            .Where(sp => sp.CashBoxId == request.CashBoxId && sp.PaymentMethod == "Cash");

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
            query = query.Where(sp => sp.PaymentDate >= request.FromDate.Value);
        if (request.ToDate.HasValue)
            query = query.Where(sp => sp.PaymentDate <= request.ToDate.Value);

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
            query = query.Where(sp => sp.Amount >= request.MinAmount.Value);
        if (request.MaxAmount.HasValue)
            query = query.Where(sp => sp.Amount <= request.MaxAmount.Value);

        var payments = await query.ToListAsync(cancellationToken);

        return payments.Select(payment => new CashBoxTransactionDto
        {
            Id = payment.Id,
            CashBoxId = payment.CashBoxId,
            CashBoxName = payment.CashBox?.Name ?? "نامشخص",
            TransactionDate = payment.PaymentDate,
            TransactionType = "SalePayment",
            TransactionTypePersian = "دریافت نقدی فروش",
            Amount = payment.Amount,
            Currency = payment.Currency,
            ExchangeRate = payment.ExchangeRate,
            AmountInBaseCurrency = payment.AmountInBaseCurrency,
            Description = $"دریافت نقدی فروش - {payment.Sale.OrderNumber}",
            ReferenceNumber = payment.ReferenceNumber,
            ReferenceType = "SalePayment",
            ReferenceId = payment.Id,
            Status = payment.Status,
            StatusPersian = GetStatusPersian(payment.Status),
            CreatedBy = payment.CreatedBy,
            CreatedByName = payment.CreatedByUser?.FirstName + " " + payment.CreatedByUser?.LastName,
            ApprovedBy = payment.ApprovedBy,
            ApprovedByName = payment.ApprovedByUser?.FirstName + " " + payment.ApprovedByUser?.LastName,
            ApprovedAt = payment.ApprovedAt,
            CreatedAt = payment.CreatedAt,
            UpdatedAt = payment.UpdatedAt,
            CustomerId = payment.Sale.CustomerId,
            CustomerName = payment.Sale.Customer?.Name + " " + payment.Sale.Customer?.LastName
        }).ToList();
    }

    /// <summary>
    /// دریافت تراکنش‌های پرداخت خرید
    /// </summary>
    private async Task<List<CashBoxTransactionDto>> GetPurchasePaymentTransactions(GetCashBoxTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.PurchasePayments
            .Include(pp => pp.PurchaseOrder)
                .ThenInclude(po => po.Vendor)
            .Include(pp => pp.CashBox)
            .Include(pp => pp.CreatedByUser)
            .Include(pp => pp.ApprovedByUser)
            .Where(pp => pp.CashBoxId == request.CashBoxId && pp.PaymentMethod == "Cash");

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
            query = query.Where(pp => pp.PaymentDate >= request.FromDate.Value);
        if (request.ToDate.HasValue)
            query = query.Where(pp => pp.PaymentDate <= request.ToDate.Value);

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
            query = query.Where(pp => pp.Amount >= request.MinAmount.Value);
        if (request.MaxAmount.HasValue)
            query = query.Where(pp => pp.Amount <= request.MaxAmount.Value);

        var payments = await query.ToListAsync(cancellationToken);

        return payments.Select(payment => new CashBoxTransactionDto
        {
            Id = payment.Id,
            CashBoxId = payment.CashBoxId,
            CashBoxName = payment.CashBox?.Name ?? "نامشخص",
            TransactionDate = payment.PaymentDate,
            TransactionType = "PurchasePayment",
            TransactionTypePersian = "پرداخت نقدی خرید",
            Amount = -payment.Amount, // پرداخت خرید منفی است
            Currency = payment.Currency,
            ExchangeRate = payment.ExchangeRate,
            AmountInBaseCurrency = payment.AmountInBaseCurrency,
            Description = $"پرداخت نقدی خرید - {payment.PurchaseOrder.OrderNumber}",
            ReferenceNumber = payment.ReferenceNumber,
            ReferenceType = "PurchasePayment",
            ReferenceId = payment.Id,
            Status = payment.Status,
            StatusPersian = GetStatusPersian(payment.Status),
            CreatedBy = payment.CreatedBy,
            CreatedByName = payment.CreatedByUser?.FirstName + " " + payment.CreatedByUser?.LastName,
            ApprovedBy = payment.ApprovedBy,
            ApprovedByName = payment.ApprovedByUser?.FirstName + " " + payment.ApprovedByUser?.LastName,
            ApprovedAt = payment.ApprovedAt,
            CreatedAt = payment.CreatedAt,
            UpdatedAt = payment.UpdatedAt,
            VendorId = payment.PurchaseOrder.VendorId,
            VendorName = payment.PurchaseOrder.Vendor?.Name
        }).ToList();
    }

    /// <summary>
    /// دریافت تراکنش‌های انتقال بین صندوق‌ها
    /// </summary>
    private async Task<List<CashBoxTransactionDto>> GetTransferTransactions(GetCashBoxTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.CashBoxTransfers
            .Include(ct => ct.SourceCashBox)
            .Include(ct => ct.TargetCashBox)
            .Include(ct => ct.CreatedByUser)
            .Include(ct => ct.ApprovedByUser)
            .Where(ct => ct.SourceCashBoxId == request.CashBoxId || ct.TargetCashBoxId == request.CashBoxId);

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
            query = query.Where(ct => ct.TransferDate >= request.FromDate.Value);
        if (request.ToDate.HasValue)
            query = query.Where(ct => ct.TransferDate <= request.ToDate.Value);

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
            query = query.Where(ct => ct.Amount >= request.MinAmount.Value);
        if (request.MaxAmount.HasValue)
            query = query.Where(ct => ct.Amount <= request.MaxAmount.Value);

        var transfers = await query.ToListAsync(cancellationToken);

        return transfers.Select(transfer => new CashBoxTransactionDto
        {
            Id = transfer.Id,
            CashBoxId = request.CashBoxId,
            CashBoxName = request.CashBoxId == transfer.SourceCashBoxId ? 
                transfer.SourceCashBox?.Name ?? "نامشخص" : transfer.TargetCashBox?.Name ?? "نامشخص",
            TransactionDate = transfer.TransferDate,
            TransactionType = request.CashBoxId == transfer.SourceCashBoxId ? "TransferOut" : "TransferIn",
            TransactionTypePersian = request.CashBoxId == transfer.SourceCashBoxId ? "انتقال به صندوق دیگر" : "دریافت از صندوق دیگر",
            Amount = request.CashBoxId == transfer.SourceCashBoxId ? -transfer.Amount : transfer.Amount,
            Currency = transfer.Currency,
            ExchangeRate = transfer.ExchangeRate,
            AmountInBaseCurrency = transfer.AmountInBaseCurrency,
            Description = transfer.Description,
            ReferenceNumber = transfer.ReferenceNumber,
            ReferenceType = "CashBoxTransfer",
            ReferenceId = transfer.Id,
            Status = transfer.Status,
            StatusPersian = GetStatusPersian(transfer.Status),
            CreatedBy = transfer.CreatedBy,
            CreatedByName = transfer.CreatedByUser?.FirstName + " " + transfer.CreatedByUser?.LastName,
            ApprovedBy = transfer.ApprovedBy,
            ApprovedByName = transfer.ApprovedByUser?.FirstName + " " + transfer.ApprovedByUser?.LastName,
            ApprovedAt = transfer.ApprovedAt,
            CreatedAt = transfer.CreatedAt,
            UpdatedAt = transfer.UpdatedAt,
            TargetCashBoxId = request.CashBoxId == transfer.SourceCashBoxId ? transfer.TargetCashBoxId : transfer.SourceCashBoxId,
            TargetCashBoxName = request.CashBoxId == transfer.SourceCashBoxId ? 
                transfer.TargetCashBox?.Name : transfer.SourceCashBox?.Name
        }).ToList();
    }

    /// <summary>
    /// دریافت تراکنش‌های دستی
    /// </summary>
    private async Task<List<CashBoxTransactionDto>> GetManualTransactions(GetCashBoxTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.CashBoxTransactions
            .Include(ct => ct.CashBox)
            .Include(ct => ct.CreatedByUser)
            .Include(ct => ct.ApprovedByUser)
            .Where(ct => ct.CashBoxId == request.CashBoxId);

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
            query = query.Where(ct => ct.TransactionDate >= request.FromDate.Value);
        if (request.ToDate.HasValue)
            query = query.Where(ct => ct.TransactionDate <= request.ToDate.Value);

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
            query = query.Where(ct => ct.Amount >= request.MinAmount.Value);
        if (request.MaxAmount.HasValue)
            query = query.Where(ct => ct.Amount <= request.MaxAmount.Value);

        var transactions = await query.ToListAsync(cancellationToken);

        return transactions.Select(transaction => new CashBoxTransactionDto
        {
            Id = transaction.Id,
            CashBoxId = transaction.CashBoxId,
            CashBoxName = transaction.CashBox?.Name ?? "نامشخص",
            TransactionDate = transaction.TransactionDate,
            TransactionType = transaction.TransactionType,
            TransactionTypePersian = GetTransactionTypePersian(transaction.TransactionType),
            Amount = transaction.Amount,
            Currency = transaction.Currency,
            ExchangeRate = transaction.ExchangeRate,
            AmountInBaseCurrency = transaction.AmountInBaseCurrency,
            Description = transaction.Description,
            ReferenceNumber = transaction.ReferenceNumber,
            ReferenceType = "ManualTransaction",
            ReferenceId = transaction.Id,
            Status = transaction.Status,
            StatusPersian = GetStatusPersian(transaction.Status),
            BalanceBefore = transaction.BalanceBefore,
            BalanceAfter = transaction.BalanceAfter,
            CreatedBy = transaction.CreatedBy,
            CreatedByName = transaction.CreatedByUser?.FirstName + " " + transaction.CreatedByUser?.LastName,
            ApprovedBy = transaction.ApprovedBy,
            ApprovedByName = transaction.ApprovedByUser?.FirstName + " " + transaction.ApprovedByUser?.LastName,
            ApprovedAt = transaction.ApprovedAt,
            CreatedAt = transaction.CreatedAt,
            UpdatedAt = transaction.UpdatedAt
        }).ToList();
    }

    /// <summary>
    /// تبدیل نوع تراکنش انگلیسی به فارسی
    /// </summary>
    private static string GetTransactionTypePersian(string transactionType)
    {
        return transactionType.ToLower() switch
        {
            "deposit" => "واریز",
            "withdrawal" => "برداشت",
            "adjustment" => "تنظیم",
            "opening_balance" => "موجودی اولیه",
            "closing_balance" => "موجودی نهایی",
            _ => transactionType
        };
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
