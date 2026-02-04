using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.AuthFeatures.Queries.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public LoginHandler(IMapper mapper, IUserRepository userRepository, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _authRepository = authRepository;
        }
        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByUsernameAsync(request.username);

            if (user == null)
                throw new AppException("Tài khoản không tồn tại", 404);
            string token = _authRepository.GenerateJwt(user);

            return new LoginResult { accesstoken = token };
        }
    }
}
