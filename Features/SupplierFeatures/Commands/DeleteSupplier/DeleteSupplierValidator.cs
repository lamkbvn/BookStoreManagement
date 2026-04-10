using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Commands.DeleteSupplier
{
    public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeleteSupplierValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(ExistsAsync).WithMessage("Supplier not found");
        }

        private async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _supplierRepository.ExistsByIdAsync(id);
        }
    }
}

