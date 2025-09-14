# ساختار Commands و Queries سیستم دیناوین ERP

## نمای کلی
این پوشه شامل تمام Commands و Queries سیستم بر اساس الگوی CQRS است. هر سیستم دارای پوشه جداگانه‌ای است که شامل Commands و Queries مربوط به آن سیستم می‌باشد.

## ساختار کلی

### CRM (مدیریت ارتباط با مشتری)
```
CRM/
├── Activities/
│   ├── Commands/
│   │   ├── CreateActivity/
│   │   │   ├── CreateActivityCommand.cs
│   │   │   └── CreateActivityCommandHandler.cs
│   │   ├── UpdateActivity/
│   │   └── DeleteActivity/
│   └── Queries/
│       ├── GetAllActivities/
│       │   ├── GetAllActivitiesQuery.cs
│       │   ├── GetAllActivitiesQueryHandler.cs
│       │   └── ActivityDto.cs
│       └── GetActivityById/
├── Contacts/
│   ├── Commands/
│   │   └── CreateContact/
│   └── Queries/
├── Leads/
├── Opportunities/
└── Tickets/
```

### Sales (فروش)
```
Sales/
├── SalesOrders/
│   ├── Commands/
│   │   ├── CreateSalesOrder/
│   │   │   ├── CreateSalesOrderCommand.cs
│   │   │   └── CreateSalesOrderCommandHandler.cs
│   │   ├── UpdateSalesOrder/
│   │   └── DeleteSalesOrder/
│   └── Queries/
│       ├── GetAllSalesOrders/
│       └── GetSalesOrderById/
└── SalesInvoices/
```

### Product (محصولات)
```
Product/
├── Products/
│   ├── Commands/
│   │   ├── CreateProduct/
│   │   │   ├── CreateProductCommand.cs
│   │   │   └── CreateProductCommandHandler.cs
│   │   ├── UpdateProduct/
│   │   └── DeleteProduct/
│   └── Queries/
│       ├── GetAllProducts/
│       └── GetProductById/
├── Brands/
├── Categories/
├── Models/
├── Trims/
├── Units/
├── Uoms/
├── UomConversions/
└── Years/
```

### HR (منابع انسانی)
```
HR/
├── Employees/
│   ├── Commands/
│   │   ├── CreateEmployee/
│   │   │   ├── CreateEmployeeCommand.cs
│   │   │   └── CreateEmployeeCommandHandler.cs
│   │   ├── UpdateEmployee/
│   │   └── DeleteEmployee/
│   └── Queries/
│       ├── GetAllEmployees/
│       └── GetEmployeeById/
└── Departments/
```

## الگوی CQRS

### Commands (دستورات)
- برای عملیات نوشتن (Create, Update, Delete)
- تغییر وضعیت سیستم
- هر Command یک Handler دارد
- از `IRequest<T>` مشتق می‌شوند

### Queries (درخواست‌ها)
- برای عملیات خواندن (Get, Search, List)
- دریافت اطلاعات از سیستم
- هر Query یک Handler دارد
- از `IRequest<T>` مشتق می‌شوند

### DTOs (Data Transfer Objects)
- برای انتقال داده بین لایه‌ها
- در پوشه Queries قرار دارند
- شامل تمام اطلاعات مورد نیاز

## ویژگی‌های پیاده‌سازی شده

### ✅ CRM
- **Activities**: CreateActivityCommand, GetAllActivitiesQuery
- **Contacts**: CreateContactCommand

### ✅ Sales
- **SalesOrders**: CreateSalesOrderCommand

### ✅ Product
- **Products**: CreateProductCommand

### ✅ HR
- **Employees**: CreateEmployeeCommand

### 🔄 در حال پیاده‌سازی
- **Purchase**: Commands و Queries
- **Inventory**: Commands و Queries
- **Accounting**: Commands و Queries
- **System**: Commands و Queries
- **Financial**: Commands و Queries
- **TaskManagement**: Commands و Queries

## مراحل بعدی

### فاز 1: تکمیل Commands و Queries
- [ ] پیاده‌سازی تمام Commands برای هر سیستم
- [ ] پیاده‌سازی تمام Queries برای هر سیستم
- [ ] ایجاد DTOs مربوطه

### فاز 2: تست و اعتبارسنجی
- [ ] تست تمام Commands
- [ ] تست تمام Queries
- [ ] اعتبارسنجی عملکرد

### فاز 3: بهینه‌سازی
- [ ] بهینه‌سازی کوئری‌ها
- [ ] اضافه کردن Caching
- [ ] بهبود Performance

## نکات مهم

- تمام Commands و Queries از MediatR استفاده می‌کنند
- هر Command/Query دارای Handler جداگانه است
- DTOs در پوشه Queries قرار دارند
- تمام فایل‌ها دارای مستندسازی فارسی هستند
- از Entity Framework Core برای دسترسی به داده استفاده می‌شود
- مدیریت خطا به صورت یکپارچه انجام می‌شود

## مثال استفاده

### Command
```csharp
var command = new CreateActivityCommand
{
    Title = "تماس با مشتری",
    Description = "تماس تلفنی برای پیگیری سفارش",
    ActivityType = "تماس",
    Status = "در حال انجام",
    Priority = "متوسط",
    CreatedByUserId = currentUserId
};

var activityId = await _mediator.Send(command);
```

### Query
```csharp
var query = new GetAllActivitiesQuery
{
    ContactId = contactId,
    Status = "تکمیل شده",
    Page = 1,
    PageSize = 25
};

var activities = await _mediator.Send(query);
```
