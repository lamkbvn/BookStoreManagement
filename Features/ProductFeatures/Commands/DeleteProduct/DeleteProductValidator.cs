using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(Exists).WithMessage("Product not found");
        }

        private async Task<bool> Exists(int id, CancellationToken cancellationToken)
            => await _productRepository.ExistsByIdAsync(id);
    }
}

