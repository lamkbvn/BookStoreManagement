using AutoMapper;
using MediatR;
using WebBanHang.Entity;
using WebBanHang.Enum;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderHandler
        : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResult> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                UserId = request.UserId,
                PromotionId = request.PromotionId,
                Status = OrderStatus.Pending,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in request.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            var createdOrder = await _orderRepository.AddAsync(order);
            var result = await _orderRepository.GetByIdAsync(createdOrder.Id);
            
            return _mapper.Map<CreateOrderResult>(result);
        }
    }
}
