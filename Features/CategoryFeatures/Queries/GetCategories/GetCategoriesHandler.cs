using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Queries.GetCategories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_categories";
        private const int CACHE_DURATION_MINUTES = 30;

        public GetCategoriesHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<GetCategoriesResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // Kiểm tra cache
            var cachedData = await _cache.GetStringAsync(CACHE_KEY, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<List<GetCategoriesResult>>(cachedData) ?? new List<GetCategoriesResult>();
            }

            // Nếu không có trong cache, lấy từ database
            var categories = await _categoryRepository.GetAllAsync();
            var result = _mapper.Map<List<GetCategoriesResult>>(categories);

            // Lưu vào cache
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CACHE_DURATION_MINUTES)
            };

            await _cache.SetStringAsync(CACHE_KEY, JsonSerializer.Serialize(result), options, cancellationToken);

            return result;
        }
    }
}

