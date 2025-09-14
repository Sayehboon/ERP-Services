using MediatR;

namespace Dinawin.Erp.Application.Features.SalesOrders.Commands.CreateSalesOrder;

/// <summary>
/// Command for creating a new sales order
/// </summary>
public class CreateSalesOrderCommand : IRequest<Guid>
{
    public string Number { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeliveryDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "تایید شده";
    public string Priority { get; set; } = "عادی";
    public string SalesPerson { get; set; }
    public string Description { get; set; }
    public string DeliveryAddress { get; set; }
    public string PaymentTerms { get; set; }
    public List<CreateSalesOrderItemCommand> Items { get; set; } = new List<CreateSalesOrderItemCommand>();
    public Guid? CreatedBy { get; set; }
}

/// <summary>
/// Command for creating a sales order item
/// </summary>
public class CreateSalesOrderItemCommand
{
    public string ProductName { get; set; } = string.Empty;
    public string ProductCode { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public string Description { get; set; }
}
