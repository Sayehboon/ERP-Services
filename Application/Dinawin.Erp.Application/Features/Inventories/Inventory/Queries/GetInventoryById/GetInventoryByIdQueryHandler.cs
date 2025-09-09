using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetInventoryById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت موجودی بر اساس شناسه
/// </summary>
public sealed class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, InventoryDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت موجودی بر اساس شناسه
    /// </summary>
    public GetInventoryByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<InventoryDto?> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var inventory = await _context.Inventory
            .Include(i => i.Product)
            .Include(i => i.Warehouse)
            .Include(i => i.Bin)
            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

        if (inventory == null)
        {
            return null;
        }

        return _mapper.Map<InventoryDto>(inventory);
    }
}
