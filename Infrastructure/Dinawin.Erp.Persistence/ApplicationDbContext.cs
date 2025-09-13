using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using TaskEntity = Dinawin.Erp.Domain.Entities.Users.WorkTask;
using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.Entities.Users;
using Dinawin.Erp.Domain.Common;
using System.Reflection;
using System.Linq.Expressions;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.Entities.Accounting;
using Dinawin.Erp.Domain.Entities.Treasury;
using Dinawin.Erp.Domain.Entities.Systems;
using Dinawin.Erp.Domain.Entities.Crm;
using Dinawin.Erp.Domain.Entities.Sales;
using Dinawin.Erp.Domain.Entities.Purchase;
using Dinawin.Erp.Domain.Entities.AfterSales;
using Dinawin.Erp.Domain.Entities.Maintenance;
using Dinawin.Erp.Domain.Entities.FixedAssets;
using Dinawin.Erp.Domain.Entities.Budget;

namespace Dinawin.Erp.Persistence;

/// <summary>
/// کنتکست دیتابیس برنامه
/// Application database context
/// </summary>
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    /// <summary>
    /// سازنده کنتکست دیتابیس
    /// Database context constructor
    /// </summary>
    /// <param name="options">گزینه‌های دیتابیس</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Product entities
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<UnitOfMeasure> UnitsOfMeasures => Set<UnitOfMeasure>();
    public DbSet<UnitOfMeasure> Units => Set<UnitOfMeasure>();
    public DbSet<Model> Models => Set<Model>();
    public DbSet<Trim> Trims => Set<Trim>();
    public DbSet<Year> Years => Set<Year>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductFile> ProductFiles => Set<ProductFile>();
    public DbSet<VehicleCompatibility> VehicleCompatibilities => Set<VehicleCompatibility>();

    // Inventory entities
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<InventoryMovement> InventoryMovements => Set<InventoryMovement>();
    public DbSet<Bin> Bins => Set<Bin>();
    public DbSet<InventoryReservation> InventoryReservations => Set<InventoryReservation>();
    public DbSet<InventoryIssueNote> InventoryIssueNotes => Set<InventoryIssueNote>();
    public DbSet<InventoryIssueLine> InventoryIssueLines => Set<InventoryIssueLine>();
    public DbSet<InventoryTransferNote> InventoryTransferNotes => Set<InventoryTransferNote>();
    public DbSet<InventoryTransferLine> InventoryTransferLines => Set<InventoryTransferLine>();
    public DbSet<GrnReceipt> GrnReceipts => Set<GrnReceipt>();
    public DbSet<GrnLine> GrnLines => Set<GrnLine>();
    public DbSet<InventoryLevel> InventoryLevels => Set<InventoryLevel>();
    public DbSet<InventoryBin> InventoryBins => Set<InventoryBin>();
    public DbSet<InventoryBarcode> InventoryBarcodes => Set<InventoryBarcode>();
    public DbSet<InventoryCostLayer> InventoryCostLayers => Set<InventoryCostLayer>();
    public DbSet<PriceHistory> PriceHistories => Set<PriceHistory>();
    public DbSet<PriceChange> PriceChanges => Set<PriceChange>();
    

    // User entities
    public DbSet<User> Users => Set<User>();
    public DbSet<Business> Businesses => Set<Business>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<UserActivityLog> UserActivityLogs => Set<UserActivityLog>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeAttendance> EmployeeAttendances => Set<EmployeeAttendance>();
    public DbSet<EmployeeSalary> EmployeeSalaries => Set<EmployeeSalary>();
    public DbSet<EmployeeSalary> EmployeeSalaryDetails => Set<EmployeeSalary>();
    public DbSet<Leave> Leaves => Set<Leave>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<SubTask> SubTasks => Set<SubTask>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskComment> TaskComments => Set<TaskComment>();
    public DbSet<TaskAttachment> TaskAttachments => Set<TaskAttachment>();
    public DbSet<TaskActivity> TaskActivities => Set<TaskActivity>();
    public DbSet<TaskProgressUpdate> TaskProgressUpdates => Set<TaskProgressUpdate>();
    public DbSet<UserPermission> UserPermissions => Set<UserPermission>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    // Accounting entities
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<SalesInvoice> SalesInvoices => Set<SalesInvoice>();
    public DbSet<SalesInvoiceLine> SalesInvoiceLines => Set<SalesInvoiceLine>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<PurchaseBill> PurchaseBills => Set<PurchaseBill>();
    public DbSet<PurchaseBillLine> PurchaseBillLines => Set<PurchaseBillLine>();

    // GL entities
    public DbSet<FiscalYear> FiscalYears => Set<FiscalYear>();
    public DbSet<FiscalPeriod> FiscalPeriods => Set<FiscalPeriod>();
    public DbSet<JournalVoucher> JournalVouchers => Set<JournalVoucher>();
    public DbSet<JournalLine> JournalLines => Set<JournalLine>();
    public DbSet<Budget> Budgets => Set<Budget>();
    public DbSet<BudgetLine> BudgetLines => Set<BudgetLine>();
    public DbSet<ClosingRun> ClosingRuns => Set<ClosingRun>();
    public DbSet<AccFiscalYear> AccFiscalYears => Set<AccFiscalYear>();
    public DbSet<AccFiscalPeriod> AccFiscalPeriods => Set<AccFiscalPeriod>();
    public DbSet<AccJournalVoucher> AccJournalVouchers => Set<AccJournalVoucher>();
    public DbSet<AccJournalLine> AccJournalLines => Set<AccJournalLine>();
    public DbSet<AccJournalApprovalLog> AccJournalApprovalLogs => Set<AccJournalApprovalLog>();
    public DbSet<AccOpeningBalance> AccOpeningBalances => Set<AccOpeningBalance>();

    // Treasury entities
    public DbSet<CashBox> CashBoxes => Set<CashBox>();
    public DbSet<CashTransaction> CashTransactions => Set<CashTransaction>();
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
    public DbSet<SalePayment> SalePayments => Set<SalePayment>();
    public DbSet<PurchasePayment> PurchasePayments => Set<PurchasePayment>();
    public DbSet<CashBoxTransfer> CashBoxTransfers => Set<CashBoxTransfer>();
    public DbSet<BankTransaction> BankTransactions => Set<BankTransaction>();
    public DbSet<BankReconciliation> BankReconciliations => Set<BankReconciliation>();
    public DbSet<Instrument> Instruments => Set<Instrument>();
    public DbSet<InstrumentFlow> InstrumentFlows => Set<InstrumentFlow>();
    public DbSet<TreasurySetting> TreasurySettings => Set<TreasurySetting>();
    public DbSet<AccSetting> AccSettings => Set<AccSetting>();

    // System entities
    public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();
    public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();
    public DbSet<SecurityAudit> SecurityAudits => Set<SecurityAudit>();
    public DbSet<SmsLog> SmsLogs => Set<SmsLog>();
    public DbSet<Dinawin.Erp.Domain.Entities.Systems.Console> Consoles => Set<Dinawin.Erp.Domain.Entities.Systems.Console>();
    public DbSet<Operation> Operations => Set<Operation>();
    public DbSet<RoleOperation> RoleOperations => Set<RoleOperation>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<OrgUnit> OrgUnits => Set<OrgUnit>();
    public DbSet<UserOrgUnit> UserOrgUnits => Set<UserOrgUnit>();
    public DbSet<SessionAudit> SessionAudits => Set<SessionAudit>();
    public DbSet<PasswordPolicy> PasswordPolicies => Set<PasswordPolicy>();
    public DbSet<LoginPolicy> LoginPolicies => Set<LoginPolicy>();
    public DbSet<CustomerSurvey> CustomerSurveys => Set<CustomerSurvey>();
    public DbSet<RepairService> RepairServices => Set<RepairService>();
    public DbSet<RepairPart> RepairParts => Set<RepairPart>();
    public DbSet<Warranty> Warranties => Set<Warranty>();
    public DbSet<WarrantyClaim> WarrantyClaims => Set<WarrantyClaim>();
    public DbSet<Technician> Technicians => Set<Technician>();
    public DbSet<MaintenanceEquipment> MaintenanceEquipment => Set<MaintenanceEquipment>();
    public DbSet<MaintenanceRequest> MaintenanceRequests => Set<MaintenanceRequest>();
    public DbSet<MaintenanceSchedule> MaintenanceSchedules => Set<MaintenanceSchedule>();
    public DbSet<MaintenanceWorkOrder> MaintenanceWorkOrders => Set<MaintenanceWorkOrder>();
    public DbSet<FaCategory> FaCategories => Set<FaCategory>();
    public DbSet<FaAsset> FaAssets => Set<FaAsset>();
    public DbSet<FaDepreciationRun> FaDepreciationRuns => Set<FaDepreciationRun>();
    public DbSet<FaDepreciationEntry> FaDepreciationEntries => Set<FaDepreciationEntry>();

    public DbSet<UomConversion> UomConversions => Set<UomConversion>();

    // CRM entities
    public DbSet<Activity> Activities => Set<Activity>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<Opportunity> Opportunities => Set<Opportunity>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<TicketResponse> TicketResponses => Set<TicketResponse>();
    public DbSet<TicketCategory> TicketCategories => Set<TicketCategory>();
    public DbSet<EmailCampaign> EmailCampaigns => Set<EmailCampaign>();
    public DbSet<EmailResponse> EmailResponses => Set<EmailResponse>();
    public DbSet<Survey> Surveys => Set<Survey>();
    public DbSet<SurveyQuestion> SurveyQuestions => Set<SurveyQuestion>();
    public DbSet<SurveyResponse> SurveyResponses => Set<SurveyResponse>();
    public DbSet<SurveyQuestionResponse> SurveyQuestionResponses => Set<SurveyQuestionResponse>();
    public DbSet<ApprovalWorkflow> ApprovalWorkflows => Set<ApprovalWorkflow>();
    public DbSet<ApprovalStage> ApprovalStages => Set<ApprovalStage>();
    public DbSet<JournalApprovalLog> JournalApprovalLogs => Set<JournalApprovalLog>();
    public DbSet<RateLimit> RateLimits => Set<RateLimit>();

    // Sales entities
    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
    public DbSet<SalesOrderItem> SalesOrderItems => Set<SalesOrderItem>();
    public DbSet<SalesReturn> SalesReturns => Set<SalesReturn>();
    public DbSet<SalesReturnLine> SalesReturnLines => Set<SalesReturnLine>();

    // Purchase entities
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderItem> PurchaseOrderItems => Set<PurchaseOrderItem>();
    public DbSet<PurchaseReceipt> PurchaseReceipts => Set<PurchaseReceipt>();
    public DbSet<PurchaseReceiptLine> PurchaseReceiptLines => Set<PurchaseReceiptLine>();
    public DbSet<PurchaseReturn> PurchaseReturns => Set<PurchaseReturn>();
    public DbSet<PurchaseReturnLine> PurchaseReturnLines => Set<PurchaseReturnLine>();
    public DbSet<PoOrder> PoOrders => Set<PoOrder>();
    public DbSet<PoOrderLine> PoOrderLines => Set<PoOrderLine>();
    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
    public DbSet<JournalEntryLine> JournalEntryLines => Set<JournalEntryLine>();

    // Additional entities for IApplicationDbContext compatibility
    public DbSet<CashBoxTransaction> CashBoxTransactions => Set<CashBoxTransaction>();
    public DbSet<ChartOfAccount> ChartOfAccounts => Set<ChartOfAccount>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<CustomerOrder> CustomerOrders => Set<CustomerOrder>();
    public DbSet<VendorOrder> VendorOrders => Set<VendorOrder>();
    public DbSet<GeneralLedgerEntry> GeneralLedgerEntries => Set<GeneralLedgerEntry>();
    public DbSet<EmployeeAttendance> EmployeeAttendance => Set<EmployeeAttendance>();
    
    // Inventory entities
    public DbSet<AccDimension> AccDimensions => Set<AccDimension>();
    public DbSet<AccDimensionValue> AccDimensionValues => Set<AccDimensionValue>();
    public DbSet<AccPostingRule> AccPostingRules => Set<AccPostingRule>();
    
    // AR/AP entities
    public DbSet<ArCustomer> ArCustomers => Set<ArCustomer>();
    public DbSet<ArInvoice> ArInvoices => Set<ArInvoice>();
    public DbSet<ArInvoiceLine> ArInvoiceLines => Set<ArInvoiceLine>();
    public DbSet<ArReceipt> ArReceipts => Set<ArReceipt>();
    public DbSet<ArSettlement> ArSettlements => Set<ArSettlement>();
    public DbSet<ApVendor> ApVendors => Set<ApVendor>();
    public DbSet<ApBill> ApBills => Set<ApBill>();
    public DbSet<ApBillLine> ApBillLines => Set<ApBillLine>();
    public DbSet<ApPayment> ApPayments => Set<ApPayment>();
    public DbSet<ApSettlement> ApSettlements => Set<ApSettlement>();

    /// <summary>
    /// پیکربندی مدل دیتابیس
    /// Configure database model
    /// </summary>
    /// <param name="builder">سازنده مدل</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // اعمال تمام پیکربندی‌ها از assembly فعلی
        // Apply all configurations from current assembly
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // پیکربندی حذف نرم برای تمام موجودیت‌ها
        // Configure soft delete for all entities
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var propertyMethodInfo = typeof(EF).GetMethod(nameof(EF.Property))!.MakeGenericMethod(typeof(bool));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(nameof(BaseEntity.IsDeleted)));
                var notDeleted = Expression.Not(isDeletedProperty);
                var lambda = Expression.Lambda(notDeleted, parameter);
                
                builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }

    /// <summary>
    /// ذخیره تغییرات با بروزرسانی خودکار timestamps
    /// Save changes with automatic timestamp updates
    /// </summary>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>تعداد تغییرات ذخیره شده</returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}
