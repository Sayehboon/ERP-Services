using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeSalary;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت حقوق کارمند
/// </summary>
public sealed class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, EmployeeSalaryDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت حقوق کارمند
    /// </summary>
    public GetEmployeeSalaryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت حقوق کارمند
    /// </summary>
    public async Task<EmployeeSalaryDto?> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var query = _context.EmployeeSalaries
            .Include(es => es.Employee)
                .ThenInclude(e => e.Department)
            .Include(es => es.Employee)
                .ThenInclude(e => e.Company)
            .Include(es => es.CreatedByUser)
            .Include(es => es.ApprovedByUser)
            .Where(es => es.EmployeeId == request.EmployeeId);

        // فیلتر بر اساس سال
        if (request.Year.HasValue)
            query = query.Where(es => es.Year == request.Year.Value);

        // فیلتر بر اساس ماه
        if (request.Month.HasValue)
            query = query.Where(es => es.Month == request.Month.Value);

        var salary = await query
            .OrderByDescending(es => es.Year)
            .ThenByDescending(es => es.Month)
            .FirstOrDefaultAsync(cancellationToken);

        if (salary == null)
        {
            return null;
        }

        // دریافت جزئیات حقوق در صورت نیاز
        var details = new List<SalaryDetailDto>();
        if (request.IncludeDetails)
        {
            var salaryDetails = await _context.EmployeeSalaryDetails
                .Where(esd => esd.EmployeeSalaryId == salary.Id)
                .ToListAsync(cancellationToken);

            details = salaryDetails.Select(detail => new SalaryDetailDto
            {
                Id = detail.Id,
                DetailType = detail.DetailType,
                DetailTypePersian = GetDetailTypePersian(detail.DetailType),
                Category = detail.Category,
                CategoryPersian = GetCategoryPersian(detail.Category),
                Amount = detail.Amount,
                Percentage = detail.Percentage,
                Description = detail.Description,
                IsAddition = detail.IsAddition
            }).ToList();
        }

        var salaryDto = new EmployeeSalaryDto
        {
            Id = salary.Id,
            EmployeeId = salary.EmployeeId,
            EmployeeName = salary.Employee?.FirstName + " " + salary.Employee?.LastName,
            EmployeeCode = salary.Employee?.EmployeeCode ?? "نامشخص",
            Year = salary.Year,
            Month = salary.Month,
            MonthName = GetMonthName(salary.Month),
            BaseSalary = salary.BaseSalary,
            OvertimePay = salary.OvertimePay,
            Bonus = salary.Bonus,
            Allowances = salary.Allowances,
            InsuranceDeduction = salary.InsuranceDeduction,
            TaxDeduction = salary.TaxDeduction,
            OtherDeductions = salary.OtherDeductions,
            Currency = salary.Currency,
            ExchangeRate = salary.ExchangeRate,
            SalaryInBaseCurrency = salary.SalaryInBaseCurrency,
            PaymentStatus = salary.PaymentStatus,
            PaymentStatusPersian = GetPaymentStatusPersian(salary.PaymentStatus),
            PaymentDate = salary.PaymentDate,
            PaymentMethod = salary.PaymentMethod,
            CheckNumber = salary.CheckNumber,
            ReferenceNumber = salary.ReferenceNumber,
            Description = salary.Description,
            CreatedBy = salary.CreatedBy,
            CreatedByName = salary.CreatedByUser?.FirstName + " " + salary.CreatedByUser?.LastName,
            ApprovedBy = salary.ApprovedBy,
            ApprovedByName = salary.ApprovedByUser?.FirstName + " " + salary.ApprovedByUser?.LastName,
            ApprovedAt = salary.ApprovedAt,
            CreatedAt = salary.CreatedAt,
            UpdatedAt = salary.UpdatedAt,
            Details = details,
            DepartmentId = salary.Employee?.DepartmentId,
            DepartmentName = salary.Employee?.Department?.Name,
            CompanyId = salary.Employee?.CompanyId,
            CompanyName = salary.Employee?.Company?.Name
        };

        return salaryDto;
    }

    /// <summary>
    /// تبدیل نوع جزئیات انگلیسی به فارسی
    /// </summary>
    private static string GetDetailTypePersian(string detailType)
    {
        return detailType.ToLower() switch
        {
            "base_salary" => "حقوق پایه",
            "overtime" => "اضافه کار",
            "bonus" => "پاداش",
            "allowance" => "مزایا",
            "transportation" => "حق حمل و نقل",
            "housing" => "حق مسکن",
            "food" => "حق غذا",
            "insurance" => "بیمه",
            "tax" => "مالیات",
            "loan" => "وام",
            "advance" => "پیش پرداخت",
            "penalty" => "جریمه",
            "other" => "سایر",
            _ => detailType
        };
    }

    /// <summary>
    /// تبدیل دسته‌بندی انگلیسی به فارسی
    /// </summary>
    private static string GetCategoryPersian(string category)
    {
        return category.ToLower() switch
        {
            "addition" => "اضافه",
            "deduction" => "کسر",
            "benefit" => "مزایا",
            "allowance" => "مزایا",
            "tax" => "مالیات",
            "insurance" => "بیمه",
            "loan" => "وام",
            "penalty" => "جریمه",
            _ => category
        };
    }

    /// <summary>
    /// تبدیل وضعیت پرداخت انگلیسی به فارسی
    /// </summary>
    private static string GetPaymentStatusPersian(string paymentStatus)
    {
        return paymentStatus.ToLower() switch
        {
            "pending" => "در انتظار پرداخت",
            "paid" => "پرداخت شده",
            "partial" => "پرداخت جزئی",
            "cancelled" => "لغو شده",
            "failed" => "ناموفق",
            "processing" => "در حال پردازش",
            _ => paymentStatus
        };
    }

    /// <summary>
    /// دریافت نام ماه
    /// </summary>
    private static string GetMonthName(int month)
    {
        return month switch
        {
            1 => "فروردین",
            2 => "اردیبهشت",
            3 => "خرداد",
            4 => "تیر",
            5 => "مرداد",
            6 => "شهریور",
            7 => "مهر",
            8 => "آبان",
            9 => "آذر",
            10 => "دی",
            11 => "بهمن",
            12 => "اسفند",
            _ => "نامشخص"
        };
    }
}
