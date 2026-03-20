using MediatR;

namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; } = new();
    }
}
