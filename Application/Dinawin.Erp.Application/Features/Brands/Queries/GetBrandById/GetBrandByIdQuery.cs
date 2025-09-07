using MediatR;
using System.ComponentModel.DataAnnotations;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Brands.Queries.GetBrandById;

/// <summary>
/// پرس‌وجو دریافت برند بر اساس شناسه
/// </summary>
public sealed class GetBrandByIdQuery : IRequest<BrandDto?>
{
    /// <summary>
    /// شناسه برند
    /// </summary>
    [Required(ErrorMessage = "شناسه برند الزامی است")]
    public Guid Id { get; set; }
}


