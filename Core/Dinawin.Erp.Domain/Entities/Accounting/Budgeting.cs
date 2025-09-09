using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

public class Budget : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Currency { get; set; } = "IRR";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = "draft";
    public ICollection<BudgetLine> Lines { get; set; } = new List<BudgetLine>();
}

public class BudgetLine : BaseEntity
{
    public Guid BudgetId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public string? Notes { get; set; }

    public Budget Budget { get; set; } = null!;
}

public class ClosingRun : BaseEntity, IAggregateRoot
{
    public Guid FiscalYearId { get; set; }
    public DateTime RunDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "completed";
}


