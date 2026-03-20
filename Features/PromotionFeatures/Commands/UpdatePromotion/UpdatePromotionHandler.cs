using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Commands.UpdatePromotion
{
    public class UpdatePromotionHandler
        : IRequestHandler<UpdatePromotionCommand, UpdatePromotionResult>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public UpdatePromotionHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePromotionResult> Handle(
            UpdatePromotionCommand request,
            CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new InvalidOperationException($"Promotion with id {request.Id} not found");

            promotion.Code = request.Code;
            promotion.Description = request.Description;
            promotion.DiscountPercentage = request.DiscountPercentage;
            promotion.MaximumDiscountAmount = request.MaximumDiscountAmount;
            promotion.StartDate = request.StartDate;
            promotion.EndDate = request.EndDate;
            promotion.IsActive = request.IsActive;

            var updatedPromotion = await _promotionRepository.UpdateAsync(promotion);
            return _mapper.Map<UpdatePromotionResult>(updatedPromotion);
        }
    }
}
