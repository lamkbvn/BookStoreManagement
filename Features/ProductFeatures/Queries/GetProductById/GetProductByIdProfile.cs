using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdProfile : Profile
    {
        public GetProductByIdProfile()
        {
            CreateMap<Product, GetProductByIdResult>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.Name : ""))
                .ForMember(d => d.SupplierName, opt => opt.MapFrom(s => s.Supplier != null ? s.Supplier.Name : ""))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Inventory != null ? s.Inventory.Quantity : 0));
        }
    }
}

