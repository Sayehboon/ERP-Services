using MediatR;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeAttendance;

/// <summary>
/// پرس‌وجو دریافت حضور و غیاب کارمند
/// </summary>
public sealed class GetEmployeeAttendanceQuery : IRequest<IEnumerable<EmployeeAttendanceDto>>
{
    /// <summary>
    /// شناسه کارمند
    /// </summary>
    public required Guid EmployeeId { get; init; }

    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// نوع حضور (اختیاری)
    /// </summary>
    public string? AttendanceType { get; init; }

    /// <summary>
    /// وضعیت حضور (اختیاری)
    /// </summary>
    public string? Status { get; init; }

    /// <summary>
    /// تعداد نتایج حداکثر
    /// </summary>
    public int MaxResults { get; init; } = 100;
}
