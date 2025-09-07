using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.Bins.Commands.UpdateBin;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی مکان
/// </summary>
public sealed class UpdateBinCommandHandler : IRequestHandler<UpdateBinCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی مکان
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateBinCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی مکان
    /// </summary>
    public async Task<Guid> Handle(UpdateBinCommand request, CancellationToken cancellationToken)
    {
        var bin = await _context.Bins.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (bin == null)
        {
            throw new ArgumentException($"مکان با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود انبار
        var warehouseExists = await _context.Warehouses
            .AnyAsync(w => w.Id == request.WarehouseId, cancellationToken);
        if (!warehouseExists)
        {
            throw new ArgumentException($"انبار با شناسه {request.WarehouseId} یافت نشد");
        }

        // بررسی یکتایی نام مکان در همان انبار
        var nameExists = await _context.Bins
            .AnyAsync(b => b.Name == request.Name && b.WarehouseId == request.WarehouseId && b.Id != request.Id, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"مکان با نام {request.Name} در این انبار قبلاً وجود دارد");
        }

        // بررسی یکتایی کد مکان در همان انبار
        var codeExists = await _context.Bins
            .AnyAsync(b => b.Code == request.Code && b.WarehouseId == request.WarehouseId && b.Id != request.Id, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"مکان با کد {request.Code} در این انبار قبلاً وجود دارد");
        }

        bin.Name = request.Name;
        bin.Code = request.Code;
        bin.WarehouseId = request.WarehouseId;
        bin.BinType = request.BinType;
        bin.Capacity = request.Capacity;
        bin.CapacityUnit = request.CapacityUnit;
        bin.Width = request.Width;
        bin.Length = request.Length;
        bin.Height = request.Height;
        bin.Location = request.Location;
        bin.Description = request.Description;
        bin.IsActive = request.IsActive;
        bin.UpdatedBy = request.UpdatedBy;
        bin.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return bin.Id;
    }
}
