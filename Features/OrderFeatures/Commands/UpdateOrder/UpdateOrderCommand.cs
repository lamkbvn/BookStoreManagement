using MediatR;

namespace WebBanHang.Features.OrderFeatures.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<UpdateOrderResult>
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
