using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetActiveVendors;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تامین‌کنندگان فعال
/// </summary>
public sealed class GetActiveVendorsQueryHandler : IRequestHandler<GetActiveVendorsQuery, IEnumerable<VendorDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تامین‌کنندگان فعال
    /// </summary>
    public GetActiveVendorsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت تامین‌کنندگان فعال
    /// </summary>
    public async Task<IEnumerable<VendorDto>> Handle(GetActiveVendorsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Vendors
            .Where(v => v.IsActive)
            .AsQueryable();

        // فیلتر بر اساس نام شرکت
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(v =>
                (v.CompanyName != null && v.CompanyName.ToLower().Contains(searchLower)) ||
                v.Name.ToLower().Contains(searchLower) ||
                (v.Email != null && v.Email.ToLower().Contains(searchLower)) ||
                (v.Phone != null && v.Phone.ToLower().Contains(searchLower)));
        }

        // مرتب‌سازی
        query = query.OrderBy(v => v.CompanyName ?? v.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var vendors = await query.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<VendorDto>>(vendors);
    }
}
