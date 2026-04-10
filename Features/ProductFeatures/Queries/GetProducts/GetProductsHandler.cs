using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Queries.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<GetProductsResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_products";
        private const int CACHE_DURATION_MINUTES = 30;

        public GetProductsHandler(IProductRepository productRepository, IMapper mapper, IDistributedCache cache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<GetProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            // Kiểm tra cache
            var cachedData = await _cache.GetStringAsync(CACHE_KEY, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<List<GetProductsResult>>(cachedData) ?? new List<GetProductsResult>();
            }

            // Nếu không có trong cache, lấy từ database
            var products = await _productRepository.GetAllAsync();
            var result = _mapper.Map<List<GetProductsResult>>(products);

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

