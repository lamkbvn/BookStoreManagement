using FluentValidation;

namespace WebBanHang.Features.PromotionFeatures.Commands.DeletePromotion
{
    public class DeletePromotionValidator : AbstractValidator<DeletePromotionCommand>
    {
        public DeletePromotionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Promotion ID must be greater than 0");
        }
    }
}
