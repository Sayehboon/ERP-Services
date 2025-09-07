using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerById;

/// <summary>
/// پرس‌وجو دریافت مشتری بر اساس شناسه
/// </summary>
public sealed class GetCustomerByIdQuery : IRequest<CustomerDto?>
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    [Required(ErrorMessage = "شناسه مشتری الزامی است")]
    public Guid Id { get; set; }
}
