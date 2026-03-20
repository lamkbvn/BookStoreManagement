using MediatR;

namespace WebBanHang.Features.InventoryFeatures.Commands.DeleteInventory
{
    public class DeleteInventoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
