using MediatR;

namespace Dinawin.Erp.Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder;

/// <summary>
/// Command for creating a new purchase order
/// </summary>
public class CreatePurchaseOrderCommand : IRequest<Guid>
{
    public string Number { get; set; } = string.Empty;
    public Guid VendorId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExpectedDeliveryDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "در انتظار تایید";
    public string Priority { get; set; } = "عادی";
    public string? RequestedBy { get; set; }
    public string? Description { get; set; }
    public string? DeliveryAddress { get; set; }
    public string? PaymentTerms { get; set; }
    public List<CreatePurchaseOrderItemCommand> Items { get; set; } = new List<CreatePurchaseOrderItemCommand>();
    public Guid? CreatedBy { get; set; }
}

/// <summary>
/// Command for creating a purchase order item
/// </summary>
public class CreatePurchaseOrderItemCommand
{
    public string ProductName { get; set; } = string.Empty;
    public string? ProductCode { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Description { get; set; }
}
