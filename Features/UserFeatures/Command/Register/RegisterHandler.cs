using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Command.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_users";

        public RegisterHandler(
            IUserRepository userRepository,
            IPasswordService passwordService,
            IMapper mapper,
            IDistributedCache cache)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<RegisterResult> Handle(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(registerCommand);
            user.Password = _passwordService.HashPassword(user, user.Password);
            await _userRepository.AddAsync(user);

            // Xóa cache khi đăng ký user mới
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);

            return _mapper.Map<RegisterResult>(user);
        }
    }
}
