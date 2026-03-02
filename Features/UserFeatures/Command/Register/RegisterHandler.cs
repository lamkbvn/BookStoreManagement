using AutoMapper;
using MediatR;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Command.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public RegisterHandler(
            IUserRepository userRepository,
            IPasswordService passwordService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async Task<RegisterResult> Handle(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(registerCommand);

            user.Password = _passwordService.HashPassword(user, user.Password);

            await _userRepository.AddAsync(user);
            return _mapper.Map<RegisterResult>(user);
        }
    }
}
