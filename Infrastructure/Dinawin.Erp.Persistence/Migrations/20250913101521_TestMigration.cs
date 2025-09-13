using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dinawin.Erp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Accounts_ControlAccountId",
                schema: "Treasury",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bins_Warehouses_WarehouseId",
                schema: "Inventory",
                table: "Bins");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ManagerId",
                schema: "Identity",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Bins_BinId",
                schema: "Inventory",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductId",
                schema: "Inventory",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId",
                schema: "Inventory",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Inventories_InventoryId",
                schema: "Inventory",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Products_ProductId",
                schema: "Inventory",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Warehouses_WarehouseId",
                schema: "Inventory",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitsOfMeasure_BaseUomId",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitsOfMeasure_UnitsOfMeasure_BaseUnitId",
                schema: "Product",
                table: "UnitsOfMeasure");

            migrationBuilder.DropForeignKey(
                name: "FK_UomConversions_UnitsOfMeasure_FromUomId",
                schema: "Product",
                table: "UomConversions");

            migrationBuilder.DropForeignKey(
                name: "FK_UomConversions_UnitsOfMeasure_ToUomId",
                schema: "Product",
                table: "UomConversions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_Business_Code",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_BusinessId",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_Name",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_Code",
                schema: "AP",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SystemSettings_Business_Category_Key",
                schema: "System",
                table: "SystemSettings");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_Customer_Date",
                schema: "AR",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBills_Vendor_Date",
                schema: "AP",
                table: "PurchaseBills");

            migrationBuilder.DropIndex(
                name: "IX_JournalVouchers_Year_Date",
                schema: "GL",
                table: "JournalVouchers");

            migrationBuilder.DropIndex(
                name: "IX_InventoryMovements_Product_Warehouse_Date",
                schema: "Inventory",
                table: "InventoryMovements");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ProductId",
                schema: "Inventory",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_FiscalYears_Code",
                schema: "GL",
                table: "FiscalYears");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Company_Level_Sort",
                schema: "Identity",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CompanyId_Code",
                schema: "Identity",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CompanyId_Name",
                schema: "Identity",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Code",
                schema: "AR",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Companies_EconomicCode",
                schema: "Identity",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_NationalId",
                schema: "Identity",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RegistrationNumber",
                schema: "Identity",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Level_SortOrder",
                schema: "Product",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Path",
                schema: "Product",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CashBoxes_Business_Name",
                schema: "Treasury",
                table: "CashBoxes");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Name",
                schema: "Product",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_SortOrder",
                schema: "Product",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_Business_Name",
                schema: "Treasury",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Business_Code",
                schema: "GL",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_BusinessId",
                schema: "GL",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfMeasure",
                schema: "Product",
                table: "UnitsOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_UnitsOfMeasure_Code",
                schema: "Product",
                table: "UnitsOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_UnitsOfMeasure_Symbol",
                schema: "Product",
                table: "UnitsOfMeasure");

            migrationBuilder.DropColumn(
                name: "AddressCity",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "AddressCountry",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "AddressState",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                schema: "Inventory",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "PhoneCountryCode",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneLocalNumber",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Factor",
                schema: "Product",
                table: "UomConversions");

            migrationBuilder.DropColumn(
                name: "TotalValueCurrency",
                schema: "Inventory",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "UnitCostCurrency",
                schema: "Inventory",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "AverageCostCurrency",
                schema: "Inventory",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "LastPurchaseCost",
                schema: "Inventory",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "LastPurchaseCostCurrency",
                schema: "Inventory",
                table: "Inventories");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                schema: "Inventory",
                newName: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Vendors",
                schema: "AP",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Identity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                schema: "Users",
                newName: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "UomConversions",
                schema: "Product",
                newName: "UomConversions");

            migrationBuilder.RenameTable(
                name: "SystemSettings",
                schema: "System",
                newName: "SystemSettings");

            migrationBuilder.RenameTable(
                name: "SalesInvoices",
                schema: "AR",
                newName: "SalesInvoices");

            migrationBuilder.RenameTable(
                name: "SalesInvoiceLines",
                schema: "AR",
                newName: "SalesInvoiceLines");

            migrationBuilder.RenameTable(
                name: "PurchaseBills",
                schema: "AP",
                newName: "PurchaseBills");

            migrationBuilder.RenameTable(
                name: "PurchaseBillLines",
                schema: "AP",
                newName: "PurchaseBillLines");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "JournalVouchers",
                schema: "GL",
                newName: "JournalVouchers");

            migrationBuilder.RenameTable(
                name: "JournalLines",
                schema: "GL",
                newName: "JournalLines");

            migrationBuilder.RenameTable(
                name: "InventoryMovements",
                schema: "Inventory",
                newName: "InventoryMovements");

            migrationBuilder.RenameTable(
                name: "Inventories",
                schema: "Inventory",
                newName: "Inventories");

            migrationBuilder.RenameTable(
                name: "FiscalYears",
                schema: "GL",
                newName: "FiscalYears");

            migrationBuilder.RenameTable(
                name: "FiscalPeriods",
                schema: "GL",
                newName: "FiscalPeriods");

            migrationBuilder.RenameTable(
                name: "Departments",
                schema: "Identity",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "AR",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "Identity",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "Product",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "CashTransactions",
                schema: "Treasury",
                newName: "CashTransactions");

            migrationBuilder.RenameTable(
                name: "CashBoxes",
                schema: "Treasury",
                newName: "CashBoxes");

            migrationBuilder.RenameTable(
                name: "Brands",
                schema: "Product",
                newName: "Brands");

            migrationBuilder.RenameTable(
                name: "Bins",
                schema: "Inventory",
                newName: "Bins");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                schema: "Treasury",
                newName: "BankAccounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                schema: "GL",
                newName: "Accounts");

            migrationBuilder.RenameTable(
                name: "UnitsOfMeasure",
                schema: "Product",
                newName: "UnitOfMeasure");

            migrationBuilder.RenameColumn(
                name: "AddressStreet",
                table: "Warehouses",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "AddressPostalCode",
                table: "Warehouses",
                newName: "CapacityUnit");

            migrationBuilder.RenameColumn(
                name: "ToUomId",
                table: "UomConversions",
                newName: "ToUnitId");

            migrationBuilder.RenameColumn(
                name: "FromUomId",
                table: "UomConversions",
                newName: "FromUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_UomConversions_ToUomId",
                table: "UomConversions",
                newName: "IX_UomConversions_ToUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_UomConversions_From_To",
                table: "UomConversions",
                newName: "IX_UomConversions_FromUnitId_ToUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesInvoiceLines_InvoiceId",
                table: "SalesInvoiceLines",
                newName: "IX_SalesInvoiceLines_SalesInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseBillLines_BillId",
                table: "PurchaseBillLines",
                newName: "IX_PurchaseBillLines_PurchaseBillId");

            migrationBuilder.RenameColumn(
                name: "WeightValue",
                table: "Products",
                newName: "Weight_Value");

            migrationBuilder.RenameColumn(
                name: "WeightUnit",
                table: "Products",
                newName: "Weight_Unit");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "Products",
                newName: "SellingPrice_Amount");

            migrationBuilder.RenameColumn(
                name: "SellingCurrency",
                table: "Products",
                newName: "SellingPrice_Currency");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Products",
                newName: "PurchasePrice_Amount");

            migrationBuilder.RenameColumn(
                name: "PurchaseCurrency",
                table: "Products",
                newName: "PurchasePrice_Currency");

            migrationBuilder.RenameColumn(
                name: "DimensionWidth",
                table: "Products",
                newName: "Dimensions_Width");

            migrationBuilder.RenameColumn(
                name: "DimensionUnit",
                table: "Products",
                newName: "Dimensions_Unit");

            migrationBuilder.RenameColumn(
                name: "DimensionLength",
                table: "Products",
                newName: "Dimensions_Length");

            migrationBuilder.RenameColumn(
                name: "DimensionHeight",
                table: "Products",
                newName: "Dimensions_Height");

            migrationBuilder.RenameColumn(
                name: "LastMovementDate",
                table: "Inventories",
                newName: "ExpiryDate");

            migrationBuilder.RenameIndex(
                name: "IX_FiscalPeriods_Year_Period",
                table: "FiscalPeriods",
                newName: "IX_FiscalPeriods_FiscalYearId_PeriodNo");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Companies",
                newName: "PhoneNumber_Value");

            migrationBuilder.RenameColumn(
                name: "PhoneLocalNumber",
                table: "Companies",
                newName: "PhoneNumber_LocalNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneCountryCode",
                table: "Companies",
                newName: "PhoneNumber_CountryCode");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Companies",
                newName: "Email_Value");

            migrationBuilder.RenameColumn(
                name: "AddressStreet",
                table: "Companies",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "AddressState",
                table: "Companies",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "AddressPostalCode",
                table: "Companies",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "AddressCountry",
                table: "Companies",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "AddressCity",
                table: "Companies",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "CashTransactions",
                newName: "Amount_Currency");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "CashTransactions",
                newName: "Amount_Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Bins_Warehouse_Code",
                table: "Bins",
                newName: "IX_Bins_WarehouseId_Code");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BankAccounts",
                newName: "AccountName");

            migrationBuilder.RenameIndex(
                name: "IX_UnitsOfMeasure_Type",
                table: "UnitOfMeasure",
                newName: "IX_UnitOfMeasure_Type");

            migrationBuilder.RenameIndex(
                name: "IX_UnitsOfMeasure_Name",
                table: "UnitOfMeasure",
                newName: "IX_UnitOfMeasure_Name");

            migrationBuilder.RenameIndex(
                name: "IX_UnitsOfMeasure_BaseUnitId",
                table: "UnitOfMeasure",
                newName: "IX_UnitOfMeasure_BaseUnitId");

            migrationBuilder.AlterColumn<string>(
                name: "Timezone",
                table: "UserSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TimeFormat",
                table: "UserSettings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Theme",
                table: "UserSettings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "UserSettings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DefaultCurrency",
                table: "UserSettings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DateFormat",
                table: "UserSettings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalSettings",
                table: "UserSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserSettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "UserRoles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Roles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Roles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentRoleId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "RolePermissions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "RolePermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resource",
                table: "Permissions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Permissions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Warehouses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Warehouses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Warehouses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Warehouses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "default");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Warehouses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Warehouses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseType",
                table: "Warehouses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Vendors",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AccountBalance",
                table: "Vendors",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Vendors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Vendors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Vendors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Vendors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CreditLimit",
                table: "Vendors",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vendors",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountRate",
                table: "Vendors",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EconomicCode",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Vendors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Vendors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Vendors",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Vendors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Vendors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredCurrency",
                table: "Vendors",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VendorType",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Vendors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId1",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalPhone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserProfiles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserProfiles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserProfiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "UserProfiles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "UserProfiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "UserProfiles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "UserProfiles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredLanguage",
                table: "UserProfiles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "UserProfiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "UserProfiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ConversionFactor",
                table: "UomConversions",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UomConversions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UomConversions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UomConversions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "SystemSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "SystemSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "SystemSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                table: "SystemSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "default");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEditable",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "SalesInvoices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "draft");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "SalesInvoices",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                table: "SalesInvoices",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "SalesOrderId",
                table: "SalesInvoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "SalesInvoiceLines",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SalesInvoiceLines",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PurchaseBills",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "draft");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "PurchaseBills",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "PurchaseBills",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BillDate",
                table: "PurchaseBills",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "VendorId1",
                table: "PurchaseBills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "PurchaseBillLines",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PurchaseBillLines",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellingPrice_Currency",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true,
                oldDefaultValue: "IRR");

            migrationBuilder.AlterColumn<string>(
                name: "PurchasePrice_Currency",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true,
                oldDefaultValue: "IRR");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentStock",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DefaultUnit",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsManufacturable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchasable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSellable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxStock",
                table: "Products",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinStock",
                table: "Products",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId1",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TrimId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TrimId1",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitOfMeasureId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UomId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WholesalePrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "YearId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VoucherDate",
                table: "JournalVouchers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "JournalVouchers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "JV");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "JournalVouchers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "draft");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "JournalVouchers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JournalVouchers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalStatus",
                table: "JournalVouchers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JournalLines",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "InventoryMovements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceType",
                table: "InventoryMovements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "InventoryMovements",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "InventoryId",
                table: "InventoryMovements",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceBefore",
                table: "InventoryMovements",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceAfter",
                table: "InventoryMovements",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceAverageCost",
                table: "InventoryMovements",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceQuantity",
                table: "InventoryMovements",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "BinId",
                table: "InventoryMovements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InventoryMovements",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "InventoryMovements",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MovementType",
                table: "InventoryMovements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "InventoryMovements",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "InventoryMovements",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "InventoryMovements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "InventoryMovements",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                table: "Inventories",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AvailableQuantity",
                table: "Inventories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "BinId1",
                table: "Inventories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Inventories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxQuantity",
                table: "Inventories",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinQuantity",
                table: "Inventories",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityAvailable",
                table: "Inventories",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityOnHand",
                table: "Inventories",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityReserved",
                table: "Inventories",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReorderLevel",
                table: "Inventories",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Inventories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                table: "Inventories",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Inventories",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearStart",
                table: "FiscalYears",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearEnd",
                table: "FiscalYears",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "FiscalYears",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FiscalYears",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FiscalPeriods",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "open");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "FiscalPeriods",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "FiscalPeriods",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Departments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentType",
                table: "Departments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Departments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HierarchyPath",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Departments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AccountBalance",
                table: "Customers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CreditLimit",
                table: "Customers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerType",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Customers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountRate",
                table: "Customers",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EconomicCode",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Customers",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredCurrency",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Companies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Longitude",
                table: "Companies",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Latitude",
                table: "Companies",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber_LocalNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber_CountryCode",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email_Value",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Street",
                table: "Companies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Categories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "CashTransactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "CashTransactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPosted",
                table: "CashTransactions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CashTransactions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amount_Currency",
                table: "CashTransactions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountId",
                table: "CashTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReferenceId",
                table: "CashTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceType",
                table: "CashTransactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "CashTransactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CashBoxes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CashBoxes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BusinessId",
                table: "CashBoxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "default");

            migrationBuilder.AddColumn<Guid>(
                name: "ControlAccountId",
                table: "CashBoxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Brands",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "Brands",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "Brands",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Brands",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Brands",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bins",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Bins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bins",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BinType",
                table: "Bins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Capacity",
                table: "Bins",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapacityUnit",
                table: "Bins",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Bins",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "Bins",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Bins",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                table: "Bins",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BankAccounts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "BankAccounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                table: "BankAccounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "default");

            migrationBuilder.AddColumn<string>(
                name: "AccountHolderName",
                table: "BankAccounts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "BankAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "BankAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankCode",
                table: "BankAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "BankAccounts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchAddress",
                table: "BankAccounts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "BankAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "BankAccounts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchPhone",
                table: "BankAccounts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "BankAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance",
                table: "BankAccounts",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BankAccounts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialBalance",
                table: "BankAccounts",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "BankAccounts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Accounts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Accounts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "default");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "UnitOfMeasure",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "UnitOfMeasure",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Precision",
                table: "UnitOfMeasure",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UnitOfMeasure",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSystemDefault",
                table: "UnitOfMeasure",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UnitOfMeasure",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ConversionFactor",
                table: "UnitOfMeasure",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UnitOfMeasure",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "UnitOfMeasure",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitOfMeasureId",
                table: "UnitOfMeasure",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitType",
                table: "UnitOfMeasure",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UomType",
                table: "UnitOfMeasure",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasure",
                table: "UnitOfMeasure",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccDimensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccDimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccFiscalYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FiscalYearName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LockDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BaseCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NumberOfPeriods = table.Column<int>(type: "int", nullable: false),
                    PeriodType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccFiscalYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccFiscalYears_Users_ClosedByUserId",
                        column: x => x.ClosedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AccFiscalYears_Users_LockedByUserId",
                        column: x => x.LockedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AccPostingRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceTable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AutoPost = table.Column<bool>(type: "bit", nullable: false),
                    RequireApproval = table.Column<bool>(type: "bit", nullable: false),
                    AccountMappingJson = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccPostingRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VatRate = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: false),
                    WithholdingRate = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: false),
                    VatAccountCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WithholdingAccountCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FxGainAccountCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FxLossAccountCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccSettings_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalWorkflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalWorkflows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApVendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApVendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankReconciliations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReconciliationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BankBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Difference = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankReconciliations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankReconciliations_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AmountInBaseCurrency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BalanceBefore = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    BalanceAfter = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransactions_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchManager = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ManagerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchLevel = table.Column<int>(type: "int", nullable: false),
                    ParentBranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HierarchyPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Branches_ParentBranchId",
                        column: x => x.ParentBranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Users_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BusinessType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CashBoxTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BalanceBefore = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BalanceAfter = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AmountInBaseCurrency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBoxTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashBoxTransactions_CashBoxes_CashBoxId",
                        column: x => x.CashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashBoxTransactions_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashBoxTransactions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CashBoxTransfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceCashBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetCashBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AmountInBaseCurrency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBoxTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashBoxTransfers_CashBoxes_SourceCashBoxId",
                        column: x => x.SourceCashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashBoxTransfers_CashBoxes_TargetCashBoxId",
                        column: x => x.TargetCashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashBoxTransfers_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashBoxTransfers_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AccountCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AccountNameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BalanceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletable = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NormalBalance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPostable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChartOfAccounts_ChartOfAccounts_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ChartOfAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSurveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServiceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OverallRating = table.Column<int>(type: "int", nullable: false),
                    QualityRating = table.Column<int>(type: "int", nullable: true),
                    SpeedRating = table.Column<int>(type: "int", nullable: true),
                    SupportRating = table.Column<int>(type: "int", nullable: true),
                    PricingRating = table.Column<int>(type: "int", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FollowUpNeeded = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSurveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailCampaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Recipients = table.Column<int>(type: "int", nullable: false),
                    Opened = table.Column<int>(type: "int", nullable: false),
                    Clicked = table.Column<int>(type: "int", nullable: false),
                    OpenRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ClickRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Template = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailCampaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailCampaigns_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersonnelNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ToCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    RateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaAssets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcquisitionCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ResidualValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccumulatedDepreciation = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DisposedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsefulLifeMonths = table.Column<int>(type: "int", nullable: false),
                    DepreciationMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpenseAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccumulatedDepAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaDepreciationRuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodNo = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaDepreciationRuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedgerEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LineNo = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DebitAmount = table.Column<int>(type: "int", precision: 18, scale: 2, nullable: false),
                    CreditAmount = table.Column<int>(type: "int", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedgerEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralLedgerEntries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralLedgerEntries_JournalVouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "JournalVouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrnReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PoOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrnReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrnReceipts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstrumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DebitAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instruments_Accounts_CreditAccountId",
                        column: x => x.CreditAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Instruments_Accounts_DebitAccountId",
                        column: x => x.DebitAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Instruments_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "InventoryBarcodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BarcodeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryBarcodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryBarcodes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryBins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryBins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryBins_Bins_BinId",
                        column: x => x.BinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryBins_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCostLayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LayerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LayerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCostLayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryCostLayers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryCostLayers_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryIssueNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIssueNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryIssueNotes_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    MaxQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ReorderPoint = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SafetyStock = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryLevels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLevels_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservedQuantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BinId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ReleasedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReservedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransferNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransferNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTransferNotes_Warehouses_FromWarehouseId",
                        column: x => x.FromWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryTransferNotes_Warehouses_ToWarehouseId",
                        column: x => x.ToWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalApprovalLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalApprovalLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstimatedValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ExpectedConversionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LeadSource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpectedCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Users_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LoginPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PolicyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaximumConcurrentSessions = table.Column<int>(type: "int", nullable: false),
                    InactivityTimeoutMinutes = table.Column<int>(type: "int", nullable: false),
                    SessionDurationMinutes = table.Column<int>(type: "int", nullable: false),
                    AllowLoginFromDifferentIPs = table.Column<bool>(type: "bit", nullable: false),
                    AllowedIpAddresses = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BlockedIpAddresses = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AllowLoginDuringSpecificHours = table.Column<bool>(type: "bit", nullable: false),
                    AllowedLoginHours = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AllowLoginOnSpecificDays = table.Column<bool>(type: "bit", nullable: false),
                    AllowedLoginDays = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RequiresTwoFactorAuthentication = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorAuthenticationType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NewDeviceLoginRequiresApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginPolicies_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoginPolicies_Users_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantyEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Criticality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificationsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedDurationHours = table.Column<int>(type: "int", nullable: true),
                    ActualDurationHours = table.Column<int>(type: "int", nullable: true),
                    RequestedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProblemDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    WorkPerformed = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsEmergency = table.Column<bool>(type: "bit", nullable: false),
                    SafetyRequirements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CostEstimate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaintenanceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FrequencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FrequencyInterval = table.Column<int>(type: "int", nullable: false),
                    NextDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastCompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedDurationHours = table.Column<int>(type: "int", nullable: true),
                    AssignedTechnician = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RequiredParts = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RequiredTools = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceWorkOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScheduledStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CompletionNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PartsUsedJson = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    LaborHours = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceWorkOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PolicyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MinimumPasswordLength = table.Column<int>(type: "int", nullable: false),
                    MaximumPasswordLength = table.Column<int>(type: "int", nullable: false),
                    RequiresUppercase = table.Column<bool>(type: "bit", nullable: false),
                    RequiresLowercase = table.Column<bool>(type: "bit", nullable: false),
                    RequiresNumbers = table.Column<bool>(type: "bit", nullable: false),
                    RequiresSpecialCharacters = table.Column<bool>(type: "bit", nullable: false),
                    AllowedSpecialCharacters = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MinimumSpecialCharactersCount = table.Column<int>(type: "int", nullable: false),
                    CannotContainUsername = table.Column<bool>(type: "bit", nullable: false),
                    CannotContainPersonalInfo = table.Column<bool>(type: "bit", nullable: false),
                    MaximumFailedAttempts = table.Column<int>(type: "int", nullable: false),
                    LockoutDurationMinutes = table.Column<int>(type: "int", nullable: false),
                    PasswordExpiryDays = table.Column<int>(type: "int", nullable: false),
                    PasswordHistoryCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordPolicies_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PasswordPolicies_Users_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PriceChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChangeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceChanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldPriceBuy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OldPriceSell = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NewPriceBuy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NewPriceSell = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChangedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFiles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgressPercentage = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VendorEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VendorPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RequestedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmountInBaseCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RateLimits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    WindowSeconds = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateLimits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ServiceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: true),
                    BaseCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequiredSkills = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RequiredTools = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RequiredParts = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityAudits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EventResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityAudits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SessionAudits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SessionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GeographicLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SessionEndReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionDurationMinutes = table.Column<int>(type: "int", nullable: true),
                    RequestCount = table.Column<int>(type: "int", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSecureSession = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionAudits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmsLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SendStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProviderMessageId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    MaxRetry = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgressPercentage = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Responses = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    CompletionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskProgressUpdates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreviousProgress = table.Column<int>(type: "int", nullable: false),
                    NewProgress = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskProgressUpdates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TechnicianCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SkillLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: true),
                    Certifications = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technicians_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TicketCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreasurySettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaxCashLimit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RequireApprovalAbove = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AutoReconciliation = table.Column<bool>(type: "bit", nullable: false),
                    CashCountingFrequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BackupFrequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReceiptTemplate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AllowNegativeBalance = table.Column<bool>(type: "bit", nullable: false),
                    MultiCurrencySupport = table.Column<bool>(type: "bit", nullable: false),
                    ExchangeRateSource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasurySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityDataJson = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCompatibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    YearRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCompatibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleCompatibilities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarrantyNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMonths = table.Column<int>(type: "int", nullable: false),
                    WarrantyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRenewable = table.Column<bool>(type: "bit", nullable: false),
                    WarrantyCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warranties_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Warranties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TrimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccDimensionValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DimensionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValueName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ParentValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    HierarchyPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccDimensionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccDimensionValues_AccDimensionValues_ParentValueId",
                        column: x => x.ParentValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccDimensionValues_AccDimensions_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "AccDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccFiscalPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FiscalYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PeriodNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LockDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccFiscalPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccFiscalPeriods_AccFiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "AccFiscalYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccFiscalPeriods_Users_ClosedByUserId",
                        column: x => x.ClosedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AccFiscalPeriods_Users_LockedByUserId",
                        column: x => x.LockedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RoleRequired = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalStages_ApprovalWorkflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "ApprovalWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApBills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FiscalPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FiscalYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ApVendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApBills_ApVendors_ApVendorId",
                        column: x => x.ApVendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApBills_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApBills_FiscalPeriods_FiscalPeriodId",
                        column: x => x.FiscalPeriodId,
                        principalTable: "FiscalPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ApBills_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ApPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CashBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApPayments_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApPayments_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ApPayments_CashBoxes_CashBoxId",
                        column: x => x.CashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ArInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FiscalPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FiscalYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArInvoices_ArCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArInvoices_FiscalPeriods_FiscalPeriodId",
                        column: x => x.FiscalPeriodId,
                        principalTable: "FiscalPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ArInvoices_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ArReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CashBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArReceipts_ArCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArReceipts_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ArReceipts_CashBoxes_CashBoxId",
                        column: x => x.CashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrgUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UnitCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitLevel = table.Column<int>(type: "int", nullable: false),
                    HierarchyPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManagerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgUnits_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrgUnits_OrgUnits_ParentUnitId",
                        column: x => x.ParentUnitId,
                        principalTable: "OrgUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrgUnits_Users_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ConsoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentOperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Consoles_ConsoleId",
                        column: x => x.ConsoleId,
                        principalTable: "Consoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Operations_Operations_ParentOperationId",
                        column: x => x.ParentOperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResponseCount = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CloseReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailCampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOpened = table.Column<bool>(type: "bit", nullable: false),
                    OpenedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsClicked = table.Column<bool>(type: "bit", nullable: false),
                    ClickedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReplied = table.Column<bool>(type: "bit", nullable: false),
                    RepliedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailResponses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailResponses_EmailCampaigns_EmailCampaignId",
                        column: x => x.EmailCampaignId,
                        principalTable: "EmailCampaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingHours = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    OvertimeHours = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OvertimePay = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Deductions = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Period = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProcessedComments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsPaidLeave = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_ProcessedBy",
                        column: x => x.ProcessedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GrnLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrnLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrnLines_GrnReceipts_GrnId",
                        column: x => x.GrnId,
                        principalTable: "GrnReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrnLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentFlows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlowType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentFlows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentFlows_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryIssueLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    BinId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIssueLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryIssueLines_InventoryIssueNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "InventoryIssueNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryIssueLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransferLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    FromBinId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToBinId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransferLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTransferLines_InventoryTransferNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "InventoryTransferNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryTransferLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntryLines_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntryLines_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Probability = table.Column<int>(type: "int", nullable: false),
                    ExpectedCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OpportunityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EstimatedValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunities_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Opportunities_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Opportunities_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Trims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drivetrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trims_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    OrderTotalBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxTotalBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GrandTotalBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoOrders_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoOrders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoOrders_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoOrders_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoOrders_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoOrders_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgressPercentage = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActualHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AssignedToUserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssignedToUserId1",
                        column: x => x.AssignedToUserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_UnitOfMeasure_UomId",
                        column: x => x.UomId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchasePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AmountInBaseCurrency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheckNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheckDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CashBoxId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseOrderId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_BankAccounts_BankAccountId1",
                        column: x => x.BankAccountId1,
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasePayments_CashBoxes_CashBoxId",
                        column: x => x.CashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_CashBoxes_CashBoxId1",
                        column: x => x.CashBoxId1,
                        principalTable: "CashBoxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasePayments_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_PurchaseOrders_PurchaseOrderId1",
                        column: x => x.PurchaseOrderId1,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasePayments_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasePayments_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReceipts_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReceipts_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReceipts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiredQuantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairParts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairParts_RepairServices_RepairServiceId",
                        column: x => x.RepairServiceId,
                        principalTable: "RepairServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnswerOptions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MinScore = table.Column<int>(type: "int", nullable: true),
                    MaxScore = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RespondentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyResponses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyResponses_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WarrantyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Decision = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DecisionNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RepairCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AcceptableCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TechnicianNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantyClaims_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WarrantyClaims_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WarrantyClaims_Warranties_WarrantyId",
                        column: x => x.WarrantyId,
                        principalTable: "Warranties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccJournalVouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FiscalPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalDebit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TotalDebitBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalCreditBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccJournalVouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccJournalVouchers_AccFiscalPeriods_FiscalPeriodId",
                        column: x => x.FiscalPeriodId,
                        principalTable: "AccFiscalPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccJournalVouchers_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AccJournalVouchers_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccJournalVouchers_Users_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AccOpeningBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FiscalPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebitBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreditBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    DebitBalanceBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreditBalanceBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisteredByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccOpeningBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccOpeningBalances_AccFiscalPeriods_FiscalPeriodId",
                        column: x => x.FiscalPeriodId,
                        principalTable: "AccFiscalPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccOpeningBalances_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccOpeningBalances_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AccOpeningBalances_Users_RegisteredByUserId",
                        column: x => x.RegisteredByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BudgetCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BudgetType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FiscalYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FiscalPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BudgetStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BudgetTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SpentTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RemainingTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    BudgetTotalBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SpentTotalBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RemainingTotalBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_AccFiscalPeriods_FiscalPeriodId",
                        column: x => x.FiscalPeriodId,
                        principalTable: "AccFiscalPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Budgets_AccFiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "AccFiscalYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Budgets_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Budgets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ClosingRuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RunCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RunType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FiscalPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RunStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionDurationMinutes = table.Column<int>(type: "int", nullable: true),
                    ExecutedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsReversible = table.Column<bool>(type: "bit", nullable: false),
                    ReversalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReversedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReversalReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProcessedDocumentsCount = table.Column<int>(type: "int", nullable: false),
                    ErrorCount = table.Column<int>(type: "int", nullable: false),
                    WarningCount = table.Column<int>(type: "int", nullable: false),
                    ExecutionReport = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ErrorReport = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExecutionParameters = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ExecutionResults = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosingRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClosingRuns_AccFiscalPeriods_FiscalPeriodId",
                        column: x => x.FiscalPeriodId,
                        principalTable: "AccFiscalPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClosingRuns_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ClosingRuns_Users_ExecutedByUserId",
                        column: x => x.ExecutedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClosingRuns_Users_ReversedByUserId",
                        column: x => x.ReversedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ApBillLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApBillLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApBillLines_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApBillLines_ApBills_BillId",
                        column: x => x.BillId,
                        principalTable: "ApBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApBillLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ApSettlements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SettledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApSettlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApSettlements_ApBills_BillId",
                        column: x => x.BillId,
                        principalTable: "ApBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApSettlements_ApPayments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "ApPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArInvoiceLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArInvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArInvoiceLines_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArInvoiceLines_ArInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "ArInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArInvoiceLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ReturnReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturns_ArCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturns_ArInvoices_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "ArInvoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesReturns_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArSettlements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SettledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArSettlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArSettlements_ArInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "ArInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArSettlements_ArReceipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "ArReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrgUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleInUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsUnitManager = table.Column<bool>(type: "bit", nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrgUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrgUnits_OrgUnits_OrgUnitId",
                        column: x => x.OrgUnitId,
                        principalTable: "OrgUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrgUnits_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrgUnits_Users_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserOrgUnits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ConstraintsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inherit = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleOperations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Activities_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Activities_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Activities_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SalesPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoOrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PoOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedQuantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ReceivedQuantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    RemainingQuantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    UnitPriceBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPriceBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalPriceBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoOrderLines_PoOrders_PoOrderId",
                        column: x => x.PoOrderId,
                        principalTable: "PoOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoOrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReceiptLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReceiptLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReceiptLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReceiptLines_PurchaseReceipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "PurchaseReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturns_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturns_PurchaseReceipts_PurchaseReceiptId",
                        column: x => x.PurchaseReceiptId,
                        principalTable: "PurchaseReceipts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReturns_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestionResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionResponses_SurveyQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionResponses_SurveyResponses_SurveyResponseId",
                        column: x => x.SurveyResponseId,
                        principalTable: "SurveyResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccJournalApprovalLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApproverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApproverComments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ApprovalStage = table.Column<int>(type: "int", nullable: false),
                    IsFinalApproval = table.Column<bool>(type: "bit", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalDurationMinutes = table.Column<int>(type: "int", nullable: true),
                    ApprovalType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccJournalApprovalLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccJournalApprovalLogs_AccJournalVouchers_JournalVoucherId",
                        column: x => x.JournalVoucherId,
                        principalTable: "AccJournalVouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccJournalApprovalLogs_Users_ApproverUserId",
                        column: x => x.ApproverUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccJournalLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    DebitAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreditAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Dimension1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension4Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension5Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension1ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension2ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension3ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension4ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension5ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccJournalLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensionValues_Dimension1ValueId",
                        column: x => x.Dimension1ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensionValues_Dimension2ValueId",
                        column: x => x.Dimension2ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensionValues_Dimension3ValueId",
                        column: x => x.Dimension3ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensionValues_Dimension4ValueId",
                        column: x => x.Dimension4ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensionValues_Dimension5ValueId",
                        column: x => x.Dimension5ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensions_Dimension1Id",
                        column: x => x.Dimension1Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensions_Dimension2Id",
                        column: x => x.Dimension2Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensions_Dimension3Id",
                        column: x => x.Dimension3Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensions_Dimension4Id",
                        column: x => x.Dimension4Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccDimensions_Dimension5Id",
                        column: x => x.Dimension5Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccJournalLines_AccJournalVouchers_JournalVoucherId",
                        column: x => x.JournalVoucherId,
                        principalTable: "AccJournalVouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccJournalLines_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaDepreciationEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaDepreciationRunId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepreciationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodNumber = table.Column<int>(type: "int", nullable: false),
                    DepreciationAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AccumulatedDepreciation = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BookValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DepreciationAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccumulatedDepreciationAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JournalVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    DepreciationAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AccumulatedDepreciationBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BookValueBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaDepreciationEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaDepreciationEntries_AccJournalVouchers_JournalVoucherId",
                        column: x => x.JournalVoucherId,
                        principalTable: "AccJournalVouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FaDepreciationEntries_Accounts_AccumulatedDepreciationAccountId",
                        column: x => x.AccumulatedDepreciationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FaDepreciationEntries_Accounts_DepreciationAccountId",
                        column: x => x.DepreciationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FaDepreciationEntries_FaAssets_FaAssetId",
                        column: x => x.FaAssetId,
                        principalTable: "FaAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaDepreciationEntries_FaCategories_FaCategoryId",
                        column: x => x.FaCategoryId,
                        principalTable: "FaCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaDepreciationEntries_FaDepreciationRuns_FaDepreciationRunId",
                        column: x => x.FaDepreciationRunId,
                        principalTable: "FaDepreciationRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaDepreciationEntries_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BudgetLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SpentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Dimension1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension4Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension5Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension1ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension2ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension3ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension4ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dimension5ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    BudgetAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SpentAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RemainingAmountBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensionValues_Dimension1ValueId",
                        column: x => x.Dimension1ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensionValues_Dimension2ValueId",
                        column: x => x.Dimension2ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensionValues_Dimension3ValueId",
                        column: x => x.Dimension3ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensionValues_Dimension4ValueId",
                        column: x => x.Dimension4ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensionValues_Dimension5ValueId",
                        column: x => x.Dimension5ValueId,
                        principalTable: "AccDimensionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensions_Dimension1Id",
                        column: x => x.Dimension1Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensions_Dimension2Id",
                        column: x => x.Dimension2Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensions_Dimension3Id",
                        column: x => x.Dimension3Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensions_Dimension4Id",
                        column: x => x.Dimension4Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_AccDimensions_Dimension5Id",
                        column: x => x.Dimension5Id,
                        principalTable: "AccDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetLines_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetLines_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BudgetLines_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnedQuantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturnLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnLines_SalesReturns_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "SalesReturns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AmountInBaseCurrency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheckNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheckDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CashBoxId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePayments_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SalePayments_BankAccounts_BankAccountId1",
                        column: x => x.BankAccountId1,
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalePayments_CashBoxes_CashBoxId",
                        column: x => x.CashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SalePayments_CashBoxes_CashBoxId1",
                        column: x => x.CashBoxId1,
                        principalTable: "CashBoxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalePayments_SalesOrders_SaleId",
                        column: x => x.SaleId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalePayments_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalePayments_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalePayments_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLines_PurchaseReturns_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "PurchaseReturns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId1",
                table: "UserSettings",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DisplayName",
                table: "Roles",
                column: "DisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ParentRoleId",
                table: "Roles",
                column: "ParentRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId_PermissionId",
                table: "RolePermissions",
                columns: new[] { "RoleId", "PermissionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId1",
                table: "RolePermissions",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Action",
                table: "Permissions",
                column: "Action");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Controller",
                table: "Permissions",
                column: "Controller");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Group",
                table: "Permissions",
                column: "Group");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                table: "Permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Code",
                table: "Warehouses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Code",
                table: "Vendors",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Email",
                table: "Vendors",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessId",
                table: "Users",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId1",
                table: "Users",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId1",
                table: "UserProfiles",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UomConversions_IsActive",
                table: "UomConversions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_Category_Key_BusinessId",
                table: "SystemSettings",
                columns: new[] { "Category", "Key", "BusinessId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CustomerId",
                table: "SalesInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_InvoiceDate",
                table: "SalesInvoices",
                column: "InvoiceDate");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_Status",
                table: "SalesInvoices",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLines_AccountId",
                table: "SalesInvoiceLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBills_BillDate",
                table: "PurchaseBills",
                column: "BillDate");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBills_Number",
                table: "PurchaseBills",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBills_Status",
                table: "PurchaseBills",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBills_VendorId",
                table: "PurchaseBills",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBills_VendorId1",
                table: "PurchaseBills",
                column: "VendorId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBillLines_AccountId",
                table: "PurchaseBillLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId1",
                table: "Products",
                column: "ModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TrimId",
                table: "Products",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TrimId1",
                table: "Products",
                column: "TrimId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitOfMeasureId",
                table: "Products",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_YearId",
                table: "Products",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalVouchers_FiscalPeriodId",
                table: "JournalVouchers",
                column: "FiscalPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalVouchers_FiscalYearId",
                table: "JournalVouchers",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalVouchers_Status",
                table: "JournalVouchers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_JournalVouchers_Type",
                table: "JournalVouchers",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_JournalVouchers_VoucherDate",
                table: "JournalVouchers",
                column: "VoucherDate");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_BinId",
                table: "InventoryMovements",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_MovementType",
                table: "InventoryMovements",
                column: "MovementType");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BinId1",
                table: "Inventories",
                column: "BinId1");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_Code",
                table: "FiscalYears",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_YearEnd",
                table: "FiscalYears",
                column: "YearEnd");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_YearStart",
                table: "FiscalYears",
                column: "YearStart");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalPeriods_EndDate",
                table: "FiscalPeriods",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalPeriods_StartDate",
                table: "FiscalPeriods",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BusinessId",
                table: "Departments",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                table: "Departments",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                table: "Customers",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_NationalId",
                table: "Companies",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RegistrationNumber",
                table: "Companies",
                column: "RegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransactions_Type",
                table: "CashTransactions",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxes_ControlAccountId",
                table: "CashBoxes",
                column: "ControlAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Code",
                table: "Brands",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_AccountNumber",
                table: "BankAccounts",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_Iban",
                table: "BankAccounts",
                column: "Iban");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Code",
                table: "Accounts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Name",
                table: "Accounts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasure_Code",
                table: "UnitOfMeasure",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasure_UnitOfMeasureId",
                table: "UnitOfMeasure",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_AccDimensions_Code",
                table: "AccDimensions",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AccDimensions_Type",
                table: "AccDimensions",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_AccDimensionValues_DimensionId",
                table: "AccDimensionValues",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccDimensionValues_DisplayOrder",
                table: "AccDimensionValues",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_AccDimensionValues_ParentValueId",
                table: "AccDimensionValues",
                column: "ParentValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalPeriods_ClosedByUserId",
                table: "AccFiscalPeriods",
                column: "ClosedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalPeriods_FiscalYearId_PeriodNumber",
                table: "AccFiscalPeriods",
                columns: new[] { "FiscalYearId", "PeriodNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalPeriods_LockedByUserId",
                table: "AccFiscalPeriods",
                column: "LockedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalPeriods_Status",
                table: "AccFiscalPeriods",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalYears_ClosedByUserId",
                table: "AccFiscalYears",
                column: "ClosedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalYears_LockedByUserId",
                table: "AccFiscalYears",
                column: "LockedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalYears_Status",
                table: "AccFiscalYears",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AccFiscalYears_Year",
                table: "AccFiscalYears",
                column: "Year");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalApprovalLogs_ApprovalDate",
                table: "AccJournalApprovalLogs",
                column: "ApprovalDate");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalApprovalLogs_ApprovalStatus",
                table: "AccJournalApprovalLogs",
                column: "ApprovalStatus");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalApprovalLogs_ApproverUserId",
                table: "AccJournalApprovalLogs",
                column: "ApproverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalApprovalLogs_JournalVoucherId",
                table: "AccJournalApprovalLogs",
                column: "JournalVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_AccountId",
                table: "AccJournalLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension1Id",
                table: "AccJournalLines",
                column: "Dimension1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension1ValueId",
                table: "AccJournalLines",
                column: "Dimension1ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension2Id",
                table: "AccJournalLines",
                column: "Dimension2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension2ValueId",
                table: "AccJournalLines",
                column: "Dimension2ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension3Id",
                table: "AccJournalLines",
                column: "Dimension3Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension3ValueId",
                table: "AccJournalLines",
                column: "Dimension3ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension4Id",
                table: "AccJournalLines",
                column: "Dimension4Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension4ValueId",
                table: "AccJournalLines",
                column: "Dimension4ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension5Id",
                table: "AccJournalLines",
                column: "Dimension5Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_Dimension5ValueId",
                table: "AccJournalLines",
                column: "Dimension5ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_JournalVoucherId",
                table: "AccJournalLines",
                column: "JournalVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalLines_LineNumber",
                table: "AccJournalLines",
                column: "LineNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalVouchers_ApprovedByUserId",
                table: "AccJournalVouchers",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalVouchers_CreatedByUserId",
                table: "AccJournalVouchers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalVouchers_FiscalPeriodId",
                table: "AccJournalVouchers",
                column: "FiscalPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalVouchers_LastModifiedByUserId",
                table: "AccJournalVouchers",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalVouchers_Status",
                table: "AccJournalVouchers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalVouchers_VoucherDate",
                table: "AccJournalVouchers",
                column: "VoucherDate");

            migrationBuilder.CreateIndex(
                name: "IX_AccJournalVouchers_VoucherNumber",
                table: "AccJournalVouchers",
                column: "VoucherNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccOpeningBalances_AccountId_FiscalPeriodId",
                table: "AccOpeningBalances",
                columns: new[] { "AccountId", "FiscalPeriodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccOpeningBalances_ApprovedByUserId",
                table: "AccOpeningBalances",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccOpeningBalances_FiscalPeriodId",
                table: "AccOpeningBalances",
                column: "FiscalPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_AccOpeningBalances_RegisteredByUserId",
                table: "AccOpeningBalances",
                column: "RegisteredByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccPostingRules_BusinessId",
                table: "AccPostingRules",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_AccPostingRules_SourceTable",
                table: "AccPostingRules",
                column: "SourceTable");

            migrationBuilder.CreateIndex(
                name: "IX_AccSettings_CreatedByUserId",
                table: "AccSettings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccSettings_DefaultCurrency",
                table: "AccSettings",
                column: "DefaultCurrency");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityType",
                table: "Activities",
                column: "ActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AssignedTo",
                table: "Activities",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AssignedUserId",
                table: "Activities",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ContactId",
                table: "Activities",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LeadId",
                table: "Activities",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_OpportunityId",
                table: "Activities",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StartDate",
                table: "Activities",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Status",
                table: "Activities",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ApBillLines_AccountId",
                table: "ApBillLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBillLines_BillId",
                table: "ApBillLines",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBillLines_LineNo",
                table: "ApBillLines",
                column: "LineNo");

            migrationBuilder.CreateIndex(
                name: "IX_ApBillLines_ProductId",
                table: "ApBillLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBills_ApVendorId",
                table: "ApBills",
                column: "ApVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBills_BillDate",
                table: "ApBills",
                column: "BillDate");

            migrationBuilder.CreateIndex(
                name: "IX_ApBills_FiscalPeriodId",
                table: "ApBills",
                column: "FiscalPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBills_FiscalYearId",
                table: "ApBills",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBills_Number",
                table: "ApBills",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_ApBills_Status",
                table: "ApBills",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ApBills_VendorId",
                table: "ApBills",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPayments_BankAccountId",
                table: "ApPayments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPayments_CashBoxId",
                table: "ApPayments",
                column: "CashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPayments_PaymentDate",
                table: "ApPayments",
                column: "PaymentDate");

            migrationBuilder.CreateIndex(
                name: "IX_ApPayments_Status",
                table: "ApPayments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ApPayments_VendorId",
                table: "ApPayments",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_Order",
                table: "ApprovalStages",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_WorkflowId",
                table: "ApprovalStages",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalWorkflows_Name",
                table: "ApprovalWorkflows",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ApSettlements_BillId",
                table: "ApSettlements",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ApSettlements_PaymentId",
                table: "ApSettlements",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApSettlements_SettledAt",
                table: "ApSettlements",
                column: "SettledAt");

            migrationBuilder.CreateIndex(
                name: "IX_ApVendors_BusinessId",
                table: "ApVendors",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ApVendors_Code",
                table: "ApVendors",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ApVendors_Name",
                table: "ApVendors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ArCustomers_BusinessId",
                table: "ArCustomers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ArCustomers_Code",
                table: "ArCustomers",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ArCustomers_Name",
                table: "ArCustomers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceLines_AccountId",
                table: "ArInvoiceLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceLines_InvoiceId",
                table: "ArInvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceLines_LineNo",
                table: "ArInvoiceLines",
                column: "LineNo");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceLines_ProductId",
                table: "ArInvoiceLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoices_CustomerId",
                table: "ArInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoices_FiscalPeriodId",
                table: "ArInvoices",
                column: "FiscalPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoices_FiscalYearId",
                table: "ArInvoices",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoices_InvoiceDate",
                table: "ArInvoices",
                column: "InvoiceDate");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoices_Number",
                table: "ArInvoices",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoices_Status",
                table: "ArInvoices",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_BankAccountId",
                table: "ArReceipts",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_CashBoxId",
                table: "ArReceipts",
                column: "CashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_CustomerId",
                table: "ArReceipts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_ReceiptDate",
                table: "ArReceipts",
                column: "ReceiptDate");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_Status",
                table: "ArReceipts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ArSettlements_InvoiceId",
                table: "ArSettlements",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ArSettlements_ReceiptId",
                table: "ArSettlements",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ArSettlements_SettledAt",
                table: "ArSettlements",
                column: "SettledAt");

            migrationBuilder.CreateIndex(
                name: "IX_BankReconciliations_BankAccountId",
                table: "BankReconciliations",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankReconciliations_ReconciliationDate",
                table: "BankReconciliations",
                column: "ReconciliationDate");

            migrationBuilder.CreateIndex(
                name: "IX_BankReconciliations_Status",
                table: "BankReconciliations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_BankAccountId",
                table: "BankTransactions",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_ReferenceNumber",
                table: "BankTransactions",
                column: "ReferenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_TransactionDate",
                table: "BankTransactions",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_TransactionType",
                table: "BankTransactions",
                column: "TransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchCode",
                table: "Branches",
                column: "BranchCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ManagerUserId",
                table: "Branches",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ParentBranchId",
                table: "Branches",
                column: "ParentBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_AccountId",
                table: "BudgetLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_BudgetId",
                table: "BudgetLines",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_DepartmentId",
                table: "BudgetLines",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension1Id",
                table: "BudgetLines",
                column: "Dimension1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension1ValueId",
                table: "BudgetLines",
                column: "Dimension1ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension2Id",
                table: "BudgetLines",
                column: "Dimension2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension2ValueId",
                table: "BudgetLines",
                column: "Dimension2ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension3Id",
                table: "BudgetLines",
                column: "Dimension3Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension3ValueId",
                table: "BudgetLines",
                column: "Dimension3ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension4Id",
                table: "BudgetLines",
                column: "Dimension4Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension4ValueId",
                table: "BudgetLines",
                column: "Dimension4ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension5Id",
                table: "BudgetLines",
                column: "Dimension5Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Dimension5ValueId",
                table: "BudgetLines",
                column: "Dimension5ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_LineNumber",
                table: "BudgetLines",
                column: "LineNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_ProjectId",
                table: "BudgetLines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_ApprovedByUserId",
                table: "Budgets",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_BudgetCode",
                table: "Budgets",
                column: "BudgetCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CreatedByUserId",
                table: "Budgets",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_DepartmentId",
                table: "Budgets",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_FiscalPeriodId",
                table: "Budgets",
                column: "FiscalPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_FiscalYearId",
                table: "Budgets",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_LastModifiedByUserId",
                table: "Budgets",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_ProjectId",
                table: "Budgets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_Code",
                table: "Businesses",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_CompanyId",
                table: "Businesses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_Name",
                table: "Businesses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransactions_ApprovedByUserId",
                table: "CashBoxTransactions",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransactions_CashBoxId",
                table: "CashBoxTransactions",
                column: "CashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransactions_CreatedByUserId",
                table: "CashBoxTransactions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransactions_Status",
                table: "CashBoxTransactions",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransactions_TransactionDate",
                table: "CashBoxTransactions",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransactions_Type",
                table: "CashBoxTransactions",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransfers_ApprovedByUserId",
                table: "CashBoxTransfers",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransfers_CreatedByUserId",
                table: "CashBoxTransfers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransfers_SourceCashBoxId",
                table: "CashBoxTransfers",
                column: "SourceCashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransfers_Status",
                table: "CashBoxTransfers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransfers_TargetCashBoxId",
                table: "CashBoxTransfers",
                column: "TargetCashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxTransfers_TransferDate",
                table: "CashBoxTransfers",
                column: "TransferDate");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_AccountCode",
                table: "ChartOfAccounts",
                column: "AccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_AccountName",
                table: "ChartOfAccounts",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_ParentId",
                table: "ChartOfAccounts",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRuns_ApprovedByUserId",
                table: "ClosingRuns",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRuns_ExecutedByUserId",
                table: "ClosingRuns",
                column: "ExecutedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRuns_FiscalPeriodId",
                table: "ClosingRuns",
                column: "FiscalPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRuns_ReversedByUserId",
                table: "ClosingRuns",
                column: "ReversedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRuns_RunCode",
                table: "ClosingRuns",
                column: "RunCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRuns_RunDate",
                table: "ClosingRuns",
                column: "RunDate");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRuns_RunStatus",
                table: "ClosingRuns",
                column: "RunStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_Code",
                table: "Consoles",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyName",
                table: "Contacts",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email",
                table: "Contacts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Mobile",
                table: "Contacts",
                column: "Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Phone",
                table: "Contacts",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_OrderDate",
                table: "CustomerOrders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_OrderNumber",
                table: "CustomerOrders",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_Status",
                table: "CustomerOrders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveys_CustomerPhone",
                table: "CustomerSurveys",
                column: "CustomerPhone");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveys_ServiceType",
                table: "CustomerSurveys",
                column: "ServiceType");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveys_Status",
                table: "CustomerSurveys",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveys_SubmittedAt",
                table: "CustomerSurveys",
                column: "SubmittedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveys_SurveyNumber",
                table: "CustomerSurveys",
                column: "SurveyNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailCampaigns_CreatedBy",
                table: "EmailCampaigns",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCampaigns_SentDate",
                table: "EmailCampaigns",
                column: "SentDate");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCampaigns_Status",
                table: "EmailCampaigns",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmailResponses_ClickedDate",
                table: "EmailResponses",
                column: "ClickedDate");

            migrationBuilder.CreateIndex(
                name: "IX_EmailResponses_ContactId",
                table: "EmailResponses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailResponses_EmailCampaignId",
                table: "EmailResponses",
                column: "EmailCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailResponses_OpenedDate",
                table: "EmailResponses",
                column: "OpenedDate");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_AttendanceDate",
                table: "EmployeeAttendance",
                column: "AttendanceDate");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_EmployeeId",
                table: "EmployeeAttendance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_Status",
                table: "EmployeeAttendance",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalCode",
                table: "Employees",
                column: "NationalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonnelNumber",
                table: "Employees",
                column: "PersonnelNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Status",
                table: "Employees",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_CreatedBy",
                table: "EmployeeSalary",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_PaymentStatus",
                table: "EmployeeSalary",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_PeriodStartDate",
                table: "EmployeeSalary",
                column: "PeriodStartDate");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_FromCurrency_ToCurrency_RateDate",
                table: "ExchangeRates",
                columns: new[] { "FromCurrency", "ToCurrency", "RateDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_IsActive",
                table: "ExchangeRates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_RateDate",
                table: "ExchangeRates",
                column: "RateDate");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_BusinessId_Code",
                table: "FaAssets",
                columns: new[] { "BusinessId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_CategoryId",
                table: "FaAssets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FaCategories_BusinessId_Code",
                table: "FaCategories",
                columns: new[] { "BusinessId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationEntries_AccumulatedDepreciationAccountId",
                table: "FaDepreciationEntries",
                column: "AccumulatedDepreciationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationEntries_ApprovedByUserId",
                table: "FaDepreciationEntries",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationEntries_DepreciationAccountId",
                table: "FaDepreciationEntries",
                column: "DepreciationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationEntries_FaAssetId_PeriodNumber",
                table: "FaDepreciationEntries",
                columns: new[] { "FaAssetId", "PeriodNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationEntries_FaCategoryId",
                table: "FaDepreciationEntries",
                column: "FaCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationEntries_FaDepreciationRunId",
                table: "FaDepreciationEntries",
                column: "FaDepreciationRunId");

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationEntries_JournalVoucherId",
                table: "FaDepreciationEntries",
                column: "JournalVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_FaDepreciationRuns_BusinessId_AssetId_PeriodNo",
                table: "FaDepreciationRuns",
                columns: new[] { "BusinessId", "AssetId", "PeriodNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgerEntries_AccountId",
                table: "GeneralLedgerEntries",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgerEntries_TransactionDate",
                table: "GeneralLedgerEntries",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgerEntries_VoucherDate",
                table: "GeneralLedgerEntries",
                column: "VoucherDate");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgerEntries_VoucherId",
                table: "GeneralLedgerEntries",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_GrnLines_GrnId",
                table: "GrnLines",
                column: "GrnId");

            migrationBuilder.CreateIndex(
                name: "IX_GrnLines_LineNo",
                table: "GrnLines",
                column: "LineNo");

            migrationBuilder.CreateIndex(
                name: "IX_GrnLines_ProductId",
                table: "GrnLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GrnReceipts_Number",
                table: "GrnReceipts",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_GrnReceipts_ReceiptDate",
                table: "GrnReceipts",
                column: "ReceiptDate");

            migrationBuilder.CreateIndex(
                name: "IX_GrnReceipts_Status",
                table: "GrnReceipts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_GrnReceipts_VendorId",
                table: "GrnReceipts",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_GrnReceipts_WarehouseId",
                table: "GrnReceipts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentFlows_FlowDate",
                table: "InstrumentFlows",
                column: "FlowDate");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentFlows_FlowType",
                table: "InstrumentFlows",
                column: "FlowType");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentFlows_InstrumentId",
                table: "InstrumentFlows",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_BankAccountId",
                table: "Instruments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_CreditAccountId",
                table: "Instruments",
                column: "CreditAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_DebitAccountId",
                table: "Instruments",
                column: "DebitAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_DueDate",
                table: "Instruments",
                column: "DueDate");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_InstrumentNumber",
                table: "Instruments",
                column: "InstrumentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_InstrumentType",
                table: "Instruments",
                column: "InstrumentType");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_IssueDate",
                table: "Instruments",
                column: "IssueDate");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_Status",
                table: "Instruments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBarcodes_Barcode",
                table: "InventoryBarcodes",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBarcodes_ProductId",
                table: "InventoryBarcodes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBins_BinId",
                table: "InventoryBins",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBins_LastUpdated",
                table: "InventoryBins",
                column: "LastUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBins_ProductId_BinId",
                table: "InventoryBins",
                columns: new[] { "ProductId", "BinId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayers_LayerDate",
                table: "InventoryCostLayers",
                column: "LayerDate");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayers_ProductId",
                table: "InventoryCostLayers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayers_WarehouseId",
                table: "InventoryCostLayers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueLines_LineNo",
                table: "InventoryIssueLines",
                column: "LineNo");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueLines_NoteId",
                table: "InventoryIssueLines",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueLines_ProductId",
                table: "InventoryIssueLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueNotes_IssueDate",
                table: "InventoryIssueNotes",
                column: "IssueDate");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueNotes_Number",
                table: "InventoryIssueNotes",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueNotes_Status",
                table: "InventoryIssueNotes",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueNotes_WarehouseId",
                table: "InventoryIssueNotes",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLevels_ProductId_WarehouseId",
                table: "InventoryLevels",
                columns: new[] { "ProductId", "WarehouseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLevels_WarehouseId",
                table: "InventoryLevels",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReservations_ProductId",
                table: "InventoryReservations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReservations_ReservationDate",
                table: "InventoryReservations",
                column: "ReservationDate");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReservations_Status",
                table: "InventoryReservations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReservations_WarehouseId",
                table: "InventoryReservations",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferLines_LineNo",
                table: "InventoryTransferLines",
                column: "LineNo");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferLines_NoteId",
                table: "InventoryTransferLines",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferLines_ProductId",
                table: "InventoryTransferLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferNotes_FromWarehouseId",
                table: "InventoryTransferNotes",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferNotes_Number",
                table: "InventoryTransferNotes",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferNotes_Status",
                table: "InventoryTransferNotes",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferNotes_ToWarehouseId",
                table: "InventoryTransferNotes",
                column: "ToWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransferNotes_TransferDate",
                table: "InventoryTransferNotes",
                column: "TransferDate");

            migrationBuilder.CreateIndex(
                name: "IX_JournalApprovalLogs_ApprovedBy",
                table: "JournalApprovalLogs",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JournalApprovalLogs_JournalId",
                table: "JournalApprovalLogs",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_AccountId",
                table: "JournalEntries",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_EntryDate",
                table: "JournalEntries",
                column: "EntryDate");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_EntryNumber",
                table: "JournalEntries",
                column: "EntryNumber");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_EntryType",
                table: "JournalEntries",
                column: "EntryType");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLines_AccountId",
                table: "JournalEntryLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLines_JournalEntryId",
                table: "JournalEntryLines",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_AssignedTo",
                table: "Leads",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Email",
                table: "Leads",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Phone",
                table: "Leads",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Status",
                table: "Leads",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leaves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_ProcessedBy",
                table: "Leaves",
                column: "ProcessedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_StartDate",
                table: "Leaves",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_Status",
                table: "Leaves",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_LoginPolicies_CreatedByUserId",
                table: "LoginPolicies",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginPolicies_LastModifiedByUserId",
                table: "LoginPolicies",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginPolicies_PolicyCode",
                table: "LoginPolicies",
                column: "PolicyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceEquipment_BusinessId_EquipmentCode",
                table: "MaintenanceEquipment",
                columns: new[] { "BusinessId", "EquipmentCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_BusinessId_RequestNumber",
                table: "MaintenanceRequests",
                columns: new[] { "BusinessId", "RequestNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_EquipmentId",
                table: "MaintenanceRequests",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_Status",
                table: "MaintenanceRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_BusinessId_EquipmentId_ScheduleName",
                table: "MaintenanceSchedules",
                columns: new[] { "BusinessId", "EquipmentId", "ScheduleName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_IsActive",
                table: "MaintenanceSchedules",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_NextDueDate",
                table: "MaintenanceSchedules",
                column: "NextDueDate");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceWorkOrders_BusinessId_WorkOrderNumber",
                table: "MaintenanceWorkOrders",
                columns: new[] { "BusinessId", "WorkOrderNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceWorkOrders_EquipmentId",
                table: "MaintenanceWorkOrders",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceWorkOrders_Status",
                table: "MaintenanceWorkOrders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_CategoryId",
                table: "Models",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Code",
                table: "Models",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name",
                table: "Models",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_Code",
                table: "Operations",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ConsoleId",
                table: "Operations",
                column: "ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ParentOperationId",
                table: "Operations",
                column: "ParentOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_AssignedTo",
                table: "Opportunities",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_ContactId",
                table: "Opportunities",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_CustomerId",
                table: "Opportunities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_ExpectedCloseDate",
                table: "Opportunities",
                column: "ExpectedCloseDate");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_LeadId",
                table: "Opportunities",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Stage",
                table: "Opportunities",
                column: "Stage");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Status",
                table: "Opportunities",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUnits_BranchId",
                table: "OrgUnits",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUnits_ManagerUserId",
                table: "OrgUnits",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUnits_ParentUnitId",
                table: "OrgUnits",
                column: "ParentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUnits_UnitCode",
                table: "OrgUnits",
                column: "UnitCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordPolicies_CreatedByUserId",
                table: "PasswordPolicies",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordPolicies_LastModifiedByUserId",
                table: "PasswordPolicies",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordPolicies_PolicyCode",
                table: "PasswordPolicies",
                column: "PolicyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoOrderLines_PoOrderId",
                table: "PoOrderLines",
                column: "PoOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrderLines_ProductId",
                table: "PoOrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_ApprovedByUserId",
                table: "PoOrders",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_CreatedByUserId",
                table: "PoOrders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_DepartmentId",
                table: "PoOrders",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_OrderNumber",
                table: "PoOrders",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_ProjectId",
                table: "PoOrders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_Status",
                table: "PoOrders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_VendorId",
                table: "PoOrders",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PoOrders_WarehouseId",
                table: "PoOrders",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductId_AttributeName",
                table: "ProductAttributes",
                columns: new[] { "ProductId", "AttributeName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_Code",
                table: "ProductCategories",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_Name",
                table: "ProductCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFiles_ProductId_FileUrl",
                table: "ProductFiles",
                columns: new[] { "ProductId", "FileUrl" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId_ImageUrl",
                table: "ProductImages",
                columns: new[] { "ProductId", "ImageUrl" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StartDate",
                table: "Projects",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Status",
                table: "Projects",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_ProductId",
                table: "PurchaseOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchaseOrderId",
                table: "PurchaseOrderItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_UomId",
                table: "PurchaseOrderItems",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ApprovedByUserId",
                table: "PurchaseOrders",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CreatedByUserId",
                table: "PurchaseOrders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_OrderNumber",
                table: "PurchaseOrders",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Status",
                table: "PurchaseOrders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_VendorId",
                table: "PurchaseOrders",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_WarehouseId",
                table: "PurchaseOrders",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_ApprovedByUserId",
                table: "PurchasePayments",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_BankAccountId",
                table: "PurchasePayments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_BankAccountId1",
                table: "PurchasePayments",
                column: "BankAccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_CashBoxId",
                table: "PurchasePayments",
                column: "CashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_CashBoxId1",
                table: "PurchasePayments",
                column: "CashBoxId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_CreatedByUserId",
                table: "PurchasePayments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PaymentDate",
                table: "PurchasePayments",
                column: "PaymentDate");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PurchaseOrderId",
                table: "PurchasePayments",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PurchaseOrderId1",
                table: "PurchasePayments",
                column: "PurchaseOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_Status",
                table: "PurchasePayments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceiptLines_ProductId",
                table: "PurchaseReceiptLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceiptLines_ReceiptId",
                table: "PurchaseReceiptLines",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceipts_PurchaseOrderId",
                table: "PurchaseReceipts",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceipts_VendorId",
                table: "PurchaseReceipts",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceipts_WarehouseId",
                table: "PurchaseReceipts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLines_ProductId",
                table: "PurchaseReturnLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLines_ReturnId",
                table: "PurchaseReturnLines",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_PurchaseReceiptId",
                table: "PurchaseReturns",
                column: "PurchaseReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_VendorId",
                table: "PurchaseReturns",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_WarehouseId",
                table: "PurchaseReturns",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_RateLimits_Key",
                table: "RateLimits",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairParts_BusinessId",
                table: "RepairParts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairParts_ProductId",
                table: "RepairParts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairParts_RepairServiceId",
                table: "RepairParts",
                column: "RepairServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairServices_BusinessId",
                table: "RepairServices",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairServices_ServiceCode",
                table: "RepairServices",
                column: "ServiceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_OperationId",
                table: "RoleOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_RoleId",
                table: "RoleOperations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_RoleId_OperationId",
                table: "RoleOperations",
                columns: new[] { "RoleId", "OperationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_ApprovedByUserId",
                table: "SalePayments",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_BankAccountId",
                table: "SalePayments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_BankAccountId1",
                table: "SalePayments",
                column: "BankAccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_CashBoxId",
                table: "SalePayments",
                column: "CashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_CashBoxId1",
                table: "SalePayments",
                column: "CashBoxId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_CreatedByUserId",
                table: "SalePayments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_PaymentDate",
                table: "SalePayments",
                column: "PaymentDate");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_SaleId",
                table: "SalePayments",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_SalesOrderId",
                table: "SalePayments",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_Status",
                table: "SalePayments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_ProductId",
                table: "SalesOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesOrderId",
                table: "SalesOrderItems",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_OpportunityId",
                table: "SalesOrders",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_OrderNumber",
                table: "SalesOrders",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_Status",
                table: "SalesOrders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_WarehouseId",
                table: "SalesOrders",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLines_ProductId",
                table: "SalesReturnLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLines_ReturnId",
                table: "SalesReturnLines",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_CustomerId",
                table: "SalesReturns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_ReturnNumber",
                table: "SalesReturns",
                column: "ReturnNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_SalesInvoiceId",
                table: "SalesReturns",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_Status",
                table: "SalesReturns",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_WarehouseId",
                table: "SalesReturns",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAudits_EventDate",
                table: "SecurityAudits",
                column: "EventDate");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAudits_EventType",
                table: "SecurityAudits",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAudits_IpAddress",
                table: "SecurityAudits",
                column: "IpAddress");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAudits_UserId",
                table: "SecurityAudits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAudits_SessionId",
                table: "SessionAudits",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionAudits_SessionStartDate",
                table: "SessionAudits",
                column: "SessionStartDate");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAudits_UserId",
                table: "SessionAudits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsLogs_PhoneNumber",
                table: "SmsLogs",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SmsLogs_ProviderMessageId",
                table: "SmsLogs",
                column: "ProviderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsLogs_SendDate",
                table: "SmsLogs",
                column: "SendDate");

            migrationBuilder.CreateIndex(
                name: "IX_SmsLogs_SendStatus",
                table: "SmsLogs",
                column: "SendStatus");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionResponses_QuestionId",
                table: "SurveyQuestionResponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionResponses_SurveyResponseId",
                table: "SurveyQuestionResponses",
                column: "SurveyResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_BusinessId",
                table: "SurveyQuestions",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_DisplayOrder",
                table: "SurveyQuestions",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_ContactId",
                table: "SurveyResponses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_SurveyId",
                table: "SurveyResponses",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CreatedByUserId",
                table: "Surveys",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedToUserId1",
                table: "Tasks",
                column: "AssignedToUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_BusinessId",
                table: "Technicians",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_TechnicianCode",
                table: "Technicians",
                column: "TechnicianCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategories_BusinessId_Code",
                table: "TicketCategories",
                columns: new[] { "BusinessId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategories_Name",
                table: "TicketCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TicketResponses_CreatedAt",
                table: "TicketResponses",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TicketResponses_TicketId",
                table: "TicketResponses",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedUserId",
                table: "Tickets",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ContactId",
                table: "Tickets",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedAt",
                table: "Tickets",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Status",
                table: "Tickets",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketNumber",
                table: "Tickets",
                column: "TicketNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionDate",
                table: "Transactions",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionNumber",
                table: "Transactions",
                column: "TransactionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Type",
                table: "Transactions",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_TreasurySettings_BusinessId",
                table: "TreasurySettings",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trims_ModelId",
                table: "Trims",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityLogs_ActivityType",
                table: "UserActivityLogs",
                column: "ActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityLogs_CreatedAt",
                table: "UserActivityLogs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityLogs_UserId",
                table: "UserActivityLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrgUnits_CreatedByUserId",
                table: "UserOrgUnits",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrgUnits_LastModifiedByUserId",
                table: "UserOrgUnits",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrgUnits_OrgUnitId",
                table: "UserOrgUnits",
                column: "OrgUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrgUnits_UserId_OrgUnitId",
                table: "UserOrgUnits",
                columns: new[] { "UserId", "OrgUnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCompatibilities_ProductId_Brand_Model_YearRange",
                table: "VehicleCompatibilities",
                columns: new[] { "ProductId", "Brand", "Model", "YearRange" },
                unique: true,
                filter: "[YearRange] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VendorOrders_OrderDate",
                table: "VendorOrders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_VendorOrders_OrderNumber",
                table: "VendorOrders",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_VendorOrders_Status",
                table: "VendorOrders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_VendorOrders_VendorId",
                table: "VendorOrders",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_BusinessId",
                table: "Warranties",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_CustomerId",
                table: "Warranties",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_ProductId",
                table: "Warranties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_WarrantyNumber",
                table: "Warranties",
                column: "WarrantyNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyClaims_BusinessId",
                table: "WarrantyClaims",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyClaims_ClaimNumber",
                table: "WarrantyClaims",
                column: "ClaimNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyClaims_CustomerId",
                table: "WarrantyClaims",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyClaims_TechnicianId",
                table: "WarrantyClaims",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyClaims_WarrantyId",
                table: "WarrantyClaims",
                column: "WarrantyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Accounts_ControlAccountId",
                table: "BankAccounts",
                column: "ControlAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_Warehouses_WarehouseId",
                table: "Bins",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashBoxes_Accounts_ControlAccountId",
                table: "CashBoxes",
                column: "ControlAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CashBoxes_Companies_BusinessId",
                table: "CashBoxes",
                column: "BusinessId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Businesses_BusinessId",
                table: "Departments",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Bins_BinId",
                table: "Inventories",
                column: "BinId",
                principalTable: "Bins",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Bins_BinId1",
                table: "Inventories",
                column: "BinId1",
                principalTable: "Bins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductId",
                table: "Inventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId",
                table: "Inventories",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Bins_BinId",
                table: "InventoryMovements",
                column: "BinId",
                principalTable: "Bins",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Inventories_InventoryId",
                table: "InventoryMovements",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Products_ProductId",
                table: "InventoryMovements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Warehouses_WarehouseId",
                table: "InventoryMovements",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalLines_Accounts_AccountId",
                table: "JournalLines",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalVouchers_FiscalPeriods_FiscalPeriodId",
                table: "JournalVouchers",
                column: "FiscalPeriodId",
                principalTable: "FiscalPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalVouchers_FiscalYears_FiscalYearId",
                table: "JournalVouchers",
                column: "FiscalYearId",
                principalTable: "FiscalYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Models_ModelId1",
                table: "Products",
                column: "ModelId1",
                principalTable: "Models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Trims_TrimId",
                table: "Products",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Trims_TrimId1",
                table: "Products",
                column: "TrimId1",
                principalTable: "Trims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasure_BaseUomId",
                table: "Products",
                column: "BaseUomId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasure_UnitOfMeasureId",
                table: "Products",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Years_YearId",
                table: "Products",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBillLines_Accounts_AccountId",
                table: "PurchaseBillLines",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBills_Vendors_VendorId",
                table: "PurchaseBills",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBills_Vendors_VendorId1",
                table: "PurchaseBills",
                column: "VendorId1",
                principalTable: "Vendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId1",
                table: "RolePermissions",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_ParentRoleId",
                table: "Roles",
                column: "ParentRoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasure_UnitOfMeasure_BaseUnitId",
                table: "UnitOfMeasure",
                column: "BaseUnitId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasure_UnitOfMeasure_UnitOfMeasureId",
                table: "UnitOfMeasure",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UomConversions_UnitOfMeasure_FromUnitId",
                table: "UomConversions",
                column: "FromUnitId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UomConversions_UnitOfMeasure_ToUnitId",
                table: "UomConversions",
                column: "ToUnitId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId1",
                table: "UserProfiles",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Businesses_BusinessId",
                table: "Users",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId1",
                table: "Users",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_Users_UserId1",
                table: "UserSettings",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Accounts_ControlAccountId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bins_Warehouses_WarehouseId",
                table: "Bins");

            migrationBuilder.DropForeignKey(
                name: "FK_CashBoxes_Accounts_ControlAccountId",
                table: "CashBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CashBoxes_Companies_BusinessId",
                table: "CashBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Businesses_BusinessId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Bins_BinId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Bins_BinId1",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Bins_BinId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Inventories_InventoryId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Products_ProductId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Warehouses_WarehouseId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalLines_Accounts_AccountId",
                table: "JournalLines");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalVouchers_FiscalPeriods_FiscalPeriodId",
                table: "JournalVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalVouchers_FiscalYears_FiscalYearId",
                table: "JournalVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Models_ModelId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Trims_TrimId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Trims_TrimId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasure_BaseUomId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasure_UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Years_YearId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBillLines_Accounts_AccountId",
                table: "PurchaseBillLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBills_Vendors_VendorId",
                table: "PurchaseBills");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBills_Vendors_VendorId1",
                table: "PurchaseBills");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId1",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_ParentRoleId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasure_UnitOfMeasure_BaseUnitId",
                table: "UnitOfMeasure");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasure_UnitOfMeasure_UnitOfMeasureId",
                table: "UnitOfMeasure");

            migrationBuilder.DropForeignKey(
                name: "FK_UomConversions_UnitOfMeasure_FromUnitId",
                table: "UomConversions");

            migrationBuilder.DropForeignKey(
                name: "FK_UomConversions_UnitOfMeasure_ToUnitId",
                table: "UomConversions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId1",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Businesses_BusinessId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Users_UserId1",
                table: "UserSettings");

            migrationBuilder.DropTable(
                name: "AccJournalApprovalLogs");

            migrationBuilder.DropTable(
                name: "AccJournalLines");

            migrationBuilder.DropTable(
                name: "AccOpeningBalances");

            migrationBuilder.DropTable(
                name: "AccPostingRules");

            migrationBuilder.DropTable(
                name: "AccSettings");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ApBillLines");

            migrationBuilder.DropTable(
                name: "ApprovalStages");

            migrationBuilder.DropTable(
                name: "ApSettlements");

            migrationBuilder.DropTable(
                name: "ArInvoiceLines");

            migrationBuilder.DropTable(
                name: "ArSettlements");

            migrationBuilder.DropTable(
                name: "BankReconciliations");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "BudgetLines");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "CashBoxTransactions");

            migrationBuilder.DropTable(
                name: "CashBoxTransfers");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "ClosingRuns");

            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "CustomerSurveys");

            migrationBuilder.DropTable(
                name: "EmailResponses");

            migrationBuilder.DropTable(
                name: "EmployeeAttendance");

            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "FaDepreciationEntries");

            migrationBuilder.DropTable(
                name: "GeneralLedgerEntries");

            migrationBuilder.DropTable(
                name: "GrnLines");

            migrationBuilder.DropTable(
                name: "InstrumentFlows");

            migrationBuilder.DropTable(
                name: "InventoryBarcodes");

            migrationBuilder.DropTable(
                name: "InventoryBins");

            migrationBuilder.DropTable(
                name: "InventoryCostLayers");

            migrationBuilder.DropTable(
                name: "InventoryIssueLines");

            migrationBuilder.DropTable(
                name: "InventoryLevels");

            migrationBuilder.DropTable(
                name: "InventoryReservations");

            migrationBuilder.DropTable(
                name: "InventoryTransferLines");

            migrationBuilder.DropTable(
                name: "JournalApprovalLogs");

            migrationBuilder.DropTable(
                name: "JournalEntryLines");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "LoginPolicies");

            migrationBuilder.DropTable(
                name: "MaintenanceEquipment");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "MaintenanceSchedules");

            migrationBuilder.DropTable(
                name: "MaintenanceWorkOrders");

            migrationBuilder.DropTable(
                name: "PasswordPolicies");

            migrationBuilder.DropTable(
                name: "PoOrderLines");

            migrationBuilder.DropTable(
                name: "PriceChanges");

            migrationBuilder.DropTable(
                name: "PriceHistories");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductFiles");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "PurchasePayments");

            migrationBuilder.DropTable(
                name: "PurchaseReceiptLines");

            migrationBuilder.DropTable(
                name: "PurchaseReturnLines");

            migrationBuilder.DropTable(
                name: "RateLimits");

            migrationBuilder.DropTable(
                name: "RepairParts");

            migrationBuilder.DropTable(
                name: "RoleOperations");

            migrationBuilder.DropTable(
                name: "SalePayments");

            migrationBuilder.DropTable(
                name: "SalesOrderItems");

            migrationBuilder.DropTable(
                name: "SalesReturnLines");

            migrationBuilder.DropTable(
                name: "SecurityAudits");

            migrationBuilder.DropTable(
                name: "SessionAudits");

            migrationBuilder.DropTable(
                name: "SmsLogs");

            migrationBuilder.DropTable(
                name: "SubTasks");

            migrationBuilder.DropTable(
                name: "SurveyQuestionResponses");

            migrationBuilder.DropTable(
                name: "TaskActivities");

            migrationBuilder.DropTable(
                name: "TaskAttachments");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "TaskProgressUpdates");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TicketCategories");

            migrationBuilder.DropTable(
                name: "TicketResponses");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TreasurySettings");

            migrationBuilder.DropTable(
                name: "Trims");

            migrationBuilder.DropTable(
                name: "UserActivityLogs");

            migrationBuilder.DropTable(
                name: "UserOrgUnits");

            migrationBuilder.DropTable(
                name: "VehicleCompatibilities");

            migrationBuilder.DropTable(
                name: "VendorOrders");

            migrationBuilder.DropTable(
                name: "WarrantyClaims");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "ApprovalWorkflows");

            migrationBuilder.DropTable(
                name: "ApBills");

            migrationBuilder.DropTable(
                name: "ApPayments");

            migrationBuilder.DropTable(
                name: "ArReceipts");

            migrationBuilder.DropTable(
                name: "AccDimensionValues");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "EmailCampaigns");

            migrationBuilder.DropTable(
                name: "AccJournalVouchers");

            migrationBuilder.DropTable(
                name: "FaAssets");

            migrationBuilder.DropTable(
                name: "FaCategories");

            migrationBuilder.DropTable(
                name: "FaDepreciationRuns");

            migrationBuilder.DropTable(
                name: "GrnReceipts");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "InventoryIssueNotes");

            migrationBuilder.DropTable(
                name: "InventoryTransferNotes");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PoOrders");

            migrationBuilder.DropTable(
                name: "PurchaseReturns");

            migrationBuilder.DropTable(
                name: "RepairServices");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "SalesReturns");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "SurveyResponses");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "OrgUnits");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.DropTable(
                name: "AccDimensions");

            migrationBuilder.DropTable(
                name: "AccFiscalPeriods");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PurchaseReceipts");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "ArInvoices");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "AccFiscalYears");

            migrationBuilder.DropTable(
                name: "ApVendors");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "ArCustomers");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_UserId1",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_DisplayName",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ParentRoleId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_RoleId_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_RoleId1",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_Action",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_Controller",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_Group",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_Name",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_Code",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_Code",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_Email",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Users_BusinessId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_UserId1",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UomConversions_IsActive",
                table: "UomConversions");

            migrationBuilder.DropIndex(
                name: "IX_SystemSettings_Category_Key_BusinessId",
                table: "SystemSettings");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_CustomerId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_InvoiceDate",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_Status",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLines_AccountId",
                table: "SalesInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBills_BillDate",
                table: "PurchaseBills");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBills_Number",
                table: "PurchaseBills");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBills_Status",
                table: "PurchaseBills");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBills_VendorId",
                table: "PurchaseBills");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBills_VendorId1",
                table: "PurchaseBills");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBillLines_AccountId",
                table: "PurchaseBillLines");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TrimId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TrimId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_YearId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_JournalVouchers_FiscalPeriodId",
                table: "JournalVouchers");

            migrationBuilder.DropIndex(
                name: "IX_JournalVouchers_FiscalYearId",
                table: "JournalVouchers");

            migrationBuilder.DropIndex(
                name: "IX_JournalVouchers_Status",
                table: "JournalVouchers");

            migrationBuilder.DropIndex(
                name: "IX_JournalVouchers_Type",
                table: "JournalVouchers");

            migrationBuilder.DropIndex(
                name: "IX_JournalVouchers_VoucherDate",
                table: "JournalVouchers");

            migrationBuilder.DropIndex(
                name: "IX_InventoryMovements_BinId",
                table: "InventoryMovements");

            migrationBuilder.DropIndex(
                name: "IX_InventoryMovements_MovementType",
                table: "InventoryMovements");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_BinId1",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_FiscalYears_Code",
                table: "FiscalYears");

            migrationBuilder.DropIndex(
                name: "IX_FiscalYears_YearEnd",
                table: "FiscalYears");

            migrationBuilder.DropIndex(
                name: "IX_FiscalYears_YearStart",
                table: "FiscalYears");

            migrationBuilder.DropIndex(
                name: "IX_FiscalPeriods_EndDate",
                table: "FiscalPeriods");

            migrationBuilder.DropIndex(
                name: "IX_FiscalPeriods_StartDate",
                table: "FiscalPeriods");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BusinessId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Code",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Code",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Companies_NationalId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RegistrationNumber",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Code",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CashTransactions_Type",
                table: "CashTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CashBoxes_ControlAccountId",
                table: "CashBoxes");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Code",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Name",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_AccountNumber",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_Iban",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Code",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Name",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasure",
                table: "UnitOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_UnitOfMeasure_Code",
                table: "UnitOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_UnitOfMeasure_UnitOfMeasureId",
                table: "UnitOfMeasure");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ParentRoleId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "WarehouseType",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "EconomicCode",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PreferredCurrency",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VendorType",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InternalPhone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PreferredLanguage",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "ConversionFactor",
                table: "UomConversions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UomConversions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UomConversions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UomConversions");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IsEditable",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "VendorId1",
                table: "PurchaseBills");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DefaultUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsManufacturable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPurchasable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsSellable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaxStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModelId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TrimId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TrimId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UomId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WholesalePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BalanceAverageCost",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "BalanceQuantity",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "BinId",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "MovementType",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "InventoryMovements");

            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "BinId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "MaxQuantity",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "MinQuantity",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "QuantityAvailable",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "QuantityOnHand",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "QuantityReserved",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ReorderLevel",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentType",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "HierarchyPath",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EconomicCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PreferredCurrency",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "CashTransactions");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "CashTransactions");

            migrationBuilder.DropColumn(
                name: "ReferenceType",
                table: "CashTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "CashTransactions");

            migrationBuilder.DropColumn(
                name: "ControlAccountId",
                table: "CashBoxes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "BinType",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "CapacityUnit",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "AccountHolderName",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BankCode",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BranchAddress",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BranchPhone",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "InitialBalance",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "UnitOfMeasure");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "UnitOfMeasure");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "UnitOfMeasure");

            migrationBuilder.DropColumn(
                name: "UomType",
                table: "UnitOfMeasure");

            migrationBuilder.EnsureSchema(
                name: "GL");

            migrationBuilder.EnsureSchema(
                name: "Treasury");

            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.EnsureSchema(
                name: "AR");

            migrationBuilder.EnsureSchema(
                name: "AP");

            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouses",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendors",
                newSchema: "AP");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "UserProfiles",
                newSchema: "Users");

            migrationBuilder.RenameTable(
                name: "UomConversions",
                newName: "UomConversions",
                newSchema: "Product");

            migrationBuilder.RenameTable(
                name: "SystemSettings",
                newName: "SystemSettings",
                newSchema: "System");

            migrationBuilder.RenameTable(
                name: "SalesInvoices",
                newName: "SalesInvoices",
                newSchema: "AR");

            migrationBuilder.RenameTable(
                name: "SalesInvoiceLines",
                newName: "SalesInvoiceLines",
                newSchema: "AR");

            migrationBuilder.RenameTable(
                name: "PurchaseBills",
                newName: "PurchaseBills",
                newSchema: "AP");

            migrationBuilder.RenameTable(
                name: "PurchaseBillLines",
                newName: "PurchaseBillLines",
                newSchema: "AP");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "Product");

            migrationBuilder.RenameTable(
                name: "JournalVouchers",
                newName: "JournalVouchers",
                newSchema: "GL");

            migrationBuilder.RenameTable(
                name: "JournalLines",
                newName: "JournalLines",
                newSchema: "GL");

            migrationBuilder.RenameTable(
                name: "InventoryMovements",
                newName: "InventoryMovements",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventories",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "FiscalYears",
                newName: "FiscalYears",
                newSchema: "GL");

            migrationBuilder.RenameTable(
                name: "FiscalPeriods",
                newName: "FiscalPeriods",
                newSchema: "GL");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Departments",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "AR");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companies",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "Product");

            migrationBuilder.RenameTable(
                name: "CashTransactions",
                newName: "CashTransactions",
                newSchema: "Treasury");

            migrationBuilder.RenameTable(
                name: "CashBoxes",
                newName: "CashBoxes",
                newSchema: "Treasury");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brands",
                newSchema: "Product");

            migrationBuilder.RenameTable(
                name: "Bins",
                newName: "Bins",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                newName: "BankAccounts",
                newSchema: "Treasury");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Accounts",
                newSchema: "GL");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasure",
                newName: "UnitsOfMeasure",
                newSchema: "Product");

            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "Inventory",
                table: "Warehouses",
                newName: "AddressStreet");

            migrationBuilder.RenameColumn(
                name: "CapacityUnit",
                schema: "Inventory",
                table: "Warehouses",
                newName: "AddressPostalCode");

            migrationBuilder.RenameColumn(
                name: "ToUnitId",
                schema: "Product",
                table: "UomConversions",
                newName: "ToUomId");

            migrationBuilder.RenameColumn(
                name: "FromUnitId",
                schema: "Product",
                table: "UomConversions",
                newName: "FromUomId");

            migrationBuilder.RenameIndex(
                name: "IX_UomConversions_ToUnitId",
                schema: "Product",
                table: "UomConversions",
                newName: "IX_UomConversions_ToUomId");

            migrationBuilder.RenameIndex(
                name: "IX_UomConversions_FromUnitId_ToUnitId",
                schema: "Product",
                table: "UomConversions",
                newName: "IX_UomConversions_From_To");

            migrationBuilder.RenameIndex(
                name: "IX_SalesInvoiceLines_SalesInvoiceId",
                schema: "AR",
                table: "SalesInvoiceLines",
                newName: "IX_SalesInvoiceLines_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseBillLines_PurchaseBillId",
                schema: "AP",
                table: "PurchaseBillLines",
                newName: "IX_PurchaseBillLines_BillId");

            migrationBuilder.RenameColumn(
                name: "Weight_Value",
                schema: "Product",
                table: "Products",
                newName: "WeightValue");

            migrationBuilder.RenameColumn(
                name: "Weight_Unit",
                schema: "Product",
                table: "Products",
                newName: "WeightUnit");

            migrationBuilder.RenameColumn(
                name: "SellingPrice_Currency",
                schema: "Product",
                table: "Products",
                newName: "SellingCurrency");

            migrationBuilder.RenameColumn(
                name: "SellingPrice_Amount",
                schema: "Product",
                table: "Products",
                newName: "SellingPrice");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice_Currency",
                schema: "Product",
                table: "Products",
                newName: "PurchaseCurrency");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice_Amount",
                schema: "Product",
                table: "Products",
                newName: "PurchasePrice");

            migrationBuilder.RenameColumn(
                name: "Dimensions_Width",
                schema: "Product",
                table: "Products",
                newName: "DimensionWidth");

            migrationBuilder.RenameColumn(
                name: "Dimensions_Unit",
                schema: "Product",
                table: "Products",
                newName: "DimensionUnit");

            migrationBuilder.RenameColumn(
                name: "Dimensions_Length",
                schema: "Product",
                table: "Products",
                newName: "DimensionLength");

            migrationBuilder.RenameColumn(
                name: "Dimensions_Height",
                schema: "Product",
                table: "Products",
                newName: "DimensionHeight");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                schema: "Inventory",
                table: "Inventories",
                newName: "LastMovementDate");

            migrationBuilder.RenameIndex(
                name: "IX_FiscalPeriods_FiscalYearId_PeriodNo",
                schema: "GL",
                table: "FiscalPeriods",
                newName: "IX_FiscalPeriods_Year_Period");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber_Value",
                schema: "Identity",
                table: "Companies",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber_LocalNumber",
                schema: "Identity",
                table: "Companies",
                newName: "PhoneLocalNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber_CountryCode",
                schema: "Identity",
                table: "Companies",
                newName: "PhoneCountryCode");

            migrationBuilder.RenameColumn(
                name: "Email_Value",
                schema: "Identity",
                table: "Companies",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                schema: "Identity",
                table: "Companies",
                newName: "AddressStreet");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                schema: "Identity",
                table: "Companies",
                newName: "AddressState");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                schema: "Identity",
                table: "Companies",
                newName: "AddressPostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                schema: "Identity",
                table: "Companies",
                newName: "AddressCountry");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                schema: "Identity",
                table: "Companies",
                newName: "AddressCity");

            migrationBuilder.RenameColumn(
                name: "Amount_Currency",
                schema: "Treasury",
                table: "CashTransactions",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "Amount_Amount",
                schema: "Treasury",
                table: "CashTransactions",
                newName: "Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Bins_WarehouseId_Code",
                schema: "Inventory",
                table: "Bins",
                newName: "IX_Bins_Warehouse_Code");

            migrationBuilder.RenameColumn(
                name: "AccountName",
                schema: "Treasury",
                table: "BankAccounts",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasure_Type",
                schema: "Product",
                table: "UnitsOfMeasure",
                newName: "IX_UnitsOfMeasure_Type");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasure_Name",
                schema: "Product",
                table: "UnitsOfMeasure",
                newName: "IX_UnitsOfMeasure_Name");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasure_BaseUnitId",
                schema: "Product",
                table: "UnitsOfMeasure",
                newName: "IX_UnitsOfMeasure_BaseUnitId");

            migrationBuilder.AlterColumn<string>(
                name: "Timezone",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TimeFormat",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Theme",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultCurrency",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "DateFormat",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalSettings",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resource",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "default",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressCountry",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressState",
                schema: "Inventory",
                table: "Warehouses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Latitude",
                schema: "Inventory",
                table: "Warehouses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Longitude",
                schema: "Inventory",
                table: "Warehouses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "AP",
                table: "Vendors",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "PhoneCountryCode",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneLocalNumber",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Users",
                table: "UserProfiles",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Users",
                table: "UserProfiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Factor",
                schema: "Product",
                table: "UomConversions",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "System",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                schema: "System",
                table: "SystemSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "System",
                table: "SystemSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                schema: "System",
                table: "SystemSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "default",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "AR",
                table: "SalesInvoices",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "draft",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "AR",
                table: "SalesInvoices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "AR",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                schema: "AR",
                table: "SalesInvoices",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "AR",
                table: "SalesInvoiceLines",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "AR",
                table: "SalesInvoiceLines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "AP",
                table: "PurchaseBills",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "draft",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "AP",
                table: "PurchaseBills",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "AP",
                table: "PurchaseBills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BillDate",
                schema: "AP",
                table: "PurchaseBills",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "AP",
                table: "PurchaseBillLines",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "AP",
                table: "PurchaseBillLines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                schema: "Product",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Product",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Product",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellingCurrency",
                schema: "Product",
                table: "Products",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                defaultValue: "IRR",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseCurrency",
                schema: "Product",
                table: "Products",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                defaultValue: "IRR",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VoucherDate",
                schema: "GL",
                table: "JournalVouchers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "GL",
                table: "JournalVouchers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "JV",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "GL",
                table: "JournalVouchers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "draft",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "GL",
                table: "JournalVouchers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "GL",
                table: "JournalVouchers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalStatus",
                schema: "GL",
                table: "JournalVouchers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "GL",
                table: "JournalLines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceType",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InventoryId",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceBefore",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceAfter",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalValueCurrency",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                defaultValue: "IRR");

            migrationBuilder.AddColumn<string>(
                name: "UnitCostCurrency",
                schema: "Inventory",
                table: "InventoryMovements",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                defaultValue: "IRR");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                schema: "Inventory",
                table: "Inventories",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<string>(
                name: "AverageCostCurrency",
                schema: "Inventory",
                table: "Inventories",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                defaultValue: "IRR");

            migrationBuilder.AddColumn<decimal>(
                name: "LastPurchaseCost",
                schema: "Inventory",
                table: "Inventories",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastPurchaseCostCurrency",
                schema: "Inventory",
                table: "Inventories",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                defaultValue: "IRR");

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearStart",
                schema: "GL",
                table: "FiscalYears",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearEnd",
                schema: "GL",
                table: "FiscalYears",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "GL",
                table: "FiscalYears",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "GL",
                table: "FiscalYears",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "GL",
                table: "FiscalPeriods",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "open",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "GL",
                table: "FiscalPeriods",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "GL",
                table: "FiscalPeriods",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                schema: "Identity",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "Identity",
                table: "Departments",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                schema: "Identity",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "AR",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                schema: "Identity",
                table: "Companies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Identity",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                schema: "Identity",
                table: "Companies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Longitude",
                schema: "Identity",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Latitude",
                schema: "Identity",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneLocalNumber",
                schema: "Identity",
                table: "Companies",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneCountryCode",
                schema: "Identity",
                table: "Companies",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Identity",
                table: "Companies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressStreet",
                schema: "Identity",
                table: "Companies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                schema: "Product",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "Product",
                table: "Categories",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                schema: "Product",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Treasury",
                table: "CashTransactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Treasury",
                table: "CashTransactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPosted",
                schema: "Treasury",
                table: "CashTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Treasury",
                table: "CashTransactions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                schema: "Treasury",
                table: "CashTransactions",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Treasury",
                table: "CashBoxes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Treasury",
                table: "CashBoxes",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                schema: "Treasury",
                table: "CashBoxes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "default",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                schema: "Product",
                table: "Brands",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                schema: "Product",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                schema: "Product",
                table: "Brands",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "Bins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Inventory",
                table: "Bins",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Inventory",
                table: "Bins",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Treasury",
                table: "BankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                schema: "Treasury",
                table: "BankAccounts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                schema: "Treasury",
                table: "BankAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "default",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "GL",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "GL",
                table: "Accounts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessId",
                schema: "GL",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "default",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Precision",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSystemDefault",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ConversionFactor",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Product",
                table: "UnitsOfMeasure",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfMeasure",
                schema: "Product",
                table: "UnitsOfMeasure",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Business_Code",
                schema: "Inventory",
                table: "Warehouses",
                columns: new[] { "BusinessId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_BusinessId",
                schema: "Inventory",
                table: "Warehouses",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Name",
                schema: "Inventory",
                table: "Warehouses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Code",
                schema: "AP",
                table: "Vendors",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                schema: "Identity",
                table: "Users",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_Business_Category_Key",
                schema: "System",
                table: "SystemSettings",
                columns: new[] { "BusinessId", "Category", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_Customer_Date",
                schema: "AR",
                table: "SalesInvoices",
                columns: new[] { "CustomerId", "InvoiceDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBills_Vendor_Date",
                schema: "AP",
                table: "PurchaseBills",
                columns: new[] { "VendorId", "BillDate" });

            migrationBuilder.CreateIndex(
                name: "IX_JournalVouchers_Year_Date",
                schema: "GL",
                table: "JournalVouchers",
                columns: new[] { "FiscalYearId", "VoucherDate" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_Product_Warehouse_Date",
                schema: "Inventory",
                table: "InventoryMovements",
                columns: new[] { "ProductId", "WarehouseId", "MovementDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductId",
                schema: "Inventory",
                table: "Inventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_Code",
                schema: "GL",
                table: "FiscalYears",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Company_Level_Sort",
                schema: "Identity",
                table: "Departments",
                columns: new[] { "CompanyId", "Level", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId_Code",
                schema: "Identity",
                table: "Departments",
                columns: new[] { "CompanyId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId_Name",
                schema: "Identity",
                table: "Departments",
                columns: new[] { "CompanyId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                schema: "AR",
                table: "Customers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_EconomicCode",
                schema: "Identity",
                table: "Companies",
                column: "EconomicCode",
                unique: true,
                filter: "[EconomicCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_NationalId",
                schema: "Identity",
                table: "Companies",
                column: "NationalId",
                unique: true,
                filter: "[NationalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RegistrationNumber",
                schema: "Identity",
                table: "Companies",
                column: "RegistrationNumber",
                unique: true,
                filter: "[RegistrationNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Level_SortOrder",
                schema: "Product",
                table: "Categories",
                columns: new[] { "Level", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Path",
                schema: "Product",
                table: "Categories",
                column: "Path");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxes_Business_Name",
                schema: "Treasury",
                table: "CashBoxes",
                columns: new[] { "BusinessId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                schema: "Product",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_SortOrder",
                schema: "Product",
                table: "Brands",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_Business_Name",
                schema: "Treasury",
                table: "BankAccounts",
                columns: new[] { "BusinessId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Business_Code",
                schema: "GL",
                table: "Accounts",
                columns: new[] { "BusinessId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BusinessId",
                schema: "GL",
                table: "Accounts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfMeasure_Code",
                schema: "Product",
                table: "UnitsOfMeasure",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfMeasure_Symbol",
                schema: "Product",
                table: "UnitsOfMeasure",
                column: "Symbol",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Accounts_ControlAccountId",
                schema: "Treasury",
                table: "BankAccounts",
                column: "ControlAccountId",
                principalSchema: "GL",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_Warehouses_WarehouseId",
                schema: "Inventory",
                table: "Bins",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ManagerId",
                schema: "Identity",
                table: "Departments",
                column: "ManagerId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Bins_BinId",
                schema: "Inventory",
                table: "Inventories",
                column: "BinId",
                principalSchema: "Inventory",
                principalTable: "Bins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductId",
                schema: "Inventory",
                table: "Inventories",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId",
                schema: "Inventory",
                table: "Inventories",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Inventories_InventoryId",
                schema: "Inventory",
                table: "InventoryMovements",
                column: "InventoryId",
                principalSchema: "Inventory",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Products_ProductId",
                schema: "Inventory",
                table: "InventoryMovements",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Warehouses_WarehouseId",
                schema: "Inventory",
                table: "InventoryMovements",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitsOfMeasure_BaseUomId",
                schema: "Product",
                table: "Products",
                column: "BaseUomId",
                principalSchema: "Product",
                principalTable: "UnitsOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsOfMeasure_UnitsOfMeasure_BaseUnitId",
                schema: "Product",
                table: "UnitsOfMeasure",
                column: "BaseUnitId",
                principalSchema: "Product",
                principalTable: "UnitsOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UomConversions_UnitsOfMeasure_FromUomId",
                schema: "Product",
                table: "UomConversions",
                column: "FromUomId",
                principalSchema: "Product",
                principalTable: "UnitsOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UomConversions_UnitsOfMeasure_ToUomId",
                schema: "Product",
                table: "UomConversions",
                column: "ToUomId",
                principalSchema: "Product",
                principalTable: "UnitsOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "Identity",
                table: "Users",
                column: "CompanyId",
                principalSchema: "Identity",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                schema: "Identity",
                table: "Users",
                column: "DepartmentId",
                principalSchema: "Identity",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
