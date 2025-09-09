using Dinawin.Erp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Domain.Entities.Crm;
using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.Entities.Sales;
using Dinawin.Erp.Domain.Entities.Purchase;

namespace Dinawin.Erp.Application.Services;

/// <summary>
/// سرویس برای وارد کردن داده‌های نمونه
/// Service for seeding sample data
/// </summary>
public class SampleDataService
{
    private readonly IApplicationDbContext _context;

    public SampleDataService(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه CRM
    /// Seed CRM sample data
    /// </summary>
    public async Task SeedCrmDataAsync()
    {
        // Check if data already exists
        if (await _context.Activities.AnyAsync())
            return;

        var activities = new List<Activity>
        {
            new Activity
            {
                Id = Guid.NewGuid(),
                Code = "A-001",
                Type = "تماس",
                Subject = "فالوآپ پیشنهاد قیمت",
                ContactName = "محمد احمدی",
                AccountName = "شرکت پارس خودرو",
                DueDate = DateTime.UtcNow.AddDays(2),
                Status = "انجام شده",
                Priority = "بالا",
                AssignedTo = null,
                Description = "تماس برای پیگیری پیشنهاد قطعات",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                IsActive = true
            },
            new Activity
            {
                Id = Guid.NewGuid(),
                Code = "A-002",
                Type = "ملاقات",
                Subject = "ارائه محصولات جدید",
                ContactName = "فاطمه صادقی",
                AccountName = "گاراژ مهر",
                DueDate = DateTime.UtcNow.AddDays(3),
                Status = "برنامه‌ریزی شده",
                Priority = "متوسط",
                AssignedTo = null,
                Description = "ملاقات حضوری برای معرفی محصولات",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                IsActive = true
            },
            new Activity
            {
                Id = Guid.NewGuid(),
                Code = "A-003",
                Type = "ایمیل",
                Subject = "ارسال کاتالوگ محصولات",
                ContactName = "علی موسوی",
                AccountName = "تعمیرگاه آریا",
                DueDate = DateTime.UtcNow.AddDays(1),
                Status = "انجام شده",
                Priority = "پایین",
                AssignedTo = null,
                Description = "ارسال کاتالوگ جدید قطعات",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                IsActive = true
            },
            new Activity
            {
                Id = Guid.NewGuid(),
                Code = "A-004",
                Type = "وظیفه",
                Subject = "آماده‌سازی پیشنهاد قیمت",
                ContactName = "رضا نوری",
                AccountName = "شرکت البرز موتور",
                DueDate = DateTime.UtcNow.AddDays(4),
                Status = "در حال انجام",
                Priority = "بالا",
                AssignedTo = null,
                Description = "تهیه پیشنهاد قیمت برای سفارش جدید",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                IsActive = true
            }
        };

        _context.Activities.AddRange(activities);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه سفارشات فروش
    /// Seed Sales Orders sample data
    /// </summary>
    public async Task SeedSalesOrdersDataAsync()
    {
        // Check if data already exists
        if (await _context.SalesOrders.AnyAsync())
            return;

        var salesOrders = new List<SalesOrder>
        {
            new SalesOrder
            {
                Id = Guid.NewGuid(),
                OrderNumber = "SO-2024-001",
                CustomerId = Guid.Empty,
                OrderDate = DateTime.UtcNow.AddDays(-5),
                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(10),
                TotalAmount = 145000000,
                Status = "تایید شده",
                Description = "سفارش محصولات صنعتی",
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                IsActive = true
            },
            new SalesOrder
            {
                Id = Guid.NewGuid(),
                OrderNumber = "SO-2024-002",
                CustomerId = Guid.Empty,
                OrderDate = DateTime.UtcNow.AddDays(-7),
                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(5),
                TotalAmount = 89000000,
                Status = "در حال تولید",
                Description = "سفارش تجهیزات دفتری",
                CreatedAt = DateTime.UtcNow.AddDays(-7),
                IsActive = true
            },
            new SalesOrder
            {
                Id = Guid.NewGuid(),
                OrderNumber = "SO-2024-003",
                CustomerId = Guid.Empty,
                OrderDate = DateTime.UtcNow.AddDays(-10),
                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(2),
                TotalAmount = 267000000,
                Status = "آماده ارسال",
                Description = "سفارش مواد اولیه",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                IsActive = true
            }
        };

        _context.SalesOrders.AddRange(salesOrders);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه سفارشات خرید
    /// Seed Purchase Orders sample data
    /// </summary>
    public async Task SeedPurchaseOrdersDataAsync()
    {
        // Check if data already exists
        if (await _context.PurchaseOrders.AnyAsync())
            return;

        var purchaseOrders = new List<PurchaseOrder>
        {
            new PurchaseOrder
            {
                Id = Guid.NewGuid(),
                OrderNumber = "PO-2024-001",
                VendorId = Guid.Empty,
                OrderDate = DateTime.UtcNow.AddDays(-3),
                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(12),
                TotalAmount = 45000000,
                Status = "sent",
                Description = "سفارش روغن موتور و فیلتر",
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                IsActive = true
            },
            new PurchaseOrder
            {
                Id = Guid.NewGuid(),
                OrderNumber = "PO-2024-002",
                VendorId = Guid.Empty,
                OrderDate = DateTime.UtcNow.AddDays(-4),
                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(11),
                TotalAmount = 32000000,
                Status = "confirmed",
                Description = "سفارش قطعات یدکی خودرو",
                CreatedAt = DateTime.UtcNow.AddDays(-4),
                IsActive = true
            }
        };

        _context.PurchaseOrders.AddRange(purchaseOrders);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه محصولات
    /// Seed Product sample data
    /// </summary>
    public async Task SeedProductDataAsync()
    {
        // Check if data already exists
        if (await _context.Models.AnyAsync())
            return;

        // First create categories
        var categories = new List<Category>
        {
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "خودروی سواری",
                Code = "CAR",
                Description = "دسته‌بندی خودروهای سواری",
                Level = 0,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "وانت",
                Code = "PICKUP",
                Description = "دسته‌بندی وانت‌ها",
                Level = 0,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "کامیون",
                Code = "TRUCK",
                Description = "دسته‌بندی کامیون‌ها",
                Level = 0,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _context.Categories.AddRange(categories);
        await _context.SaveChangesAsync();

        // Create brands
        var brands = new List<Brand>
        {
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "تویوتا",
                Country = "ژاپن",
                CategoryId = categories[0].Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "پژو",
                Country = "فرانسه",
                CategoryId = categories[0].Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "بنز",
                Country = "آلمان",
                CategoryId = categories[2].Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _context.Brands.AddRange(brands);
        await _context.SaveChangesAsync();

        // Create models
        var models = new List<Model>
        {
            new Model
            {
                Id = Guid.NewGuid(),
                Name = "کمری",
                Code = "CAMRY",
                BrandId = brands[0].Id,
                Description = "مدل کمری تویوتا",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Model
            {
                Id = Guid.NewGuid(),
                Name = "کرولا",
                Code = "COROLLA",
                BrandId = brands[0].Id,
                Description = "مدل کرولا تویوتا",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Model
            {
                Id = Guid.NewGuid(),
                Name = "206",
                Code = "206",
                BrandId = brands[1].Id,
                Description = "مدل 206 پژو",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _context.Models.AddRange(models);
        await _context.SaveChangesAsync();

        // Create trims
        var trims = new List<Trim>
        {
            new Trim
            {
                Id = Guid.NewGuid(),
                Name = "LE",
                Code = "LE",
                ModelId = models[0].Id,
                Description = "نسخه استاندارد با امکانات پایه",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Trim
            {
                Id = Guid.NewGuid(),
                Name = "XLE",
                Code = "XLE",
                ModelId = models[0].Id,
                Description = "نسخه میانی با امکانات بیشتر",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _context.Trims.AddRange(trims);
        await _context.SaveChangesAsync();

        // Create years
        var years = new List<Year>
        {
            new Year
            {
                Id = Guid.NewGuid(),
                YearValue = 2022,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Year
            {
                Id = Guid.NewGuid(),
                YearValue = 2023,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Year
            {
                Id = Guid.NewGuid(),
                YearValue = 2024,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _context.Years.AddRange(years);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه مخاطبین
    /// Seed Contacts sample data
    /// </summary>
    public async Task SeedContactsDataAsync()
    {
        // Check if data already exists
        if (await _context.Contacts.AnyAsync())
            return;

        var contacts = new List<Contact>
        {
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "محمد",
                LastName = "احمدی",
                Email = "m.ahmadi@parsauto.com",
                Phone = "021-12345678",
                Mobile = "09121234567",
                Company = "شرکت پارس خودرو",
                Position = "مدیر خرید",
                Address = "تهران، خیابان ولیعصر",
                City = "تهران",
                Source = "لید وب‌سایت",
                Status = "مشتری",
                Notes = "مشتری VIP با خرید عمده",
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                IsActive = true
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "فاطمه",
                LastName = "رضایی",
                Email = "f.rezaei@mehrgarage.com",
                Phone = "031-87654321",
                Mobile = "09129876543",
                Company = "گاراژ مهر",
                Position = "مالک",
                Address = "اصفهان، خیابان کاوه",
                City = "اصفهان",
                Source = "تماس تلفنی",
                Status = "مشتری بالقوه",
                Notes = "سرویس منظم",
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                IsActive = true
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "علی",
                LastName = "صادقی",
                Email = "a.sadeghi@aryagarage.com",
                Phone = "051-11223344",
                Mobile = "09135678901",
                Company = "تعمیرگاه آریا",
                Position = "مدیر فنی",
                Address = "مشهد، خیابان امام رضا",
                City = "مشهد",
                Source = "معرفی مشتری",
                Status = "لید",
                Notes = "علاقه‌مند به تجهیزات جدید",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                IsActive = true
            }
        };

        _context.Contacts.AddRange(contacts);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه لیدها
    /// Seed Leads sample data
    /// </summary>
    public async Task SeedLeadsDataAsync()
    {
        // Check if data already exists
        if (await _context.Leads.AnyAsync())
            return;

        var leads = new List<Lead>
        {
            new Lead
            {
                Id = Guid.NewGuid(),
                Name = "رضا",
                LastName = "نوری",
                Email = "r.nouri@example.com",
                Phone = "09123456789",
                CompanyName = "شرکت البرز موتور",
                Source = "وب‌سایت",
                Status = "جدید",
                Score = 85,
                EstimatedValue = 15000000,
                Notes = "علاقه‌مند به قطعات یدکی",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                IsActive = true
            },
            new Lead
            {
                Id = Guid.NewGuid(),
                Name = "زهرا",
                LastName = "کریمی",
                Email = "z.karimi@example.com",
                Phone = "09187654321",
                CompanyName = "گاراژ ستاره",
                Source = "تماس تلفنی",
                Status = "مقدماتی",
                Score = 72,
                EstimatedValue = 8500000,
                Notes = "درخواست کاتالوگ محصولات",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                IsActive = true
            }
        };

        _context.Leads.AddRange(leads);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه فرصت‌ها
    /// Seed Opportunities sample data
    /// </summary>
    public async Task SeedOpportunitiesDataAsync()
    {
        // Check if data already exists
        if (await _context.Opportunities.AnyAsync())
            return;

        var opportunities = new List<Opportunity>
        {
            new Opportunity
            {
                Id = Guid.NewGuid(),
                Name = "پروژه تأمین قطعات",
                AccountName = "شرکت پارس خودرو",
                ContactName = "محمد احمدی",
                Stage = "مذاکره",
                Probability = 75,
                Value = 45000000,
                CloseDate = DateTime.UtcNow.AddDays(30),
                Source = "لید کالیفای شده",
                Owner = "علی رضایی",
                Description = "تأمین قطعات یدکی برای یک سال",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                IsActive = true
            },
            new Opportunity
            {
                Id = Guid.NewGuid(),
                Name = "قرارداد سرویس سالانه",
                AccountName = "گاراژ مهر",
                ContactName = "فاطمه صادقی",
                Stage = "پیشنهاد",
                Probability = 60,
                Value = 25000000,
                CloseDate = DateTime.UtcNow.AddDays(45),
                Source = "تماس مستقیم",
                Owner = "سارا احمدی",
                Description = "خدمات سرویس و تعمیرات سالانه",
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                IsActive = true
            }
        };

        _context.Opportunities.AddRange(opportunities);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه تیکت‌ها
    /// Seed Tickets sample data
    /// </summary>
    public async Task SeedTicketsDataAsync()
    {
        // Check if data already exists
        if (await _context.Tickets.AnyAsync())
            return;

        var tickets = new List<Ticket>
        {
            new Ticket
            {
                Id = Guid.NewGuid(),
                Number = "TIC-001",
                Subject = "مشکل در تحویل قطعات",
                CustomerName = "شرکت پارس خودرو",
                ContactName = "محمد احمدی",
                Category = "شکایت",
                Priority = "بالا",
                Status = "باز",
                //AssignedTo = "علی رضایی",
                Description = "قطعات سفارش داده شده با تأخیر تحویل شده و کیفیت مطلوب نداشته",
                ResponseCount = 3,
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                IsActive = true
            },
            new Ticket
            {
                Id = Guid.NewGuid(),
                Number = "TIC-002",
                Subject = "درخواست اطلاعات محصول",
                CustomerName = "گاراژ مهر",
                ContactName = "فاطمه صادقی",
                Category = "سوال",
                Priority = "متوسط",
                Status = "در حال بررسی",
                //AssignedTo = "سارا احمدی",
                Description = "درخواست مشخصات فنی و قیمت محصولات جدید",
                ResponseCount = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                IsActive = true
            }
        };

        _context.Tickets.AddRange(tickets);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// وارد کردن تمام داده‌های نمونه
    /// Seed all sample data
    /// </summary>
    public async Task SeedAllSampleDataAsync()
    {
        await SeedCrmDataAsync();
        await SeedContactsDataAsync();
        await SeedLeadsDataAsync();
        await SeedOpportunitiesDataAsync();
        await SeedTicketsDataAsync();
        await SeedSalesOrdersDataAsync();
        await SeedPurchaseOrdersDataAsync();
        await SeedProductDataAsync();
    }
}
