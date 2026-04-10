using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Commands.UpdateSupplier
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand, UpdateSupplierResult>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSupplierResult> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var existing = await _supplierRepository.GetByIdAsync(request.Id);

            if (existing is null)
                throw new AppException("Supplier not found", StatusCodes.Status404NotFound);

            existing.Name = request.Name;
            var updated = await _supplierRepository.UpdateAsync(existing);

            return _mapper.Map<UpdateSupplierResult>(updated);
        }
    }
}

