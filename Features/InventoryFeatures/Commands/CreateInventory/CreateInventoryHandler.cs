using AutoMapper;
using MediatR;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.CreateInventory
{
    public class CreateInventoryHandler
        : IRequestHandler<CreateInventoryCommand, CreateInventoryResult>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public CreateInventoryHandler(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateInventoryResult> Handle(
            CreateInventoryCommand request,
            CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);
            var createdInventory = await _inventoryRepository.AddAsync(inventory);
            
            // Reload to get Product data
            var result = await _inventoryRepository.GetByIdAsync(createdInventory.Id);
            return _mapper.Map<CreateInventoryResult>(result);
        }
    }
}
