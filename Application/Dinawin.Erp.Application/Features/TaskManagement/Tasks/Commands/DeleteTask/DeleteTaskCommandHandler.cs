using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.DeleteTask;

/// <summary>
/// مدیریت‌کننده دستور حذف وظیفه
/// </summary>
public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف وظیفه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف وظیفه
    /// </summary>
    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (task == null)
        {
            throw new ArgumentException($"وظیفه با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasSubTasks = await _context.Tasks
            .AnyAsync(t => t.ParentTaskId == request.Id, cancellationToken);
        
        if (hasSubTasks)
        {
            throw new InvalidOperationException("امکان حذف وظیفه به دلیل وجود زیروظایف وابسته وجود ندارد");
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
