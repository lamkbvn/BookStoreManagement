using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Commands.DeleteSupplier
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand, Unit>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeleteSupplierHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (supplier is null)
                throw new AppException("Supplier not found", StatusCodes.Status404NotFound);

            await _supplierRepository.DeleteAsync(supplier);

            return Unit.Value;
        }
    }
}

