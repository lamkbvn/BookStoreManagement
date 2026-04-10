using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WebBanHang.Common.Exceptions;
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
                throw new AppException($"Inventory with id {request.Id} not found", StatusCodes.Status404NotFound);

            inventory.Quantity += request.Quantity;
            await _inventoryRepository.UpdateAsync(inventory);

            var result = await _inventoryRepository.GetByIdAsync(request.Id);
            if (result == null)
                throw new AppException("Failed to load inventory after increase", StatusCodes.Status500InternalServerError);

            return _mapper.Map<IncreaseInventoryResult>(result);
        }
    }
}
