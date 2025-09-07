namespace Dinawin.Erp.Application.Features.Categories.DTOs;

/// <summary>
/// DTO for Category entity
/// </summary>
public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    public string? ParentName { get; set; }
    public bool IsActive { get; set; }
    public int SortOrder { get; set; }
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public List<CategoryDto> Children { get; set; } = new List<CategoryDto>();
    public int ProductsCount { get; set; }
}

/// <summary>
/// DTO for creating a category
/// </summary>
public class CreateCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; } = 0;
    public string? Icon { get; set; }
    public string? Color { get; set; }
}

/// <summary>
/// DTO for updating a category
/// </summary>
public class UpdateCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsActive { get; set; }
    public int SortOrder { get; set; }
    public string? Icon { get; set; }
    public string? Color { get; set; }
}

