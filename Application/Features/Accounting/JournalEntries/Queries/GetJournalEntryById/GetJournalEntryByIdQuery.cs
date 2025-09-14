using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Queries.GetJournalEntryById;

/// <summary>
/// پرس‌وجو دریافت سند حسابداری بر اساس شناسه
/// </summary>
public sealed class GetJournalEntryByIdQuery : IRequest<JournalEntryDto>
{
    /// <summary>
    /// شناسه سند حسابداری
    /// </summary>
    [Required(ErrorMessage = "شناسه سند حسابداری الزامی است")]
    public Guid Id { get; set; }
}
