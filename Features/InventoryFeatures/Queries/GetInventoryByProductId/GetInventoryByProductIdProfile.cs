using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryByProductId
{
    public class GetInventoryByProductIdProfile : Profile
    {
        public GetInventoryByProductIdProfile()
        {
            CreateMap<Inventory, GetInventoryByProductIdResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
