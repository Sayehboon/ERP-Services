using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Years.Queries.GetYearById;

/// <summary>
/// پرس‌وجو دریافت سال بر اساس شناسه
/// </summary>
public sealed class GetYearByIdQuery : IRequest<YearDto?>
{
    /// <summary>
    /// شناسه سال
    /// </summary>
    [Required(ErrorMessage = "شناسه سال الزامی است")]
    public Guid Id { get; set; }
}
