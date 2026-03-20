using MediatR;

namespace WebBanHang.Features.OrderFeatures.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdResult>
    {
        public int Id { get; set; }
    }
}
