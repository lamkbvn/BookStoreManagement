using AutoMapper;
using MediatR;
using WebBanHang.Enum;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.UpdateOrder
{
    public class UpdateOrderHandler
        : IRequestHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderResult> Handle(
            UpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
                throw new InvalidOperationException($"Order with id {request.Id} not found");

            if (System.Enum.TryParse<OrderStatus>(request.Status, out var status))
            {
                order.Status = status;
            }

            // Calculate discount and final price before updating
            var totalPrice = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);
            if (order.Promotion != null)
            {
                order.DiscountAmount = totalPrice * (order.Promotion.DiscountPercentage / 100);
                order.FinalPrice = totalPrice - order.DiscountAmount;
            }
            else
            {
                order.DiscountAmount = 0;
                order.FinalPrice = totalPrice;
            }

            var updatedOrder = await _orderRepository.UpdateAsync(order);
            return _mapper.Map<UpdateOrderResult>(updatedOrder);
        }
    }
}
