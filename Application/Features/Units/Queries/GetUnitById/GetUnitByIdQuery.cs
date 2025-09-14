using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Units.Queries.GetUnitById;

/// <summary>
/// پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
/// </summary>
public sealed class GetUnitByIdQuery : IRequest<UnitDto>
{
    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "شناسه واحد اندازه‌گیری الزامی است")]
    public Guid Id { get; set; }
}
