using MediatR;

namespace WebBanHang.Features.OrderFeatures.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<List<GetOrdersResult>>
    {
    }
}
