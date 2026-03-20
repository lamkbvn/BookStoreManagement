using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryById
{
    public class GetInventoryByIdQuery : IRequest<GetInventoryByIdResult>
    {
        public int Id { get; set; }
    }
}
