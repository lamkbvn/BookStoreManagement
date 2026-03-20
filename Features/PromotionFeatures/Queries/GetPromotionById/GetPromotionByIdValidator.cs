using FluentValidation;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotionById
{
    public class GetPromotionByIdValidator : AbstractValidator<GetPromotionByIdQuery>
    {
        public GetPromotionByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Promotion ID must be greater than 0");
        }
    }
}
