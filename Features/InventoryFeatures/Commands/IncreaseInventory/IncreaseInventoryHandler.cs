using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.IncreaseInventory
{
    public class IncreaseInventoryHandler
        : IRequestHandler<IncreaseInventoryCommand, IncreaseInventoryResult>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public IncreaseInventoryHandler(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<IncreaseInventoryResult> Handle(
            IncreaseInventoryCommand request,
            CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(request.Id);
            if (inventory == null)
                throw new InvalidOperationException($"Inventory with id {request.Id} not found");

            inventory.Quantity += request.Quantity;
            var updatedInventory = await _inventoryRepository.UpdateAsync(inventory);
            
            return _mapper.Map<IncreaseInventoryResult>(updatedInventory);
        }
    }
}
