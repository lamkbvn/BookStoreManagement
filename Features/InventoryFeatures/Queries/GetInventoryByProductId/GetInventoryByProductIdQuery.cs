using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryByProductId
{
    public class GetInventoryByProductIdQuery : IRequest<GetInventoryByProductIdResult>
    {
        public int ProductId { get; set; }
    }
}
