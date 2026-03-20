using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Queries.GetOrders
{
    public class GetOrdersHandler
        : IRequestHandler<GetOrdersQuery, List<GetOrdersResult>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersHandler(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrdersResult>> Handle(
            GetOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<GetOrdersResult>>(orders);
        }
    }
}
