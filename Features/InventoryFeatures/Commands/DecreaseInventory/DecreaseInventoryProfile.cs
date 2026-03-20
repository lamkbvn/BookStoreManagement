using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.InventoryFeatures.Commands.DecreaseInventory
{
    public class DecreaseInventoryProfile : Profile
    {
        public DecreaseInventoryProfile()
        {
            CreateMap<Inventory, DecreaseInventoryResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
