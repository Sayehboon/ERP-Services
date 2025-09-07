# ساختار کامل کنترلرهای سیستم دیناوین ERP

## نمای کلی
تمام کنترلرهای سیستم به صورت منظم در پوشه‌های جداگانه سازماندهی شده‌اند و از `BaseController` مشتق می‌شوند.

## ساختار کامل پوشه‌ها

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
├── AccountsController.cs       # مدیریت حساب‌ها
├── AccountingSettingsController.cs # تنظیمات حسابداری
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

### 10. TaskManagement (مدیریت وظایف)
```
TaskManagement/
├── ProjectsController.cs       # مدیریت پروژه‌ها
└── TasksController.cs          # مدیریت وظایف
```

### 11. Customers (مشتریان)
```
Customers/
└── CustomersController.cs      # مدیریت مشتریان
```

### 12. Vendors (تامین‌کنندگان)
```
Vendors/
└── VendorsController.cs        # مدیریت تامین‌کنندگان
```

### 13. Financial (مالی)
```
Financial/
├── BankAccountsController.cs   # مدیریت حساب‌های بانکی
└── CashBoxesController.cs      # مدیریت صندوق‌های نقدی
```

### 14. Settings (تنظیمات)
```
Settings/
└── SystemSettingsController.cs # تنظیمات سیستم
```

## کنترلرهای باقی‌مانده برای سازماندهی

کنترلرهای زیر هنوز در پوشه اصلی قرار دارند و نیاز به سازماندهی دارند:

### Accounting (حسابداری)
- `FiscalPeriodsController.cs` → `Accounting/FiscalPeriodsController.cs`
- `FiscalYearsController.cs` → `Accounting/FiscalYearsController.cs`
- `JournalVouchersController.cs` → `Accounting/JournalVouchersController.cs`

### Financial (مالی)
- `CashTransactionsController.cs` → `Financial/CashTransactionsController.cs`

### Sales (فروش)
- `SalesInvoicesController.cs` → `Sales/SalesInvoicesController.cs`

### Purchase (خرید)
- `PurchaseBillsController.cs` → `Purchase/PurchaseBillsController.cs`

### Inventory (موجودی)
- `BinsController.cs` → `Inventory/BinsController.cs`
- `InventoryMovementsController.cs` → `Inventory/InventoryMovementsController.cs`

### Product (محصولات)
- `UomsController.cs` → `Product/UomsController.cs`
- `UomConversionsController.cs` → `Product/UomConversionsController.cs`

### System (سیستم)
- `CompaniesController.cs` → `System/CompaniesController.cs`
- `UserProfilesController.cs` → `System/UserProfilesController.cs`

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

## آمار کلی

- **تعداد کل کنترلرها**: 35+ کنترلر
- **تعداد پوشه‌های سیستم**: 14 پوشه
- **کنترلرهای سازماندهی شده**: 25+ کنترلر
- **کنترلرهای باقی‌مانده**: 10+ کنترلر

## مراحل بعدی

1. ✅ سازماندهی کنترلرهای اصلی
2. ✅ ایجاد BaseController
3. ✅ پیاده‌سازی CQRS Pattern
4. 🔄 سازماندهی کنترلرهای باقی‌مانده
5. ⏳ پیاده‌سازی Commands و Queries
6. ⏳ تست تمام API ها
7. ⏳ اتصال Frontend به API های جدید

## نکات مهم

- تمام کنترلرها از `BaseController` مشتق می‌شوند
- هر کنترلر در پوشه مربوط به سیستم خود قرار دارد
- تمام متدها دارای مستندسازی فارسی هستند
- از الگوی CQRS برای جداسازی عملیات خواندن و نوشتن استفاده می‌شود
- مدیریت خطا به صورت یکپارچه انجام می‌شود
