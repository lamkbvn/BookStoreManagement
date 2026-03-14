using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(Exists).WithMessage("Product not found");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(200).WithMessage("Product name max 200 characters")
                .MustAsync(BeUniqueName).WithMessage("Product name already exists");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be >= 0");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0")
                .MustAsync(CategoryExists).WithMessage("Category not found");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("SupplierId must be greater than 0")
                .MustAsync(SupplierExists).WithMessage("Supplier not found");
        }

        private async Task<bool> Exists(int id, CancellationToken cancellationToken)
            => await _productRepository.ExistsByIdAsync(id);

        private async Task<bool> BeUniqueName(UpdateProductCommand cmd, string name, CancellationToken cancellationToken)
            => !await _productRepository.ExistsByNameExceptIdAsync(name, cmd.Id);

        private async Task<bool> CategoryExists(int categoryId, CancellationToken cancellationToken)
            => await _productRepository.CategoryExistsAsync(categoryId);

        private async Task<bool> SupplierExists(int supplierId, CancellationToken cancellationToken)
            => await _productRepository.SupplierExistsAsync(supplierId);
    }
}

