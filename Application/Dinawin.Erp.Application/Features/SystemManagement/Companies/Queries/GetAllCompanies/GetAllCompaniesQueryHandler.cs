using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Queries.GetAllCompanies;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست شرکت‌ها
/// </summary>
public sealed class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست شرکت‌ها
    /// </summary>
    public GetAllCompaniesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست شرکت‌ها
    /// </summary>
    public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Companies.AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(c => 
                c.Name.ToLower().Contains(searchLower) ||
                (c.TradeName != null && c.TradeName.ToLower().Contains(searchLower)) ||
                (c.RegistrationNumber != null && c.RegistrationNumber.Contains(searchLower)) ||
                (c.NationalId != null && c.NationalId.Contains(searchLower)) ||
                (c.EconomicCode != null && c.EconomicCode.Contains(searchLower)));
        }

        // فیلتر بر اساس وضعیت فعال بودن
        if (request.IsActive.HasValue)
        {
            query = query.Where(c => c.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(c => c.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var companies = await query.ToListAsync(cancellationToken);
        
        return companies.Select(c => new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            TradeName = c.TradeName,
            RegistrationNumber = c.RegistrationNumber,
            NationalId = c.NationalId,
            EconomicCode = c.EconomicCode,
            Address = c.Address?.ToString() ?? string.Empty,
            PhoneNumber = c.PhoneNumber,
            // FaxNumber property does not exist in Company entity
            Email = c.Email,
            Website = c.Website,
            // Description property does not exist in Company entity
            IsActive = c.IsActive,
            UsersCount = _context.Users.Count(u => u.CompanyId == c.Id),
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt,
            CreatedBy = c.CreatedBy,
            UpdatedBy = c.UpdatedBy
        });
    }
}
