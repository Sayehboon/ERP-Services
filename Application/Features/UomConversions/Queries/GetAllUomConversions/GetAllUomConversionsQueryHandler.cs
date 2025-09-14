using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.UomConversions.Queries.GetAllUomConversions;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست تبدیلات واحد اندازه‌گیری
/// </summary>
public sealed class GetAllUomConversionsQueryHandler : IRequestHandler<GetAllUomConversionsQuery, IEnumerable<UomConversionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست تبدیلات واحد اندازه‌گیری
    /// </summary>
    public GetAllUomConversionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست تبدیلات واحد اندازه‌گیری
    /// </summary>
    public async Task<IEnumerable<UomConversionDto>> Handle(GetAllUomConversionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UomConversions
            .Include(uc => uc.FromUom)
            .Include(uc => uc.ToUom)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(uc => 
                (uc.Name != null && uc.Name.ToLower().Contains(searchLower)) ||
                (uc.FromUom != null && uc.FromUom.Name.ToLower().Contains(searchLower)) ||
                (uc.ToUom != null && uc.ToUom.Name.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس واحد اندازه‌گیری مبدا
        if (request.FromUomId.HasValue)
        {
            query = query.Where(uc => uc.FromUomId == request.FromUomId.Value);
        }

        // فیلتر بر اساس واحد اندازه‌گیری مقصد
        if (request.ToUomId.HasValue)
        {
            query = query.Where(uc => uc.ToUomId == request.ToUomId.Value);
        }

        // فیلتر بر اساس وضعیت فعال بودن
        if (request.IsActive.HasValue)
        {
            query = query.Where(uc => uc.IsActive == request.IsActive.Value);
        }

        // فیلتر بر اساس ضریب تبدیل
        if (request.MinConversionFactor.HasValue)
        {
            query = query.Where(uc => uc.ConversionFactor >= request.MinConversionFactor.Value);
        }

        if (request.MaxConversionFactor.HasValue)
        {
            query = query.Where(uc => uc.ConversionFactor <= request.MaxConversionFactor.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(uc => uc.FromUom!.Name).ThenBy(uc => uc.ToUom!.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var uomConversions = await query.ToListAsync(cancellationToken);
        
        return uomConversions.Select(uc => new UomConversionDto
        {
            Id = uc.Id,
            FromUomId = uc.FromUomId,
            FromUomName = uc.FromUom?.Name,
            FromUomCode = uc.FromUom?.Code,
            FromUomSymbol = uc.FromUom?.Symbol,
            ToUomId = uc.ToUomId,
            ToUomName = uc.ToUom?.Name,
            ToUomCode = uc.ToUom?.Code,
            ToUomSymbol = uc.ToUom?.Symbol,
            ConversionFactor = uc.ConversionFactor,
            Name = uc.Name,
            Description = uc.Description,
            IsActive = uc.IsActive,
            CreatedAt = uc.CreatedAt,
            UpdatedAt = uc.UpdatedAt,
            CreatedBy = uc.CreatedBy,
            UpdatedBy = uc.UpdatedBy
        });
    }
}
