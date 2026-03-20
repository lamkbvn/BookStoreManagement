using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.InventoryFeatures.Commands.IncreaseInventory
{
    public class IncreaseInventoryProfile : Profile
    {
        public IncreaseInventoryProfile()
        {
            CreateMap<Inventory, IncreaseInventoryResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
