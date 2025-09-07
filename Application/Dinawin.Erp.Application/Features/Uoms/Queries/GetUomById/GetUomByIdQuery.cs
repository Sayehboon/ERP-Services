using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetUomById;

/// <summary>
/// پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
/// </summary>
public sealed class GetUomByIdQuery : IRequest<UomDto?>
{
    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "شناسه واحد اندازه‌گیری الزامی است")]
    public Guid Id { get; set; }
}
