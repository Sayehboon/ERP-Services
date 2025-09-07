using MediatR;
using Dinawin.Erp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Commands.DeleteActivity;

/// <summary>
/// پردازشگر دستور حذف فعالیت
/// </summary>
public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, bool>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public DeleteActivityCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور حذف فعالیت
    /// </summary>
    /// <param name="request">درخواست حذف فعالیت</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>نتیجه حذف</returns>
    public async Task<bool> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (activity == null)
        {
            return false;
        }

        _context.Activities.Remove(activity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
