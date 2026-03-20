using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : IRequest<UpdateInventoryResult>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
