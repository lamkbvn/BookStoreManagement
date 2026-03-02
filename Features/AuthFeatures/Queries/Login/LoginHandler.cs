using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.AuthFeatures.Queries.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public LoginHandler(IMapper mapper, IUserRepository userRepository, IAuthRepository authRepository, IPasswordService passwordService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _passwordService = passwordService;
        }
        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByUsernameAsync(request.username);

            if (user == null)
                throw new AppException("Tài khoản không tồn tại", 404);

            var isValid = _passwordService.VerifyPassword(
                            user,
                            user.Password,
                            request.password);

            if (!isValid)
                throw new AppException("Mật khẩu không chính xác", 401);


            string token = _authRepository.GenerateJwt(user);

            return new LoginResult { accesstoken = token };
        }
    }
}
