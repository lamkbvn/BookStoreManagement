using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Commands.IncreaseInventory
{
    public class IncreaseInventoryCommand : IRequest<IncreaseInventoryResult>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
