using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Commands.DecreaseInventory
{
    public class DecreaseInventoryCommand : IRequest<DecreaseInventoryResult>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
