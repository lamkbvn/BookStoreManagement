using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Commands.UpdateSupplier
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplierValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(ExistsAsync).WithMessage("Supplier not found");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Supplier name is required")
                .MaximumLength(200).WithMessage("Supplier name max 200 characters")
                .MustAsync(BeUniqueName).WithMessage("Supplier name already exists");
        }

        private async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _supplierRepository.ExistsByIdAsync(id);
        }

        private async Task<bool> BeUniqueName(UpdateSupplierCommand command, string name, CancellationToken cancellationToken)
        {
            return !await _supplierRepository.ExistsByNameExceptIdAsync(name, command.Id);
        }
    }
}

