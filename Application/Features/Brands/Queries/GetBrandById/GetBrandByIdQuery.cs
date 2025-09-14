using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Brands.Queries.GetBrandById;

/// <summary>
/// پرس‌وجو دریافت برند بر اساس شناسه
/// </summary>
public sealed class GetBrandByIdQuery : IRequest<BrandDto>
{
    /// <summary>
    /// شناسه برند
    /// </summary>
    [Required(ErrorMessage = "شناسه برند الزامی است")]
    public Guid Id { get; set; }
}


