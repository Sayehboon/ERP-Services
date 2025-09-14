using MediatR;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetAllCashBoxes;

/// <summary>
/// درخواست دریافت تمام صندوق‌های نقدی
/// </summary>
public class GetAllCashBoxesQuery : IRequest<IEnumerable<CashBoxDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; set; }

    /// <summary>
    /// شناسه مسئول صندوق
    /// </summary>
    public Guid? ResponsiblePersonId { get; set; }

    /// <summary>
    /// آیا فقط صندوق‌های فعال
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// اندازه صفحه
    /// </summary>
    public int PageSize { get; set; } = 25;
}
