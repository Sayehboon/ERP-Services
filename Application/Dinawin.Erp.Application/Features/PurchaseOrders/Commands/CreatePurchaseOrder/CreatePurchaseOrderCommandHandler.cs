using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Purchase;

namespace Dinawin.Erp.Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder;

/// <summary>
/// Handler for creating a new purchase order
/// </summary>
public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePurchaseOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        var purchaseOrder = new PurchaseOrder
        {
            Id = Guid.NewGuid(),
            OrderNumber = request.Number,
            VendorId = request.VendorId,
            VendorEmail = request.VendorEmail,
            VendorPhone = request.VendorPhone,
            OrderDate = request.OrderDate,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate,
            TotalAmount = request.TotalAmount,
            Status = request.Status,
            Priority = request.Priority,
            RequestedBy = request.RequestedBy,
            Description = request.Description,
            DeliveryAddress = request.DeliveryAddress,
            PaymentTerms = request.PaymentTerms,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        _context.PurchaseOrders.Add(purchaseOrder);

        // Add order items
        foreach (var itemCommand in request.Items)
        {
            var orderItem = new PurchaseOrderItem
            {
                Id = Guid.NewGuid(),
                PurchaseOrderId = purchaseOrder.Id,
                ProductName = itemCommand.ProductName,
                ProductCode = itemCommand.ProductCode,
                Quantity = itemCommand.Quantity,
                UnitPrice = itemCommand.UnitPrice,
                TotalAmount = itemCommand.TotalAmount,
                Description = itemCommand.Description,
                CreatedBy = request.CreatedBy,
                CreatedAt = DateTime.UtcNow
            };

            _context.PurchaseOrderItems.Add(orderItem);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return purchaseOrder.Id;
    }
}
