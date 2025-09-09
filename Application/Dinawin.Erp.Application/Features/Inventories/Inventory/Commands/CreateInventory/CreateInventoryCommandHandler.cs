using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Inventories;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.CreateInventory;

/// <summary>
/// پردازشگر دستور ایجاد موجودی
/// </summary>
public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateInventoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد سطوح موجودی
    /// </summary>
    /// <param name="request">درخواست ایجاد سطوح موجودی</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه سطح موجودی ایجاد شده</returns>
    public async Task<Guid> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود سطح موجودی تکراری برای همان محصول و انبار
        var existingLevel = await _context.InventoryLevels
            .FirstOrDefaultAsync(il => il.ProductId == request.ProductId && 
                                      il.WarehouseId == request.WarehouseId, cancellationToken);

        if (existingLevel != null)
        {
            throw new InvalidOperationException($"سطح موجودی برای این محصول در این انبار قبلاً وجود دارد");
        }

        var inventoryLevel = new InventoryLevel
        {
            ProductId = request.ProductId,
            WarehouseId = request.WarehouseId,
            MinQty = request.MinQty,
            MaxQty = request.MaxQty,
            ReorderPoint = request.ReorderPoint,
            SafetyStock = request.SafetyStock,
            CreatedBy = request.CreatedByUserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.InventoryLevels.Add(inventoryLevel);
        await _context.SaveChangesAsync(cancellationToken);

        return inventoryLevel.Id;
    }
}
