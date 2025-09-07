using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.Sales;

namespace Dinawin.Erp.Application.Features.SalesOrders.Commands.CreateSalesOrder;

/// <summary>
/// Handler for creating a new sales order
/// </summary>
public class CreateSalesOrderCommandHandler : IRequestHandler<CreateSalesOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateSalesOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateSalesOrderCommand request, CancellationToken cancellationToken)
    {
        var salesOrder = new SalesOrder
        {
            Id = Guid.NewGuid(),
            Number = request.Number,
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            CustomerPhone = request.CustomerPhone,
            OrderDate = request.OrderDate,
            DeliveryDate = request.DeliveryDate,
            TotalAmount = request.TotalAmount,
            Status = request.Status,
            Priority = request.Priority,
            SalesPerson = request.SalesPerson,
            Description = request.Description,
            DeliveryAddress = request.DeliveryAddress,
            PaymentTerms = request.PaymentTerms,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        _context.SalesOrders.Add(salesOrder);

        // Add order items
        foreach (var itemCommand in request.Items)
        {
            var orderItem = new SalesOrderItem
            {
                Id = Guid.NewGuid(),
                SalesOrderId = salesOrder.Id,
                ProductName = itemCommand.ProductName,
                ProductCode = itemCommand.ProductCode,
                Quantity = itemCommand.Quantity,
                UnitPrice = itemCommand.UnitPrice,
                TotalAmount = itemCommand.TotalAmount,
                Description = itemCommand.Description,
                CreatedBy = request.CreatedBy,
                CreatedAt = DateTime.UtcNow
            };

            _context.SalesOrderItems.Add(orderItem);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return salesOrder.Id;
    }
}
