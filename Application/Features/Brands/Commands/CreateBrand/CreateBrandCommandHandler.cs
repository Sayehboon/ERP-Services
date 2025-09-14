using MediatR;
using Dinawin.Erp.Domain.Entities;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Application.Features.Brands.Commands.CreateBrand;

/// <summary>
/// پردازشگر دستور ایجاد برند جدید
/// Handler for creating a new brand
/// </summary>
public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر دستور ایجاد برند
    /// Constructor for create brand command handler
    /// </summary>
    /// <param name="context">زمینه پایگاه داده</param>
    public CreateBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد برند جدید
    /// Handles the create brand command
    /// </summary>
    /// <param name="request">درخواست ایجاد برند</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه برند ایجاد شده</returns>
    public async Task<Guid> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            Country = request.Country,
            Website = request.Website,
            LogoUrl = request.LogoUrl,
            IsActive = request.IsActive,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Brands.Add(brand);
        await _context.SaveChangesAsync(cancellationToken);

        return brand.Id;
    }
}
