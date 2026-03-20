using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderValidator
        : AbstractValidator<CreateOrderCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateOrderValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

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

            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("UnitPrice is required")
                .GreaterThan(0).WithMessage("UnitPrice must be greater than 0");
        }
    }
}
