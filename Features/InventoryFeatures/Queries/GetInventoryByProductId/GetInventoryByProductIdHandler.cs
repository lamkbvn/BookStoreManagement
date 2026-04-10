using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryByProductId
{
    public class GetInventoryByProductIdHandler
        : IRequestHandler<GetInventoryByProductIdQuery, GetInventoryByProductIdResult>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoryByProductIdHandler(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<GetInventoryByProductIdResult> Handle(
            GetInventoryByProductIdQuery request,
            CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(request.ProductId);
            if (inventory == null)
                throw new AppException($"Inventory for product {request.ProductId} not found", StatusCodes.Status404NotFound);

            return _mapper.Map<GetInventoryByProductIdResult>(inventory);
        }
    }
}
