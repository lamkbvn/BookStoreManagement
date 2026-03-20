using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.UpdateInventory
{
    public class UpdateInventoryHandler
        : IRequestHandler<UpdateInventoryCommand, UpdateInventoryResult>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public UpdateInventoryHandler(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateInventoryResult> Handle(
            UpdateInventoryCommand request,
            CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(request.Id);
            if (inventory == null)
                throw new InvalidOperationException($"Inventory with id {request.Id} not found");

            inventory.Quantity = request.Quantity;
            var updatedInventory = await _inventoryRepository.UpdateAsync(inventory);
            
            return _mapper.Map<UpdateInventoryResult>(updatedInventory);
        }
    }
}
