using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Commands.DeleteJournalEntry;

/// <summary>
/// دستور حذف سند حسابداری
/// </summary>
public sealed class DeleteJournalEntryCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه سند حسابداری
    /// </summary>
    [Required(ErrorMessage = "شناسه سند حسابداری الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
