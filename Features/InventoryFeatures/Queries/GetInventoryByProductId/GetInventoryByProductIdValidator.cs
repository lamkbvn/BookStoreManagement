using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryByProductId
{
    public class GetInventoryByProductIdValidator
        : AbstractValidator<GetInventoryByProductIdQuery>
    {
        private readonly IProductRepository _productRepository;

        public GetInventoryByProductIdValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required")
                .MustAsync(ProductExistsAsync).WithMessage("Product does not exist");
        }

        private async Task<bool> ProductExistsAsync(int productId, CancellationToken cancellationToken)
        {
            return await _productRepository.ExistsByIdAsync(productId);
        }
    }
}
