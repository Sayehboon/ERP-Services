using MediatR;
using System.ComponentModel.DataAnnotations;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Categories.Queries.GetCategoryById;

/// <summary>
/// پرس‌وجو دریافت دسته‌بندی بر اساس شناسه
/// </summary>
public sealed class GetCategoryByIdQuery : IRequest<CategoryDto?>
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    [Required(ErrorMessage = "شناسه دسته‌بندی الزامی است")]
    public Guid Id { get; set; }
}
