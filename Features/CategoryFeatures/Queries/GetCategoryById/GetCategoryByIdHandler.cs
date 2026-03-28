using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const int CACHE_DURATION_MINUTES = 30;

        public GetCategoryByIdHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<GetCategoryByIdResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"category_{request.Id}";

            // Kiểm tra cache
            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<GetCategoryByIdResult>(cachedData) 
                    ?? throw new AppException("Category not found", StatusCodes.Status404NotFound);
            }

            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category is null)
            {
                throw new AppException("Category not found", StatusCodes.Status404NotFound);
            }

            var result = _mapper.Map<GetCategoryByIdResult>(category);

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

