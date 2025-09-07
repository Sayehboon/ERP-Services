using MediatR;

namespace Dinawin.Erp.Application.Features.Categories.Commands.CreateCategory;

/// <summary>
/// Command for creating a new category
/// </summary>
public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; } = 0;
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public Guid? CreatedBy { get; set; }
}

