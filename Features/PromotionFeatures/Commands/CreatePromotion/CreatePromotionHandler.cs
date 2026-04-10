using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Commands.CreatePromotion
{
    public class CreatePromotionHandler
        : IRequestHandler<CreatePromotionCommand, CreatePromotionResult>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_promotions";

        public CreatePromotionHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<CreatePromotionResult> Handle(
            CreatePromotionCommand request,
            CancellationToken cancellationToken)
        {
            var promotion = new Promotion
            {
                Code = request.Code,
                Description = request.Description,
                DiscountPercentage = request.DiscountPercentage,
                MaximumDiscountAmount = request.MaximumDiscountAmount,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = request.IsActive
            };

            var createdPromotion = await _promotionRepository.AddAsync(promotion);

            // Xóa cache khi tạo promotion mới
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);

            return _mapper.Map<CreatePromotionResult>(createdPromotion);
        }
    }
}
