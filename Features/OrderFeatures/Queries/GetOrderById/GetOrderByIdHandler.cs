using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Queries.GetOrderById
{
    public class GetOrderByIdHandler
        : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdResult> Handle(
            GetOrderByIdQuery request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
                throw new InvalidOperationException($"Order with id {request.Id} not found");

            return _mapper.Map<GetOrderByIdResult>(order);
        }
    }
}
