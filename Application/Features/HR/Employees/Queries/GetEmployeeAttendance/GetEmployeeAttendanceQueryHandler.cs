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
            .Where(ea => ea.EmployeeId == request.EmployeeId);

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
            query = query.Where(ea => ea.AttendanceDate >= request.FromDate.Value);
        if (request.ToDate.HasValue)
            query = query.Where(ea => ea.AttendanceDate <= request.ToDate.Value);

        // فیلتر بر اساس نوع حضور - AttendanceType property does not exist in EmployeeAttendance entity
        // if (!string.IsNullOrEmpty(request.AttendanceType))
        //     query = query.Where(ea => ea.AttendanceType == request.AttendanceType);

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

            // محاسبه تاخیر در ورود - ScheduledStartTime property does not exist
            int? lateArrivalMinutes = null;
            // محاسبه زودتر خروج - ScheduledEndTime property does not exist
            int? earlyDepartureMinutes = null;
            // محاسبه اضافه کار - ScheduledEndTime property does not exist
            int? overtimeMinutes = null;

            var attendanceDto = new EmployeeAttendanceDto
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                EmployeeName = "نامشخص",
                EmployeeCode = "نامشخص",
                AttendanceDate = attendance.AttendanceDate,
                CheckInTime = attendance.CheckInTime,
                CheckOutTime = attendance.CheckOutTime,
                WorkDurationMinutes = workDurationMinutes,
                // AttendanceType property does not exist in EmployeeAttendance entity
                // AttendanceTypePersian - property does not exist
                Status = attendance.Status,
                StatusPersian = GetStatusPersian(attendance.Status),
                // ScheduledStartTime property does not exist in EmployeeAttendance entity
                // ScheduledEndTime property does not exist in EmployeeAttendance entity
                LateArrivalMinutes = lateArrivalMinutes,
                EarlyDepartureMinutes = earlyDepartureMinutes,
                OvertimeMinutes = overtimeMinutes,
                // BreakMinutes property does not exist in EmployeeAttendance entity
                // CheckInLocation property does not exist in EmployeeAttendance entity
                // CheckOutLocation property does not exist in EmployeeAttendance entity
                // CheckInDevice property does not exist in EmployeeAttendance entity
                // CheckOutDevice property does not exist in EmployeeAttendance entity
                Description = attendance.Description,
                // ManagerNotes property does not exist in EmployeeAttendance entity
                // IsApproved property does not exist in EmployeeAttendance entity
                // ApprovedBy property does not exist in EmployeeAttendance entity
                // ApprovedByName - ApprovedByUser property does not exist
                // ApprovedAt property does not exist in EmployeeAttendance entity
                CreatedBy = attendance.CreatedBy,
                // CreatedByName - CreatedByUser property does not exist
                CreatedAt = attendance.CreatedAt,
                UpdatedAt = attendance.UpdatedAt,
                DepartmentId = null,
                DepartmentName = null,
                CompanyId = null,
                CompanyName = null
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
