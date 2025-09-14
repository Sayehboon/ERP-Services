using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Application.Features.Categories.Commands.CreateCategory;

/// <summary>
/// Handler for creating a new category
/// </summary>
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ParentCategoryId = request.ParentId,
            IsActive = request.IsActive,
            SortOrder = request.SortOrder,
            Icon = request.Icon,
            Color = request.Color,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}

