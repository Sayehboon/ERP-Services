using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetBinById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت مکان بر اساس شناسه
/// </summary>
public sealed class GetBinByIdQueryHandler : IRequestHandler<GetBinByIdQuery, BinDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت مکان بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetBinByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت مکان بر اساس شناسه
    /// </summary>
    public async Task<BinDto?> Handle(GetBinByIdQuery request, CancellationToken cancellationToken)
    {
        var bin = await _context.Bins
            .Include(b => b.Warehouse)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (bin == null)
        {
            return null;
        }

        return new BinDto
        {
            Id = bin.Id,
            Name = bin.Name,
            Code = bin.Code,
            WarehouseId = bin.WarehouseId,
            WarehouseName = bin.Warehouse.Name,
            BinType = bin.BinType,
            Capacity = bin.Capacity,
            CapacityUnit = bin.CapacityUnit,
            Width = bin.Width,
            Length = bin.Length,
            Height = bin.Height,
            Location = bin.Location,
            Description = bin.Description,
            IsActive = bin.IsActive,
            CreatedAt = bin.CreatedAt,
            UpdatedAt = bin.UpdatedAt,
            CreatedBy = bin.CreatedBy,
            UpdatedBy = bin.UpdatedBy
        };
    }
}
