using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.DeleteOrder
{
    public class DeleteOrderHandler
        : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(
            DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
                throw new InvalidOperationException($"Order with id {request.Id} not found");

            await _orderRepository.DeleteAsync(order);
            return Unit.Value;
        }
    }
}
