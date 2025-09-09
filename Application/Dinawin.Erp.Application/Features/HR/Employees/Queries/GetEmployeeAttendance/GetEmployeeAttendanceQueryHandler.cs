using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeAttendance;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت حضور و غیاب کارمند
/// </summary>
public sealed class GetEmployeeAttendanceQueryHandler : IRequestHandler<GetEmployeeAttendanceQuery, IEnumerable<EmployeeAttendanceDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت حضور و غیاب کارمند
    /// </summary>
    public GetEmployeeAttendanceQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت حضور و غیاب کارمند
    /// </summary>
    public async Task<IEnumerable<EmployeeAttendanceDto>> Handle(GetEmployeeAttendanceQuery request, CancellationToken cancellationToken)
    {
        var query = _context.EmployeeAttendances
            .Include(ea => ea.Employee)
                .ThenInclude(e => e.Department)
            .Include(ea => ea.Employee)
                .ThenInclude(e => e.Company)
            .Include(ea => ea.CreatedByUser)
            .Include(ea => ea.ApprovedByUser)
            .Where(ea => ea.EmployeeId == request.EmployeeId);

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
            query = query.Where(ea => ea.AttendanceDate >= request.FromDate.Value);
        if (request.ToDate.HasValue)
            query = query.Where(ea => ea.AttendanceDate <= request.ToDate.Value);

        // فیلتر بر اساس نوع حضور
        if (!string.IsNullOrEmpty(request.AttendanceType))
            query = query.Where(ea => ea.AttendanceType == request.AttendanceType);

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrEmpty(request.Status))
            query = query.Where(ea => ea.Status == request.Status);

        var attendances = await query
            .OrderByDescending(ea => ea.AttendanceDate)
            .Take(request.MaxResults)
            .ToListAsync(cancellationToken);

        var result = new List<EmployeeAttendanceDto>();

        foreach (var attendance in attendances)
        {
            // محاسبه مدت زمان کار
            int? workDurationMinutes = null;
            if (attendance.CheckInTime.HasValue && attendance.CheckOutTime.HasValue)
            {
                var duration = attendance.CheckOutTime.Value - attendance.CheckInTime.Value;
                workDurationMinutes = (int)duration.TotalMinutes;
            }

            // محاسبه تاخیر در ورود
            int? lateArrivalMinutes = null;
            if (attendance.CheckInTime.HasValue && attendance.ScheduledStartTime.HasValue)
            {
                if (attendance.CheckInTime.Value > attendance.ScheduledStartTime.Value)
                {
                    var lateTime = attendance.CheckInTime.Value - attendance.ScheduledStartTime.Value;
                    lateArrivalMinutes = (int)lateTime.TotalMinutes;
                }
            }

            // محاسبه زودتر خروج
            int? earlyDepartureMinutes = null;
            if (attendance.CheckOutTime.HasValue && attendance.ScheduledEndTime.HasValue)
            {
                if (attendance.CheckOutTime.Value < attendance.ScheduledEndTime.Value)
                {
                    var earlyTime = attendance.ScheduledEndTime.Value - attendance.CheckOutTime.Value;
                    earlyDepartureMinutes = (int)earlyTime.TotalMinutes;
                }
            }

            // محاسبه اضافه کار
            int? overtimeMinutes = null;
            if (attendance.CheckOutTime.HasValue && attendance.ScheduledEndTime.HasValue)
            {
                if (attendance.CheckOutTime.Value > attendance.ScheduledEndTime.Value)
                {
                    var overtime = attendance.CheckOutTime.Value - attendance.ScheduledEndTime.Value;
                    overtimeMinutes = (int)overtime.TotalMinutes;
                }
            }

            var attendanceDto = new EmployeeAttendanceDto
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                EmployeeName = attendance.Employee?.FirstName + " " + attendance.Employee?.LastName,
                EmployeeCode = attendance.Employee?.EmployeeCode ?? "نامشخص",
                AttendanceDate = attendance.AttendanceDate,
                CheckInTime = attendance.CheckInTime,
                CheckOutTime = attendance.CheckOutTime,
                WorkDurationMinutes = workDurationMinutes,
                AttendanceType = attendance.AttendanceType,
                AttendanceTypePersian = GetAttendanceTypePersian(attendance.AttendanceType),
                Status = attendance.Status,
                StatusPersian = GetStatusPersian(attendance.Status),
                ScheduledStartTime = attendance.ScheduledStartTime,
                ScheduledEndTime = attendance.ScheduledEndTime,
                LateArrivalMinutes = lateArrivalMinutes,
                EarlyDepartureMinutes = earlyDepartureMinutes,
                OvertimeMinutes = overtimeMinutes,
                BreakMinutes = attendance.BreakMinutes,
                CheckInLocation = attendance.CheckInLocation,
                CheckOutLocation = attendance.CheckOutLocation,
                CheckInDevice = attendance.CheckInDevice,
                CheckOutDevice = attendance.CheckOutDevice,
                Description = attendance.Description,
                ManagerNotes = attendance.ManagerNotes,
                IsApproved = attendance.IsApproved,
                ApprovedBy = attendance.ApprovedBy,
                ApprovedByName = attendance.ApprovedByUser?.FirstName + " " + attendance.ApprovedByUser?.LastName,
                ApprovedAt = attendance.ApprovedAt,
                CreatedBy = attendance.CreatedBy,
                CreatedByName = attendance.CreatedByUser?.FirstName + " " + attendance.CreatedByUser?.LastName,
                CreatedAt = attendance.CreatedAt,
                UpdatedAt = attendance.UpdatedAt,
                DepartmentId = attendance.Employee?.DepartmentId,
                DepartmentName = attendance.Employee?.Department?.Name,
                CompanyId = attendance.Employee?.CompanyId,
                CompanyName = attendance.Employee?.Company?.Name
            };

            result.Add(attendanceDto);
        }

        return result;
    }

    /// <summary>
    /// تبدیل نوع حضور انگلیسی به فارسی
    /// </summary>
    private static string GetAttendanceTypePersian(string attendanceType)
    {
        return attendanceType.ToLower() switch
        {
            "present" => "حاضر",
            "absent" => "غایب",
            "late" => "تاخیر",
            "early_departure" => "زودتر خروج",
            "overtime" => "اضافه کار",
            "half_day" => "نیم روز",
            "sick_leave" => "مرخصی استعلاجی",
            "vacation" => "مرخصی",
            "personal_leave" => "مرخصی شخصی",
            "emergency_leave" => "مرخصی اضطراری",
            "maternity_leave" => "مرخصی زایمان",
            "paternity_leave" => "مرخصی پدری",
            "unpaid_leave" => "مرخصی بدون حقوق",
            "business_trip" => "ماموریت",
            "training" => "آموزش",
            "meeting" => "جلسه",
            _ => attendanceType
        };
    }

    /// <summary>
    /// تبدیل وضعیت انگلیسی به فارسی
    /// </summary>
    private static string GetStatusPersian(string status)
    {
        return status.ToLower() switch
        {
            "pending" => "در انتظار تایید",
            "approved" => "تایید شده",
            "rejected" => "رد شده",
            "draft" => "پیش‌نویس",
            "completed" => "تکمیل شده",
            "cancelled" => "لغو شده",
            _ => status
        };
    }
}
