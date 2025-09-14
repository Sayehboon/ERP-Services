using MediatR;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxById;

/// <summary>
/// درخواست دریافت صندوق نقدی بر اساس شناسه
/// </summary>
public class GetCashBoxByIdQuery : IRequest<CashBoxDto>
{
    /// <summary>
    /// شناسه صندوق نقدی
    /// </summary>
    public Guid Id { get; set; }
}
