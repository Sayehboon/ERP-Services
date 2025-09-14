namespace Dinawin.Erp.Application.Features.SalesOrders.DTOs;

/// <summary>
/// DTO for SalesOrder entity
/// </summary>
public class SalesOrderDto
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string SalesPerson { get; set; }
    public string Description { get; set; }
    public string DeliveryAddress { get; set; }
    public string PaymentTerms { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public List<SalesOrderItemDto> Items { get; set; } = new List<SalesOrderItemDto>();
}

/// <summary>
/// DTO for SalesOrderItem entity
/// </summary>
public class SalesOrderItemDto
{
    public Guid Id { get; set; }
    public Guid SalesOrderId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductCode { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}
