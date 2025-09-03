using AutoMapper;
using Dinawin.Erp.Application.Features.Inventory.Queries.Dtos;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;
using Dinawin.Erp.Application.Features.Users.Queries.Dtos;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.Entities.Users;

namespace Dinawin.Erp.Application.Common.Mappings;

/// <summary>
/// پروفایل نگاشت AutoMapper
/// AutoMapper mapping profile
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// سازنده پروفایل نگاشت
    /// Mapping profile constructor
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
            .ForMember(dest => dest.BaseUomName, opt => opt.MapFrom(src => src.BaseUom != null ? src.BaseUom.Name : null))
            .ForMember(dest => dest.PriceBuy, opt => opt.MapFrom(src => src.PurchasePrice != null ? src.PurchasePrice.Amount : (decimal?)null))
            .ForMember(dest => dest.PriceSell, opt => opt.MapFrom(src => src.SellingPrice != null ? src.SellingPrice.Amount : (decimal?)null))
            .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => 
                src.Inventories.Sum(i => i.AvailableQuantity)));

        CreateMap<Brand, BrandDto>()
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));

        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ParentCategoryName, opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.Name : null))
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count))
            .ForMember(dest => dest.SubcategoryCount, opt => opt.MapFrom(src => src.SubCategories.Count));

        CreateMap<User, UserProfileDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email != null ? src.Email.Value : string.Empty))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber != null ? src.PhoneNumber.Value : null))
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.Name : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => 
                src.UserRoles.Where(ur => ur.IsActive && !ur.IsExpired)
                           .Select(ur => ur.Role.DisplayName)
                           .FirstOrDefault()));



        CreateMap<Inventory, InventoryDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ProductSku, opt => opt.MapFrom(src => src.Product.Sku))
            .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
            .ForMember(dest => dest.AvgCost, opt => opt.MapFrom(src => src.AverageCost != null ? src.AverageCost.Amount : (decimal?)null));

        CreateMap<Warehouse, WarehouseDto>();
        CreateMap<InventoryMovement, InventoryMovementDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
            .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => src.UnitCost != null ? src.UnitCost.Amount : (decimal?)null))
            .ForMember(dest => dest.TotalValue, opt => opt.MapFrom(src => src.TotalValue != null ? src.TotalValue.Amount : (decimal?)null));
    }
}
