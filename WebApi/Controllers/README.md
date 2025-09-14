# BaseController Documentation

## مستندات کلاس پایه کنترلرها

### مقدمه
کلاس `BaseController` یک کلاس پایه برای تمام کنترلرهای API است که تنظیمات متمرکز و متدهای مشترک را فراهم می‌کند.

### مزایای استفاده از BaseController

#### 1. **تنظیمات متمرکز**
- تمام کنترلرها از یک ساختار یکسان پیروی می‌کنند
- مدیریت خطاها به صورت متمرکز
- پاسخ‌های API استاندارد

#### 2. **کاهش تکرار کد**
- متدهای مشترک در یک مکان
- کد کمتر و نگهداری آسان‌تر
- سازگاری با تمام کنترلرها

#### 3. **مدیریت خطا**
- مدیریت یکپارچه خطاها
- پاسخ‌های خطای استاندارد
- لاگ‌گیری متمرکز

### متدهای موجود در BaseController

#### 1. **متدهای پاسخ موفقیت‌آمیز**

```csharp
// پاسخ موفقیت‌آمیز با داده
protected ActionResult<T> Success<T>(T data, string message = null)

// پاسخ موفقیت‌آمیز بدون داده
protected ActionResult Success(string message = null)

// پاسخ ایجاد شده
protected ActionResult<T> Created<T>(Guid id, T data, string actionName = "Get")

// پاسخ به‌روزرسانی شده
protected ActionResult Updated(string message = null)

// پاسخ حذف شده
protected ActionResult Deleted(string message = null)
```

#### 2. **متدهای پاسخ خطا**

```csharp
// پاسخ خطای ساده
protected ActionResult Error(string message, int statusCode = 400)

// پاسخ خطا با جزئیات
protected ActionResult Error(string message, object details, int statusCode = 400)

// مدیریت خطاهای عمومی
protected ActionResult HandleError(Exception ex)
```

#### 3. **متدهای صفحه‌بندی**

```csharp
// پاسخ لیست صفحه‌بندی شده
protected ActionResult<PaginatedResponse<T>> Paginated<T>(
    IEnumerable<T> data, 
    int pageNumber, 
    int pageSize, 
    int totalCount)
```

#### 4. **متدهای اعتبارسنجی**

```csharp
// اعتبارسنجی شناسه
protected bool IsValidId(Guid id)

// اعتبارسنجی شناسه و بازگشت خطا
protected ActionResult? ValidateId(Guid id)
```

### نحوه استفاده

#### 1. **ارث‌بری از BaseController**

```csharp
[Route("api/[controller]")]
public class CategoriesController : BaseController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }
}
```

#### 2. **استفاده از متدهای پاسخ**

```csharp
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

[HttpPost]
public async Task<ActionResult<Guid>> CreateCategory([FromBody] CreateCategoryCommand command)
{
    try
    {
        var categoryId = await _mediator.Send(command);
        return Created(categoryId, categoryId, nameof(GetCategory));
    }
    catch (Exception ex)
    {
        return HandleError(ex);
    }
}
```

### ساختار پاسخ‌های API

#### 1. **پاسخ موفقیت‌آمیز**

```json
{
  "success": true,
  "data": [...],
  "message": "عملیات با موفقیت انجام شد",
  "timestamp": "2024-01-01T00:00:00Z"
}
```

#### 2. **پاسخ خطا**

```json
{
  "success": false,
  "message": "خطای داخلی سرور",
  "timestamp": "2024-01-01T00:00:00Z"
}
```

#### 3. **پاسخ صفحه‌بندی شده**

```json
{
  "data": [...],
  "pageNumber": 1,
  "pageSize": 25,
  "totalCount": 100,
  "totalPages": 4,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

### کنترلرهای به‌روزرسانی شده

#### 1. **CategoriesController**
- ارث‌بری از BaseController
- استفاده از متدهای استاندارد پاسخ
- مدیریت خطای متمرکز

#### 2. **SalesOrdersController**
- ارث‌بری از BaseController
- استفاده از متدهای استاندارد پاسخ
- مدیریت خطای متمرکز

#### 3. **PurchaseOrdersController**
- ارث‌بری از BaseController
- استفاده از متدهای استاندارد پاسخ
- مدیریت خطای متمرکز

### مزایای این رویکرد

#### 1. **سازگاری**
- تمام API ها ساختار یکسانی دارند
- پاسخ‌های استاندارد
- مدیریت خطای یکپارچه

#### 2. **نگهداری**
- تغییرات در یک مکان
- کد کمتر و تمیزتر
- تست آسان‌تر

#### 3. **قابلیت توسعه**
- اضافه کردن متدهای جدید آسان
- پشتیبانی از ویژگی‌های جدید
- سازگاری با تغییرات آینده

### نکات مهم

1. **همیشه از try-catch استفاده کنید**
2. **از متدهای BaseController استفاده کنید**
3. **پیام‌های خطا را به فارسی بنویسید**
4. **کدهای وضعیت HTTP مناسب استفاده کنید**
5. **مستندات کامل برای هر متد بنویسید**

### مثال کامل

```csharp
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAllProducts([FromQuery] GetAllProductsQuery query)
    {
        try
        {
            var products = await _mediator.Send(query);
            return Success(products, "لیست محصولات با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
    {
        try
        {
            var productId = await _mediator.Send(command);
            return Created(productId, productId, nameof(GetProduct));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            await _mediator.Send(new DeleteProductCommand { Id = id });
            return Deleted("محصول با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}
```

این رویکرد باعث می‌شود که تمام کنترلرها ساختار یکسان و استانداردی داشته باشند و نگهداری و توسعه آن‌ها آسان‌تر شود.

