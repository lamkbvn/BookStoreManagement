using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WebBanHang.Common.Exceptions;
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
                throw new AppException($"Inventory with id {request.Id} not found", StatusCodes.Status404NotFound);

            if (inventory.Quantity < request.Quantity)
                throw new AppException("Hết hàng", StatusCodes.Status400BadRequest);

            inventory.Quantity -= request.Quantity;
            await _inventoryRepository.UpdateAsync(inventory);

            var result = await _inventoryRepository.GetByIdAsync(request.Id);
            if (result == null)
                throw new AppException("Failed to load inventory after decrease", StatusCodes.Status500InternalServerError);

            return _mapper.Map<DecreaseInventoryResult>(result);
        }
    }
}
