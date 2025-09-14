using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Vendors.Commands.DeleteVendor;

/// <summary>
/// دستور حذف تامین‌کننده
/// </summary>
public sealed class DeleteVendorCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    [Required(ErrorMessage = "شناسه تامین‌کننده الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
