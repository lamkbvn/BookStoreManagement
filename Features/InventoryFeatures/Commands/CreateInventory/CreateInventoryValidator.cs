using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.CreateInventory
{
    public class CreateInventoryValidator
        : AbstractValidator<CreateInventoryCommand>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;

        public CreateInventoryValidator(
            IInventoryRepository inventoryRepository,
            IProductRepository productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required")
                .MustAsync(ProductExistsAsync).WithMessage("Product does not exist");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0")
                .LessThanOrEqualTo(10000).WithMessage("Quantity must not exceed 10000");

            RuleFor(x => x.ProductId)
                .MustAsync(ProductNotHaveInventoryAsync).WithMessage("Product already has inventory");
        }

        private async Task<bool> ProductExistsAsync(int productId, CancellationToken cancellationToken)
        {
            return await _productRepository.ExistsByIdAsync(productId);
        }

        private async Task<bool> ProductNotHaveInventoryAsync(int productId, CancellationToken cancellationToken)
        {
            return !await _inventoryRepository.ExistsByProductIdAsync(productId);
        }
    }
}
