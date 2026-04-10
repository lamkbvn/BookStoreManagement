using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotions
{
    public class GetPromotionsHandler
        : IRequestHandler<GetPromotionsQuery, List<GetPromotionsResult>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_promotions";
        private const int CACHE_DURATION_MINUTES = 30;

        public GetPromotionsHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<GetPromotionsResult>> Handle(
            GetPromotionsQuery request,
            CancellationToken cancellationToken)
        {
            // Kiểm tra cache
            var cachedData = await _cache.GetStringAsync(CACHE_KEY, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<List<GetPromotionsResult>>(cachedData) ?? new List<GetPromotionsResult>();
            }

            // Nếu không có trong cache, lấy từ database
            var promotions = await _promotionRepository.GetAllAsync();
            var result = _mapper.Map<List<GetPromotionsResult>>(promotions);

            // Lưu vào cache với thời gian sống 30 phút
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CACHE_DURATION_MINUTES)
            };

            await _cache.SetStringAsync(CACHE_KEY, JsonSerializer.Serialize(result), options, cancellationToken);

            return result;
        }
    }
}
