using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderValidator
        : AbstractValidator<CreateOrderCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IPromotionRepository _promotionRepository;

        public CreateOrderValidator(
            IProductRepository productRepository,
            IPromotionRepository promotionRepository)
        {
            _productRepository = productRepository;
            _promotionRepository = promotionRepository;

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required")
                .GreaterThan(0).WithMessage("CustomerId must be greater than 0");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required")
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage("OrderItems cannot be empty")
                .Must(x => x.Count > 0).WithMessage("At least one OrderItem is required");

            RuleForEach(x => x.OrderItems)
                .SetValidator(new CreateOrderItemValidator(_productRepository));

            RuleFor(x => x.PromotionId)
                .MustAsync(PromotionExistsAsync)
                .When(x => x.PromotionId.HasValue && x.PromotionId.Value > 0)
                .WithMessage("Promotion does not exist");
        }

        private async Task<bool> PromotionExistsAsync(int? promotionId, CancellationToken cancellationToken)
        {
            if (!promotionId.HasValue)
            {
                return true;
            }

            return await _promotionRepository.ExistsByIdAsync(promotionId.Value);
        }
    }

    public class CreateOrderItemValidator
        : AbstractValidator<CreateOrderItemDto>
    {
        public CreateOrderItemValidator(IProductRepository productRepository)
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required")
                .GreaterThan(0).WithMessage("ProductId must be greater than 0")
                .MustAsync(async (productId, ct) => await productRepository.ExistsByIdAsync(productId))
                .WithMessage("Product does not exist");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0")
                .LessThanOrEqualTo(10000).WithMessage("Quantity must not exceed 10000");
        }
    }
}
