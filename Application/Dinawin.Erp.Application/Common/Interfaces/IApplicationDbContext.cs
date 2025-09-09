using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Domain.Entities.Users;
using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.Entities.Accounting;
using Dinawin.Erp.Domain.Entities.Treasury;
using Dinawin.Erp.Domain.Entities.Systems;
using Dinawin.Erp.Domain.Entities.Crm;
using Dinawin.Erp.Domain.Entities.Sales;
using Dinawin.Erp.Domain.Entities.Purchase;
using TaskEntity = Dinawin.Erp.Domain.Entities.Users.WorkTask;

namespace Dinawin.Erp.Application.Common.Interfaces;

/// <summary>
/// رابط کنتکست دیتابیس اپلیکیشن
/// Application database context interface
/// </summary>
public interface IApplicationDbContext
{
    // Users and Authentication
    DbSet<User> Users { get; }
    DbSet<Company> Companies { get; }
    DbSet<Role> Roles { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<RolePermission> RolePermissions { get; }

    // Product Management
    DbSet<Product> Products { get; }
    DbSet<Category> Categories { get; }
    DbSet<Brand> Brands { get; }
    DbSet<Model> Models { get; }
    DbSet<Trim> Trims { get; }
    DbSet<Year> Years { get; }
    DbSet<UnitOfMeasure> UnitsOfMeasures { get; }
    DbSet<UomConversion> UomConversions { get; }
    DbSet<ProductCategory> ProductCategories { get; }

    // Inventory Management
    DbSet<Inventory> Inventory { get; }
    DbSet<InventoryLevel> InventoryLevels { get; }
    DbSet<InventoryMovement> InventoryMovements { get; }
    DbSet<Warehouse> Warehouses { get; }
    DbSet<Bin> Bins { get; }
    DbSet<InventoryReservation> InventoryReservations { get; }
    DbSet<InventoryBin> InventoryBins { get; }
    DbSet<InventoryBarcode> InventoryBarcodes { get; }
    DbSet<InventoryCostLayer> InventoryCostLayers { get; }
    DbSet<InventoryIssueNote> InventoryIssueNotes { get; }
    DbSet<InventoryIssueLine> InventoryIssueLines { get; }
    DbSet<InventoryTransferNote> InventoryTransferNotes { get; }
    DbSet<InventoryTransferLine> InventoryTransferLines { get; }
    DbSet<GrnReceipt> GrnReceipts { get; }
    DbSet<GrnLine> GrnLines { get; }

    // Pricing/History
    DbSet<PriceHistory> PriceHistories { get; }
    DbSet<PriceChange> PriceChanges { get; }

    // Financial Management
    DbSet<CashBox> CashBoxes { get; }
    DbSet<CashBoxTransaction> CashBoxTransactions { get; }
    DbSet<ChartOfAccount> ChartOfAccounts { get; }
    DbSet<Account> Accounts { get; }
    DbSet<Transaction> Transactions { get; }
    DbSet<JournalVoucher> JournalVouchers { get; }
    DbSet<JournalLine> JournalLines { get; }
    DbSet<Budget> Budgets { get; }
    DbSet<BudgetLine> BudgetLines { get; }
    DbSet<ClosingRun> ClosingRuns { get; }
    DbSet<GeneralLedgerEntry> GeneralLedgerEntries { get; }
    DbSet<PurchaseBill> PurchaseBills { get; }
    DbSet<PurchaseBillLine> PurchaseBillLines { get; }
    DbSet<JournalEntry> JournalEntries { get; }
    DbSet<JournalEntryLine> JournalEntryLines { get; }

    // Treasury
    DbSet<BankAccount> BankAccounts { get; }
    DbSet<CashTransaction> CashTransactions { get; }
    DbSet<SalePayment> SalePayments { get; }
    DbSet<PurchasePayment> PurchasePayments { get; }
    DbSet<CashBoxTransfer> CashBoxTransfers { get; }
    DbSet<BankTransaction> BankTransactions { get; }
    DbSet<BankReconciliation> BankReconciliations { get; }
    DbSet<Instrument> Instruments { get; }
    DbSet<InstrumentFlow> InstrumentFlows { get; }
    DbSet<TreasurySetting> TreasurySettings { get; }

    // GL master data
    DbSet<FiscalYear> FiscalYears { get; }
    DbSet<FiscalPeriod> FiscalPeriods { get; }

    // Sales & Purchase Orders
    DbSet<SalesOrder> SalesOrders { get; }
    DbSet<PurchaseOrder> PurchaseOrders { get; }
    DbSet<SalesReturn> SalesReturns { get; }
    DbSet<SalesReturnLine> SalesReturnLines { get; }
    DbSet<PurchaseReceipt> PurchaseReceipts { get; }
    DbSet<PurchaseReceiptLine> PurchaseReceiptLines { get; }
    DbSet<PurchaseReturn> PurchaseReturns { get; }
    DbSet<PurchaseReturnLine> PurchaseReturnLines { get; }

    // Customer and Vendor Management
    DbSet<Customer> Customers { get; }
    DbSet<Vendor> Vendors { get; }
    DbSet<CustomerOrder> CustomerOrders { get; }
    DbSet<VendorOrder> VendorOrders { get; }
    
    // Accounts Receivable
    DbSet<ArCustomer> ArCustomers { get; }
    DbSet<ArInvoice> ArInvoices { get; }
    DbSet<ArInvoiceLine> ArInvoiceLines { get; }
    DbSet<ArReceipt> ArReceipts { get; }
    DbSet<ArSettlement> ArSettlements { get; }
    
    // Accounts Payable
    DbSet<ApVendor> ApVendors { get; }
    DbSet<ApBill> ApBills { get; }
    DbSet<ApBillLine> ApBillLines { get; }
    DbSet<ApPayment> ApPayments { get; }
    DbSet<ApSettlement> ApSettlements { get; }

    // HR Management
    DbSet<Department> Departments { get; }
    DbSet<Employee> Employees { get; }
    DbSet<EmployeeAttendance> EmployeeAttendance { get; }
    DbSet<EmployeeSalary> EmployeeSalaries { get; }

    // Task Management
    DbSet<TaskEntity> Tasks { get; }
    DbSet<SubTask> SubTasks { get; }
    DbSet<Project> Projects { get; }
    DbSet<TaskComment> TaskComments { get; }
    DbSet<TaskAttachment> TaskAttachments { get; }
    DbSet<TaskActivity> TaskActivities { get; }
    DbSet<TaskProgressUpdate> TaskProgressUpdates { get; }

    // CRM
    DbSet<Activity> Activities { get; }
    DbSet<Contact> Contacts { get; }
    DbSet<Lead> Leads { get; }
    DbSet<Opportunity> Opportunities { get; }
    DbSet<Ticket> Tickets { get; }
    DbSet<ApprovalWorkflow> ApprovalWorkflows { get; }
    DbSet<ApprovalStage> ApprovalStages { get; }
    DbSet<JournalApprovalLog> JournalApprovalLogs { get; }
    DbSet<RateLimit> RateLimits { get; }

    // Dimensions & Posting Rules
    DbSet<AccDimension> AccDimensions { get; }
    DbSet<AccDimensionValue> AccDimensionValues { get; }
    DbSet<AccPostingRule> AccPostingRules { get; }

    // System
    DbSet<SystemSetting> SystemSettings { get; }
    DbSet<ExchangeRate> ExchangeRates { get; }
    DbSet<SecurityAudit> SecurityAudits { get; }
    DbSet<SmsLog> SmsLogs { get; }

    /// <summary>
    /// ذخیره تغییرات
    /// Save changes
    /// </summary>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>تعداد رکوردهای تغییر یافته</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}