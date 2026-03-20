using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventories
{
    public class GetInventoriesHandler
        : IRequestHandler<GetInventoriesQuery, List<GetInventoriesResult>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoriesHandler(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetInventoriesResult>> Handle(
            GetInventoriesQuery request,
            CancellationToken cancellationToken)
        {
            var inventories = await _inventoryRepository.GetAllAsync();
            return _mapper.Map<List<GetInventoriesResult>>(inventories);
        }
    }
}
