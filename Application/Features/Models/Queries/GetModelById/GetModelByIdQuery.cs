using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Models.Queries.GetModelById;

/// <summary>
/// پرس‌وجو دریافت مدل بر اساس شناسه
/// </summary>
public sealed class GetModelByIdQuery : IRequest<ModelDto>
{
    /// <summary>
    /// شناسه مدل
    /// </summary>
    [Required(ErrorMessage = "شناسه مدل الزامی است")]
    public Guid Id { get; set; }
}
