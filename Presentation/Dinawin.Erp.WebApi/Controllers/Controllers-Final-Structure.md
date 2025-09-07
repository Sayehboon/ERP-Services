# ساختار نهایی کنترلرهای سیستم دیناوین ERP

## نمای کلی
تمام کنترلرهای سیستم به صورت منظم در پوشه‌های جداگانه سازماندهی شده‌اند و از `BaseController` مشتق می‌شوند.

## ساختار پوشه‌ها

### 1. CRM (مدیریت ارتباط با مشتری)
```
CRM/
├── ActivitiesController.cs      # مدیریت فعالیت‌ها
├── ContactsController.cs        # مدیریت مخاطبین
├── LeadsController.cs          # مدیریت لیدها
├── OpportunitiesController.cs   # مدیریت فرصت‌ها
└── TicketsController.cs        # مدیریت تیکت‌ها
```

### 2. Sales (فروش)
```
Sales/
└── SalesOrdersController.cs    # مدیریت سفارشات فروش
```

### 3. Purchase (خرید)
```
Purchase/
└── PurchaseOrdersController.cs # مدیریت سفارشات خرید
```

### 4. Product (محصولات)
```
Product/
├── BrandsController.cs         # مدیریت برندها
├── CategoriesController.cs     # مدیریت دسته‌بندی‌ها
├── ModelsController.cs         # مدیریت مدل‌ها
├── ProductsController.cs       # مدیریت محصولات
├── TrimsController.cs          # مدیریت تریم‌ها
├── UnitsController.cs          # مدیریت واحدها
└── YearsController.cs          # مدیریت سال‌ها
```

### 5. Inventory (موجودی)
```
Inventory/
├── InventoryController.cs      # مدیریت موجودی
└── WarehousesController.cs     # مدیریت انبارها
```

### 6. Accounting (حسابداری)
```
Accounting/
├── ChartOfAccountsController.cs # مدیریت حساب‌های کل
└── JournalEntriesController.cs  # مدیریت سندهای حسابداری
```

### 7. HR (منابع انسانی)
```
HR/
├── DepartmentsController.cs    # مدیریت بخش‌ها
└── EmployeesController.cs      # مدیریت کارمندان
```

### 8. System (سیستم)
```
System/
├── RolesController.cs          # مدیریت نقش‌ها
├── SampleDataController.cs     # مدیریت داده‌های نمونه
└── UsersController.cs          # مدیریت کاربران سیستم
```

### 9. Dashboard (داشبورد)
```
Dashboard/
└── DashboardController.cs      # مدیریت داشبورد و آمار
```

## ویژگی‌های مشترک

### BaseController
تمام کنترلرها از `BaseController` مشتق می‌شوند که شامل:
- تزریق `IMediator` برای CQRS
- متدهای استاندارد پاسخ (`Success`, `Error`, `Created`, `Updated`, `Deleted`)
- مدیریت خطاهای یکپارچه
- مستندسازی کامل

### الگوی CQRS
تمام کنترلرها از الگوی CQRS استفاده می‌کنند:
- Commands برای عملیات نوشتن (Create, Update, Delete)
- Queries برای عملیات خواندن (Get, Search, List)

### مستندسازی
تمام متدها دارای مستندسازی کامل به زبان فارسی هستند.

## کنترلرهای باقی‌مانده
کنترلرهای زیر هنوز در پوشه اصلی قرار دارند و نیاز به سازماندهی دارند:
- AccountingSettingsController.cs
- AccountsController.cs
- BankAccountsController.cs
- BinsController.cs
- CashBoxesController.cs
- CashTransactionsController.cs
- CompaniesController.cs
- CustomersController.cs
- FiscalPeriodsController.cs
- FiscalYearsController.cs
- InventoryMovementsController.cs
- JournalVouchersController.cs
- PurchaseBillsController.cs
- SalesInvoicesController.cs
- SystemSettingsController.cs
- UomConversionsController.cs
- UomsController.cs
- UserProfilesController.cs
- VendorsController.cs

## مراحل بعدی
1. سازماندهی کنترلرهای باقی‌مانده در پوشه‌های مناسب
2. پیاده‌سازی Commands و Queries مربوط به هر کنترلر
3. تست تمام API ها
4. اتصال Frontend به API های جدید
