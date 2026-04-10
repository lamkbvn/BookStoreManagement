using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(200).WithMessage("Product name max 200 characters")
                .MustAsync(BeUniqueName).WithMessage("Product name already exists");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0")
                .MustAsync(CategoryExists).WithMessage("Category not found");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("SupplierId must be greater than 0")
                .MustAsync(SupplierExists).WithMessage("Supplier not found");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
            => !await _productRepository.ExistsByNameAsync(name);

        private async Task<bool> CategoryExists(int categoryId, CancellationToken cancellationToken)
            => await _productRepository.CategoryExistsAsync(categoryId);

        private async Task<bool> SupplierExists(int supplierId, CancellationToken cancellationToken)
            => await _productRepository.SupplierExistsAsync(supplierId);
    }
}

