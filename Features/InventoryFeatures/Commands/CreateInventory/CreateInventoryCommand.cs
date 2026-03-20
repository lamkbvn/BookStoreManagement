using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Commands.CreateInventory
{
    public class CreateInventoryCommand : IRequest<CreateInventoryResult>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
