using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Categories.Queries.GetCategoryById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت دسته‌بندی بر اساس شناسه
/// </summary>
public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت دسته‌بندی بر اساس شناسه
    /// </summary>
    public GetCategoryByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories
            .Include(c => c.ParentCategory)
            .Include(c => c.Products)
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category == null)
        {
            return null;
        }

        var dto = _mapper.Map<CategoryDto>(category);
        dto.ParentCategoryName = category.ParentCategory?.Name;
        dto.ProductCount = category.Products?.Count ?? 0;
        dto.SubcategoryCount = category.SubCategories?.Count ?? 0;
        return dto;
    }
}
