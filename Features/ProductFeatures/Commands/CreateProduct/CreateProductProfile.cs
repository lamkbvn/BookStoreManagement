using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Inventory, opt => opt.Ignore())
                .ForMember(d => d.OrderItems, opt => opt.Ignore())
                .ForMember(d => d.Category, opt => opt.Ignore())
                .ForMember(d => d.Supplier, opt => opt.Ignore());

            CreateMap<Product, CreateProductResult>()
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Inventory != null ? s.Inventory.Quantity : 0));
        }
    }
}

