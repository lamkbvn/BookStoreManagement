using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Queries.GetSupplierById
{
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, GetSupplierByIdResult>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<GetSupplierByIdResult> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id);
            if (supplier == null)
                throw new AppException("Supplier not found", StatusCodes.Status404NotFound);

            return _mapper.Map<GetSupplierByIdResult>(supplier);
        }
    }
}

