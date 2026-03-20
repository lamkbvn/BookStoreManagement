using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventories
{
    public class GetInventoriesQuery : IRequest<List<GetInventoriesResult>>
    {
    }
}
