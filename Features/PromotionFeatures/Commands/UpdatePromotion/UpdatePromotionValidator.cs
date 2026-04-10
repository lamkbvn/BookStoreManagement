using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Commands.UpdatePromotion
{
    public class UpdatePromotionValidator : AbstractValidator<UpdatePromotionCommand>
    {
        private readonly IPromotionRepository _promotionRepository;

        public UpdatePromotionValidator(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Promotion ID must be greater than 0");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Promotional code is required")
                .MaximumLength(50).WithMessage("Promotional code must not exceed 50 characters")
                .MustAsync(BeUniqueCodeAsync).WithMessage("Promotion code already exists");

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

        private async Task<bool> BeUniqueCodeAsync(UpdatePromotionCommand command, string code, CancellationToken cancellationToken)
        {
            return !await _promotionRepository.ExistsByCodeExceptIdAsync(code, command.Id);
        }
    }
}
