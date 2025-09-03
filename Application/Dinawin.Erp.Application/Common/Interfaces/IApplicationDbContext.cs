using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.Entities.Accounting;
using Dinawin.Erp.Domain.Entities.Treasury;
using Dinawin.Erp.Domain.Entities.Systems;

namespace Dinawin.Erp.Application.Common.Interfaces;

/// <summary>
/// واسط دیتابیس برنامه
/// Application database context interface
/// </summary>
public interface IApplicationDbContext
{
    // Product entities
    
    DbSet<UomConversion> UomConversions { get; }
    DbSet<Product> Products { get; }
    DbSet<Brand> Brands { get; }
    DbSet<Category> Categories { get; }
    DbSet<UnitOfMeasure> UnitsOfMeasure { get; }

    // Inventory entities
    DbSet<Inventory> Inventories { get; }
    DbSet<Warehouse> Warehouses { get; }
    DbSet<InventoryMovement> InventoryMovements { get; }
    DbSet<Bin> Bins { get; }

    // User entities
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<RolePermission> RolePermissions { get; }
    DbSet<UserPermission> UserPermissions { get; }
    DbSet<Company> Companies { get; }
    DbSet<Department> Departments { get; }
    DbSet<UserSettings> UserSettings { get; }
    DbSet<UserProfile> UserProfiles { get; }

    // Accounting entities
    DbSet<Customer> Customers { get; }
    DbSet<Account> Accounts { get; }
    DbSet<SalesInvoice> SalesInvoices { get; }
    DbSet<SalesInvoiceLine> SalesInvoiceLines { get; }

    // AP entities
    DbSet<Vendor> Vendors { get; }
    DbSet<PurchaseBill> PurchaseBills { get; }
    DbSet<PurchaseBillLine> PurchaseBillLines { get; }

    // GL entities
    DbSet<FiscalYear> FiscalYears { get; }
    DbSet<FiscalPeriod> FiscalPeriods { get; }
    DbSet<JournalVoucher> JournalVouchers { get; }
    DbSet<JournalLine> JournalLines { get; }

    // Treasury entities
    DbSet<CashBox> CashBoxes { get; }
    DbSet<CashTransaction> CashTransactions { get; }
    DbSet<BankAccount> BankAccounts { get; }

    // System entities
    DbSet<SystemSetting> SystemSettings { get; }

    /// <summary>
    /// ذخیره تغییرات
    /// Save changes
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
