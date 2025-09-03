namespace Dinawin.Erp.Application.Features.Accounting.Bills.Queries.Dtos;

public class PurchaseBillDto
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public DateTime BillDate { get; set; }
    public Guid VendorId { get; set; }
    public string VendorName { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string Status { get; set; } = string.Empty;
}


