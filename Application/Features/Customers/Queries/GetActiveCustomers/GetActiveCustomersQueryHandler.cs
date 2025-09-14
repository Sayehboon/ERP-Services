using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetActiveCustomers;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت مشتریان فعال
/// </summary>
public sealed class GetActiveCustomersQueryHandler : IRequestHandler<GetActiveCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت مشتریان فعال
    /// </summary>
    public GetActiveCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت مشتریان فعال
    /// </summary>
    public async Task<IEnumerable<CustomerDto>> Handle(GetActiveCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Customers
            .Where(c => c.IsActive)
            .AsQueryable();

        // فیلتر بر اساس شرکت
        //if (request.CompanyId.HasValue)
        //{
        //    query = query.Where(c => c.CompanyId == request.CompanyId.Value);
        //}

        // جستجو در نام، کد مشتری و اطلاعات تماس
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(c => 
                c.Name.ToLower().Contains(searchLower) ||
                c.Code.ToLower().Contains(searchLower) ||
                (c.Email != null && c.Email.ToLower().Contains(searchLower)) ||
                (c.Phone != null && c.Phone.ToLower().Contains(searchLower)) ||
                (c.Mobile != null && c.Mobile.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس نوع مشتری
        if (!string.IsNullOrWhiteSpace(request.CustomerType))
        {
            query = query.Where(c => c.CustomerType == request.CustomerType);
        }

        // فیلتر بر اساس شهر
        if (!string.IsNullOrWhiteSpace(request.City))
        {
            query = query.Where(c => c.City == request.City);
        }

        // مرتب‌سازی
        query = query.OrderBy(c => c.Name).ThenBy(c => c.LastName);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var customers = await query.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }
}
