using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Commands.DeletePromotion
{
    public class DeletePromotionHandler
        : IRequestHandler<DeletePromotionCommand, bool>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_promotions";

        public DeletePromotionHandler(
            IPromotionRepository promotionRepository,
            IDistributedCache cache)
        {
            _promotionRepository = promotionRepository;
            _cache = cache;
        }

        public async Task<bool> Handle(
            DeletePromotionCommand request,
            CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new AppException($"Promotion with id {request.Id} not found", StatusCodes.Status404NotFound);

            if (!promotion.IsActive)
            {
                return true;
            }

            promotion.IsActive = false;
            await _promotionRepository.UpdateAsync(promotion);

            // Xóa cache khi deactive promotion
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            await _cache.RemoveAsync($"promotion_{request.Id}", cancellationToken);

            return true;
        }
    }
}
