using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductById;

/// <summary>
/// پرس‌وجو دریافت محصول بر اساس شناسه
/// </summary>
public sealed class GetProductByIdQuery : IRequest<ProductDto>
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    [Required(ErrorMessage = "شناسه محصول الزامی است")]
    public Guid Id { get; set; }
}