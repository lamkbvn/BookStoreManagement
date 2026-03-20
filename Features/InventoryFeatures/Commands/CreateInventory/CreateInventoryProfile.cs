using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.InventoryFeatures.Commands.CreateInventory
{
    public class CreateInventoryProfile : Profile
    {
        public CreateInventoryProfile()
        {
            CreateMap<CreateInventoryCommand, Inventory>();
            CreateMap<Inventory, CreateInventoryResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
