using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.InventoryFeatures.Commands.UpdateInventory
{
    public class UpdateInventoryProfile : Profile
    {
        public UpdateInventoryProfile()
        {
            CreateMap<UpdateInventoryCommand, Inventory>();
            CreateMap<Inventory, UpdateInventoryResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
