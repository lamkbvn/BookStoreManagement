using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Command.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_users";

        public UpdateUserHandler(IUserRepository userRepository, IPasswordService passwordService, IMapper mapper, IDistributedCache cache)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<UpdateUserResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindById(request.Id);
            if (user == null)
                throw new AppException($"User với {request.Id} không tồn tại", 404);

            user.Password = _passwordService.HashPassword(user, request.Password);
            user.Fullname = request.Fullname;
            user.Role = request.Role;

            await _userRepository.UpdateAsync(user);

            // Xóa cache khi cập nhật user
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            await _cache.RemoveAsync($"user_{request.Id}", cancellationToken);

            return _mapper.Map<UpdateUserResult>(user);
        }
    }
}
