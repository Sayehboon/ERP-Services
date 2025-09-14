using MediatR;
using Dinawin.Erp.Application.Features.Categories.DTOs;

namespace Dinawin.Erp.Application.Features.Categories.Queries.GetAllCategories;

/// <summary>
/// Query for getting all categories with optional filtering
/// </summary>
public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
    public string SearchTerm { get; set; }
    public Guid? ParentId { get; set; }
    public bool? IsActive { get; set; } = true;
    public bool IncludeChildren { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}