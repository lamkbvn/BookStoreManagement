using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Queries.GetSupplierById
{
    public class GetSupplierByIdValidator : AbstractValidator<GetSupplierByIdQuery>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierByIdValidator(ISupplierRepository supplierRepository)
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

