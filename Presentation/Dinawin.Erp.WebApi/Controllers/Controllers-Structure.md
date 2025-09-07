# Controllers Structure Documentation

## مستندات ساختار کنترلرها

### مقدمه
کنترلرهای API بر اساس سیستم‌های مختلف سازماندهی شده‌اند. هر سیستم در پوشه جداگانه‌ای قرار دارد و از `BaseController` ارث‌بری می‌کند.

### ساختار پوشه‌ها

```
Controllers/
├── BaseController.cs                    # کلاس پایه تمام کنترلرها
├── Controllers-Structure.md            # این فایل مستندات
├── README.md                           # مستندات BaseController
│
├── CRM/                                # سیستم مدیریت ارتباط با مشتری
│   ├── ActivitiesController.cs         # مدیریت فعالیت‌ها
│   ├── ContactsController.cs           # مدیریت مخاطبین
│   ├── LeadsController.cs              # مدیریت سرنخ‌ها
│   ├── OpportunitiesController.cs      # مدیریت فرصت‌ها
│   └── TicketsController.cs            # مدیریت تیکت‌ها
│
├── Sales/                              # سیستم فروش
│   └── SalesOrdersController.cs        # مدیریت سفارشات فروش
│
├── Purchase/                           # سیستم خرید
│   └── PurchaseOrdersController.cs     # مدیریت سفارشات خرید
│
├── Product/                            # سیستم مدیریت محصولات
│   ├── CategoriesController.cs         # مدیریت دسته‌بندی‌ها
│   ├── BrandsController.cs             # مدیریت برندها
│   ├── ModelsController.cs             # مدیریت مدل‌ها
│   ├── TrimsController.cs              # مدیریت تریم‌ها
│   ├── YearsController.cs              # مدیریت سال‌ها
│   ├── UnitsController.cs              # مدیریت واحدها
│   └── ProductsController.cs           # مدیریت محصولات
│
├── Inventory/                          # سیستم موجودی
│   ├── WarehousesController.cs         # مدیریت انبارها
│   ├── InventoryController.cs          # مدیریت موجودی
│   ├── InventoryMovementsController.cs # مدیریت حرکات موجودی
│   └── BinsController.cs               # مدیریت قفسه‌ها
│
├── Accounting/                         # سیستم حسابداری
│   ├── AccountsController.cs           # مدیریت حساب‌ها
│   ├── JournalVouchersController.cs    # مدیریت سندهای حسابداری
│   ├── CashBoxesController.cs          # مدیریت صندوق‌ها
│   ├── CashTransactionsController.cs   # مدیریت تراکنش‌های نقدی
│   ├── BankAccountsController.cs       # مدیریت حساب‌های بانکی
│   ├── FiscalYearsController.cs        # مدیریت سال‌های مالی
│   ├── FiscalPeriodsController.cs      # مدیریت دوره‌های مالی
│   ├── PurchaseBillsController.cs      # مدیریت فاکتورهای خرید
│   └── SalesInvoicesController.cs      # مدیریت فاکتورهای فروش
│
├── HR/                                 # سیستم منابع انسانی
│   ├── UserProfilesController.cs       # مدیریت پروفایل کاربران
│   └── UsersController.cs              # مدیریت کاربران
│
├── System/                             # سیستم‌های عمومی
│   ├── DashboardController.cs          # داشبورد اصلی
│   ├── SampleDataController.cs         # داده‌های نمونه
│   ├── SystemSettingsController.cs     # تنظیمات سیستم
│   ├── RolesController.cs              # مدیریت نقش‌ها
│   ├── CompaniesController.cs          # مدیریت شرکت‌ها
│   ├── CustomersController.cs          # مدیریت مشتریان
│   └── VendorsController.cs            # مدیریت تامین‌کنندگان
│
└── Settings/                           # تنظیمات
    └── AccountingSettingsController.cs # تنظیمات حسابداری
```

### مزایای این ساختار

#### 1. **سازماندهی منطقی**
- هر سیستم در پوشه جداگانه
- کنترلرهای مرتبط در کنار هم
- پیدا کردن کنترلرها آسان‌تر

#### 2. **قابلیت نگهداری**
- تغییرات در یک سیستم تأثیر بر سایرین ندارد
- توسعه مستقل هر سیستم
- تست آسان‌تر

#### 3. **مقیاس‌پذیری**
- اضافه کردن سیستم جدید آسان
- تقسیم‌بندی تیم‌های توسعه
- مدیریت بهتر کد

### Namespace ها

هر کنترلر در namespace مربوط به سیستم خود قرار دارد:

```csharp
// CRM Controllers
namespace Dinawin.Erp.WebApi.Controllers.CRM;

// Sales Controllers  
namespace Dinawin.Erp.WebApi.Controllers.Sales;

// Purchase Controllers
namespace Dinawin.Erp.WebApi.Controllers.Purchase;

// Product Controllers
namespace Dinawin.Erp.WebApi.Controllers.Product;

// Inventory Controllers
namespace Dinawin.Erp.WebApi.Controllers.Inventory;

// Accounting Controllers
namespace Dinawin.Erp.WebApi.Controllers.Accounting;

// HR Controllers
namespace Dinawin.Erp.WebApi.Controllers.HR;

// System Controllers
namespace Dinawin.Erp.WebApi.Controllers.System;

// Settings Controllers
namespace Dinawin.Erp.WebApi.Controllers.Settings;
```

### BaseController

تمام کنترلرها از `BaseController` ارث‌بری می‌کنند که شامل:

- **متدهای پاسخ استاندارد**: `Success`, `Error`, `Created`, `Updated`, `Deleted`
- **مدیریت خطا**: `HandleError`
- **اعتبارسنجی**: `ValidateId`
- **صفحه‌بندی**: `Paginated`
- **تنظیمات متمرکز**: `ApiController`, `Produces`

### مثال استفاده

```csharp
[Route("api/[controller]")]
public class CategoriesController : BaseController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories([FromQuery] GetAllCategoriesQuery query)
    {
        try
        {
            var categories = await _mediator.Send(query);
            return Success(categories, "لیست دسته‌بندی‌ها با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}
```

### قوانین نام‌گذاری

#### 1. **نام پوشه‌ها**
- با حروف بزرگ شروع می‌شوند
- از نام سیستم استفاده می‌کنند
- به صورت مفرد هستند

#### 2. **نام کنترلرها**
- با حروف بزرگ شروع می‌شوند
- به `Controller` ختم می‌شوند
- نام Entity را شامل می‌شوند

#### 3. **Route ها**
- از `[Route("api/[controller]")]` استفاده می‌کنند
- نام کنترلر به صورت خودکار Route می‌شود

### مزایای این رویکرد

#### 1. **جداسازی منطقی**
- هر سیستم مستقل است
- وابستگی‌ها کم‌تر
- تست آسان‌تر

#### 2. **قابلیت توسعه**
- اضافه کردن کنترلر جدید آسان
- تغییرات محدود به سیستم مربوطه
- توسعه موازی

#### 3. **نگهداری آسان**
- پیدا کردن کنترلرها سریع
- تغییرات متمرکز
- کد تمیزتر

### نکات مهم

1. **همیشه از BaseController استفاده کنید**
2. **Namespace مناسب انتخاب کنید**
3. **Route ها را درست تنظیم کنید**
4. **مستندات کامل بنویسید**
5. **Error handling را فراموش نکنید**

### مراحل بعدی

1. **تکمیل کنترلرهای باقی‌مانده**
2. **اضافه کردن کنترلرهای جدید**
3. **تست تمام کنترلرها**
4. **به‌روزرسانی مستندات**

این ساختار باعث می‌شود که پروژه منظم‌تر، قابل نگهداری‌تر و قابل توسعه‌تر باشد.

