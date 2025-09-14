using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Categories.DTOs;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Application.Features.Categories.Queries.GetCategoriesTree;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت درخت دسته‌بندی‌ها
/// </summary>
public sealed class GetCategoriesTreeQueryHandler : IRequestHandler<GetCategoriesTreeQuery, IEnumerable<CategoryTreeDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت درخت دسته‌بندی‌ها
    /// </summary>
    public GetCategoriesTreeQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت درخت دسته‌بندی‌ها
    /// </summary>
    public async Task<IEnumerable<CategoryTreeDto>> Handle(GetCategoriesTreeQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Categories
            .Include(c => c.SubCategories)
            .AsQueryable();

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        if (request.OnlyActive.HasValue)
        {
            query = query.Where(c => c.IsActive == request.OnlyActive.Value);
        }

        // فیلتر بر اساس دسته‌بندی والد
        if (request.ParentId.HasValue)
        {
            query = query.Where(c => c.ParentCategoryId == request.ParentId.Value);
        }
        else
        {
            // فقط دسته‌بندی‌های ریشه (بدون والد)
            query = query.Where(c => c.ParentCategoryId == null);
        }

        var categories = await query
            .OrderBy(c => c.Name)
            .ToListAsync(cancellationToken);

        return BuildCategoryTree(categories);
    }

    /// <summary>
    /// ساخت درخت دسته‌بندی‌ها
    /// </summary>
    private static IEnumerable<CategoryTreeDto> BuildCategoryTree(IEnumerable<Category> categories)
    {
        var categoryDict = categories.ToDictionary(c => c.Id, c => new CategoryTreeDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            IsActive = c.IsActive,
            ParentId = c.ParentCategoryId,
            Children = new List<CategoryTreeDto>()
        });

        var rootCategories = new List<CategoryTreeDto>();

        foreach (var category in categories)
        {
            var categoryDto = categoryDict[category.Id];
            
            if (category.ParentCategoryId == null)
            {
                rootCategories.Add(categoryDto);
            }
            else if (categoryDict.ContainsKey(category.ParentCategoryId.Value))
            {
                categoryDict[category.ParentCategoryId.Value].Children.Add(categoryDto);
            }
        }

        return rootCategories;
    }
}
