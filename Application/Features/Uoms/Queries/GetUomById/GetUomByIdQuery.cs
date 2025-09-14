using MediatR;

namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetUomById;

/// <summary>
/// پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
/// </summary>
public sealed class GetUomByIdQuery : IRequest<UomDto>
{
    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    public required Guid Id { get; init; }
}