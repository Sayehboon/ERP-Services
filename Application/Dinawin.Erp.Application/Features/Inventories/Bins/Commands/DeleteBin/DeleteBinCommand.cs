using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventories.Bins.Commands.DeleteBin;

/// <summary>
/// دستور حذف مکان
/// </summary>
public sealed class DeleteBinCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه مکان
    /// </summary>
    [Required(ErrorMessage = "شناسه مکان الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
