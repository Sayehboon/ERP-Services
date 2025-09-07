using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.TaskManagement;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.CreateTask;

/// <summary>
/// پردازشگر دستور ایجاد وظیفه جدید
/// </summary>
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه وظیفه ایجاد شده</returns>
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود پروژه
        if (request.ProjectId.HasValue)
        {
            var projectExists = await _context.Projects
                .AnyAsync(p => p.Id == request.ProjectId.Value, cancellationToken);

            if (!projectExists)
            {
                throw new InvalidOperationException($"پروژه با شناسه {request.ProjectId} یافت نشد");
            }
        }

        // بررسی وجود کاربر مسئول
        if (request.AssignedToUserId.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToUserId.Value, cancellationToken);

            if (!userExists)
            {
                throw new InvalidOperationException($"کاربر با شناسه {request.AssignedToUserId} یافت نشد");
            }
        }

        // بررسی وجود کاربر ایجاد کننده
        var createdByUserExists = await _context.Users
            .AnyAsync(u => u.Id == request.CreatedByUserId, cancellationToken);

        if (!createdByUserExists)
        {
            throw new InvalidOperationException($"کاربر ایجاد کننده با شناسه {request.CreatedByUserId} یافت نشد");
        }

        var task = new Task
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            ProjectId = request.ProjectId,
            AssignedToUserId = request.AssignedToUserId,
            CreatedByUserId = request.CreatedByUserId,
            Priority = request.Priority,
            Status = request.Status,
            TaskType = request.TaskType,
            Progress = request.Progress,
            StartDate = request.StartDate,
            DueDate = request.DueDate,
            CompletedDate = request.CompletedDate,
            EstimatedHours = request.EstimatedHours,
            ActualHours = request.ActualHours,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}
