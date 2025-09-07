using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetChartOfAccountById;

/// <summary>
/// پرس‌وجو دریافت حساب کل بر اساس شناسه
/// </summary>
public sealed class GetChartOfAccountByIdQuery : IRequest<ChartOfAccountDto?>
{
    /// <summary>
    /// شناسه حساب کل
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب کل الزامی است")]
    public Guid Id { get; set; }
}
