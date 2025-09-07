using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.Warehouses.Commands.UpdateWarehouse;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی انبار
/// </summary>
public sealed class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی انبار
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateWarehouseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی انبار
    /// </summary>
    public async Task<Guid> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);
        if (warehouse == null)
        {
            throw new ArgumentException($"انبار با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی نام انبار
        var nameExists = await _context.Warehouses
            .AnyAsync(w => w.Name == request.Name && w.Id != request.Id, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"انبار با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی یکتایی کد انبار
        var codeExists = await _context.Warehouses
            .AnyAsync(w => w.Code == request.Code && w.Id != request.Id, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"انبار با کد {request.Code} قبلاً وجود دارد");
        }

        warehouse.Name = request.Name;
        warehouse.Code = request.Code;
        warehouse.Address = request.Address;
        warehouse.PhoneNumber = request.PhoneNumber;
        warehouse.Email = request.Email;
        warehouse.ManagerName = request.ManagerName;
        warehouse.Capacity = request.Capacity;
        warehouse.CapacityUnit = request.CapacityUnit;
        warehouse.WarehouseType = request.WarehouseType;
        warehouse.Description = request.Description;
        warehouse.IsActive = request.IsActive;
        warehouse.UpdatedBy = request.UpdatedBy;
        warehouse.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return warehouse.Id;
    }
}
