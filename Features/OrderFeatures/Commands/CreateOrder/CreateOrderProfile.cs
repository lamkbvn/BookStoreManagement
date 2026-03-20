using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<Order, CreateOrderResult>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.PromotionCode, opt => opt.MapFrom(src => src.Promotion != null ? src.Promotion.Code : null))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice)));

            CreateMap<OrderItem, OrderItemResultDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
