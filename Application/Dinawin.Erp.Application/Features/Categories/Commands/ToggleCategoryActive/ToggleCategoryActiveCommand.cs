using MediatR;

namespace Dinawin.Erp.Application.Features.Categories.Commands.ToggleCategoryActive;

/// <summary>
/// دستور تغییر وضعیت فعال/غیرفعال دسته‌بندی
/// </summary>
public sealed class ToggleCategoryActiveCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public required Guid Id { get; init; }
}
