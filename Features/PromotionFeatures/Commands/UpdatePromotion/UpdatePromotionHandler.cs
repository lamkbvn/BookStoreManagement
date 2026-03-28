using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Commands.UpdatePromotion
{
    public class UpdatePromotionHandler
        : IRequestHandler<UpdatePromotionCommand, UpdatePromotionResult>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_promotions";

        public UpdatePromotionHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
            _cache = cache;
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

            // Xóa cache khi cập nhật promotion
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            await _cache.RemoveAsync($"promotion_{request.Id}", cancellationToken);

            return _mapper.Map<UpdatePromotionResult>(updatedPromotion);
        }
    }
}
