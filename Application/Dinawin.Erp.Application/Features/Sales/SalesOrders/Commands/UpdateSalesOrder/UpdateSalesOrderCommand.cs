using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Commands.UpdateSalesOrder;

/// <summary>
/// دستور به‌روزرسانی سفارش فروش
/// </summary>
public sealed class UpdateSalesOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه سفارش فروش
    /// </summary>
    [Required(ErrorMessage = "شناسه سفارش فروش الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شماره سفارش
    /// </summary>
    [Required(ErrorMessage = "شماره سفارش الزامی است")]
    [StringLength(50, ErrorMessage = "شماره سفارش نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// شناسه مشتری
    /// </summary>
    [Required(ErrorMessage = "شناسه مشتری الزامی است")]
    public Guid CustomerId { get; set; }

    /// <summary>
    /// شناسه فرصت
    /// </summary>
    public Guid? OpportunityId { get; set; }

    /// <summary>
    /// تاریخ سفارش
    /// </summary>
    [Required(ErrorMessage = "تاریخ سفارش الزامی است")]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// تاریخ تحویل مورد انتظار
    /// </summary>
    public DateTime? ExpectedDeliveryDate { get; set; }

    /// <summary>
    /// تاریخ تحویل واقعی
    /// </summary>
    public DateTime? ActualDeliveryDate { get; set; }

    /// <summary>
    /// وضعیت سفارش
    /// </summary>
    [Required(ErrorMessage = "وضعیت سفارش الزامی است")]
    [StringLength(30, ErrorMessage = "وضعیت سفارش نمی‌تواند بیش از 30 کاراکتر باشد")]
    public string Status { get; set; } = "Draft";

    /// <summary>
    /// نوع سفارش
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع سفارش نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? OrderType { get; set; }

    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedById { get; set; }

    /// <summary>
    /// مبلغ کل سفارش
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ کل سفارش باید مثبت باشد")]
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// مبلغ تخفیف
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ تخفیف باید مثبت باشد")]
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// مبلغ مالیات
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ مالیات باید مثبت باشد")]
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// مبلغ نهایی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ نهایی باید مثبت باشد")]
    public decimal FinalAmount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    [StringLength(10, ErrorMessage = "کد ارز نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ تبدیل ارز
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "نرخ تبدیل ارز باید مثبت باشد")]
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// روش پرداخت
    /// </summary>
    [StringLength(50, ErrorMessage = "روش پرداخت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// شرایط پرداخت
    /// </summary>
    [StringLength(100, ErrorMessage = "شرایط پرداخت نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? PaymentTerms { get; set; }

    /// <summary>
    /// آدرس تحویل
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس تحویل نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? DeliveryAddress { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(2000, ErrorMessage = "توضیحات نمی‌تواند بیش از 2000 کاراکتر باشد")]
    public string? Notes { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}