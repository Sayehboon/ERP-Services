using MediatR;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetActiveCashBoxes;

/// <summary>
/// پرس‌وجو دریافت صندوق‌های نقدی فعال
/// </summary>
public sealed class GetActiveCashBoxesQuery : IRequest<IEnumerable<CashBoxDto>>
{
    /// <summary>
    /// شناسه کسب‌وکار (اختیاری)
    /// </summary>
    public Guid? BusinessId { get; init; }
}
