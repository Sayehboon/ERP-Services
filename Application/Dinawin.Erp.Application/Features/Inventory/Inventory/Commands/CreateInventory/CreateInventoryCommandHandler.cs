using MediatR;
using Dinawin.Erp.Infrastructure.Data;
using Dinawin.Erp.Infrastructure.Data.Entities.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Inventory.Inventory.Commands.CreateInventory;

/// <summary>
/// پردازشگر دستور ایجاد موجودی
/// </summary>
public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateInventoryCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد موجودی
    /// </summary>
    /// <param name="request">درخواست ایجاد موجودی</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه موجودی ایجاد شده</returns>
    public async Task<Guid> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود موجودی تکراری برای همان محصول و انبار
        var existingInventory = await _context.Inventory
            .FirstOrDefaultAsync(i => i.ProductId == request.ProductId && 
                                     i.WarehouseId == request.WarehouseId && 
                                     i.BinId == request.BinId, cancellationToken);

        if (existingInventory != null)
        {
            throw new InvalidOperationException($"موجودی برای این محصول در این انبار و مکان قبلاً وجود دارد");
        }

        var inventory = new Inventory
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            WarehouseId = request.WarehouseId,
            BinId = request.BinId,
            Quantity = request.Quantity,
            MinimumStock = request.MinimumStock,
            MaximumStock = request.MaximumStock,
            AveragePrice = request.AveragePrice,
            LastInDate = request.LastInDate,
            LastOutDate = request.LastOutDate,
            IsActive = request.IsActive,
            Notes = request.Notes,
            CreatedByUserId = request.CreatedByUserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Inventory.Add(inventory);
        await _context.SaveChangesAsync(cancellationToken);

        return inventory.Id;
    }
}
