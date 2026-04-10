using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryById
{
    public class GetInventoryByIdHandler
        : IRequestHandler<GetInventoryByIdQuery, GetInventoryByIdResult>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoryByIdHandler(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<GetInventoryByIdResult> Handle(
            GetInventoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(request.Id);
            if (inventory == null)
                throw new AppException($"Inventory with id {request.Id} not found", StatusCodes.Status404NotFound);

            return _mapper.Map<GetInventoryByIdResult>(inventory);
        }
    }
}
