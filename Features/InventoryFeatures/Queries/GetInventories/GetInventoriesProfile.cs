using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventories
{
    public class GetInventoriesProfile : Profile
    {
        public GetInventoriesProfile()
        {
            CreateMap<Inventory, GetInventoriesResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
