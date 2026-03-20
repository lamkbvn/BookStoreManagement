using MediatR;

namespace WebBanHang.Features.OrderFeatures.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
