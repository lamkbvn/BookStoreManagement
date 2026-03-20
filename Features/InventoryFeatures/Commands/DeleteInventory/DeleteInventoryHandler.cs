using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.DeleteInventory
{
    public class DeleteInventoryHandler
        : IRequestHandler<DeleteInventoryCommand, Unit>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public DeleteInventoryHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<Unit> Handle(
            DeleteInventoryCommand request,
            CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(request.Id);
            if (inventory == null)
                throw new InvalidOperationException($"Inventory with id {request.Id} not found");

            await _inventoryRepository.DeleteAsync(inventory);
            return Unit.Value;
        }
    }
}
