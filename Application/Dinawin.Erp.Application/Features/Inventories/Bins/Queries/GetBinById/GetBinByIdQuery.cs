using MediatR;
using System.ComponentModel.DataAnnotations;
using Dinawin.Erp.Application.Features.Inventories.Bins.DTOs;

namespace Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetBinById;

/// <summary>
/// پرس‌وجو دریافت مکان بر اساس شناسه
/// </summary>
public sealed class GetBinByIdQuery : IRequest<BinDto?>
{
    /// <summary>
    /// شناسه مکان
    /// </summary>
    [Required(ErrorMessage = "شناسه مکان الزامی است")]
    public Guid Id { get; set; }
}
