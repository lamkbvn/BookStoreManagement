using FluentValidation;

namespace WebBanHang.Features.PromotionFeatures.Commands.CreatePromotion
{
    public class CreatePromotionValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Promotional code is required")
                .MaximumLength(50).WithMessage("Promotional code must not exceed 50 characters");

            RuleFor(x => x.DiscountPercentage)
                .GreaterThan(0).WithMessage("Discount percentage must be greater than 0")
                .LessThanOrEqualTo(100).WithMessage("Discount percentage must not exceed 100");

            RuleFor(x => x.MaximumDiscountAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Maximum discount amount must be greater than or equal to 0");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date");
        }
    }
}
