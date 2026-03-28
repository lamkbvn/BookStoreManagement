using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotionById
{
    public class GetPromotionByIdHandler
        : IRequestHandler<GetPromotionByIdQuery, GetPromotionByIdResult>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const int CACHE_DURATION_MINUTES = 30;

        public GetPromotionByIdHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<GetPromotionByIdResult> Handle(
            GetPromotionByIdQuery request,
            CancellationToken cancellationToken)
        {
            var cacheKey = $"promotion_{request.Id}";

            // Kiểm tra cache
            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<GetPromotionByIdResult>(cachedData) 
                    ?? throw new InvalidOperationException($"Promotion with id {request.Id} not found");
            }

            var promotion = await _promotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new InvalidOperationException($"Promotion with id {request.Id} not found");

            var result = _mapper.Map<GetPromotionByIdResult>(promotion);

            // Lưu vào cache
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CACHE_DURATION_MINUTES)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), options, cancellationToken);

            return result;
        }
    }
}
