using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Customers.Commands.DeleteCustomer;

/// <summary>
/// دستور حذف مشتری
/// </summary>
public sealed class DeleteCustomerCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    [Required(ErrorMessage = "شناسه مشتری الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
