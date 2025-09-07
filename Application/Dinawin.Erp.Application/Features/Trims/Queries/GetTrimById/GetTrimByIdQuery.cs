using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Trims.Queries.GetTrimById;

/// <summary>
/// پرس‌وجو دریافت تریم بر اساس شناسه
/// </summary>
public sealed class GetTrimByIdQuery : IRequest<TrimDto?>
{
    /// <summary>
    /// شناسه تریم
    /// </summary>
    [Required(ErrorMessage = "شناسه تریم الزامی است")]
    public Guid Id { get; set; }
}
