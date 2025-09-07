using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorById;

/// <summary>
/// پرس‌وجو دریافت تامین‌کننده بر اساس شناسه
/// </summary>
public sealed class GetVendorByIdQuery : IRequest<VendorDto?>
{
    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    [Required(ErrorMessage = "شناسه تامین‌کننده الزامی است")]
    public Guid Id { get; set; }
}
