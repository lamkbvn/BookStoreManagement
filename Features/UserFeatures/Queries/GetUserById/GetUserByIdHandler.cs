using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand, GetUserByIdResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const int CACHE_DURATION_MINUTES = 30;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper, IDistributedCache cache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<GetUserByIdResult> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"user_{request.Id}";

            // Kiểm tra cache
            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<GetUserByIdResult>(cachedData) 
                    ?? throw new AppException($"User với id là {request.Id} không tồn tại", 404);
            }

            var user = await _userRepository.FindById(request.Id);

            if (user == null)
                throw new AppException($"User với id là {request.Id} không tồn tại", 404);

            var result = _mapper.Map<GetUserByIdResult>(user);

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
