using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<Product, UpdateProductResult>()
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Inventory != null ? s.Inventory.Quantity : 0));
        }
    }
}

