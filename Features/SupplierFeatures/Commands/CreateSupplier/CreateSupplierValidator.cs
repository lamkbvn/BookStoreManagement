using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Commands.CreateSupplier
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Supplier name is required")
                .MaximumLength(200).WithMessage("Supplier name max 200 characters")
                .MustAsync(BeUniqueName).WithMessage("Supplier name already exists");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return !await _supplierRepository.ExistsByNameAsync(name);
        }
    }
}

