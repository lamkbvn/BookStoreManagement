using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryById
{
    public class GetInventoryByIdProfile : Profile
    {
        public GetInventoryByIdProfile()
        {
            CreateMap<Inventory, GetInventoryByIdResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
