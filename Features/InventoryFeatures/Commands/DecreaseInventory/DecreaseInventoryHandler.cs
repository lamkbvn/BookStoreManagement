using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.DecreaseInventory
{
    public class DecreaseInventoryHandler
        : IRequestHandler<DecreaseInventoryCommand, DecreaseInventoryResult>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public DecreaseInventoryHandler(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<DecreaseInventoryResult> Handle(
            DecreaseInventoryCommand request,
            CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(request.Id);
            if (inventory == null)
                throw new InvalidOperationException($"Inventory with id {request.Id} not found");

            if (inventory.Quantity < request.Quantity)
                throw new InvalidOperationException($"Insufficient inventory quantity. Current: {inventory.Quantity}, Requested: {request.Quantity}");

            inventory.Quantity -= request.Quantity;
            var updatedInventory = await _inventoryRepository.UpdateAsync(inventory);
            
            return _mapper.Map<DecreaseInventoryResult>(updatedInventory);
        }
    }
}
