using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, List<GetAllUserResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_users";
        private const int CACHE_DURATION_MINUTES = 30;

        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper, IDistributedCache cache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<GetAllUserResult>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            // Kiểm tra cache
            var cachedData = await _cache.GetStringAsync(CACHE_KEY, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<List<GetAllUserResult>>(cachedData) ?? new List<GetAllUserResult>();
            }

            // Nếu không có trong cache, lấy từ database
            var listUser = await _userRepository.GetAll();
            var result = _mapper.Map<List<GetAllUserResult>>(listUser);

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
