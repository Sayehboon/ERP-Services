using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Categories.DTOs;

namespace Dinawin.Erp.Application.Features.Categories.Queries.GetAllCategories;

/// <summary>
/// Handler for getting all categories
/// </summary>
public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoriesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Categories
            .Include(c => c.ParentCategory)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(c => c.Name.Contains(request.SearchTerm) ||
                                   (c.Description != null && c.Description.Contains(request.SearchTerm)));
        }

        if (request.ParentId.HasValue)
            query = query.Where(c => c.ParentCategoryId == request.ParentId.Value);

        if (request.IsActive.HasValue)
            query = query.Where(c => c.IsActive == request.IsActive.Value);

        // Apply pagination
        query = query
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var categories = await query
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ParentId = c.ParentCategoryId,
                ParentName = c.ParentCategory != null ? c.ParentCategory.Name : null,
                IsActive = c.IsActive,
                SortOrder = c.SortOrder,
                Icon = c.Icon,
                Color = c.Color,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                CreatedBy = c.CreatedBy,
                UpdatedBy = c.UpdatedBy,
                ProductsCount = c.Products != null ? c.Products.Count : 0
            })
            .ToListAsync(cancellationToken);

        // Load children if requested
        if (request.IncludeChildren)
        {
            foreach (var category in categories)
            {
                category.Children = await GetChildrenCategories(category.Id, cancellationToken);
            }
        }

        return categories;
    }

    private async Task<List<CategoryDto>> GetChildrenCategories(Guid parentId, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(c => c.ParentCategoryId == parentId && c.IsActive)
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ParentId = c.ParentCategoryId,
                IsActive = c.IsActive,
                SortOrder = c.SortOrder,
                Icon = c.Icon,
                Color = c.Color,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                CreatedBy = c.CreatedBy,
                UpdatedBy = c.UpdatedBy,
                ProductsCount = c.Products != null ? c.Products.Count : 0
            })
            .ToListAsync(cancellationToken);
    }
}

