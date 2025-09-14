using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.UomConversions.Queries.GetUomConversionById;

/// <summary>
/// پرس‌وجو دریافت تبدیل واحد اندازه‌گیری بر اساس شناسه
/// </summary>
public sealed class GetUomConversionByIdQuery : IRequest<UomConversionDto>
{
    /// <summary>
    /// شناسه تبدیل واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "شناسه تبدیل واحد اندازه‌گیری الزامی است")]
    public Guid Id { get; set; }
}
