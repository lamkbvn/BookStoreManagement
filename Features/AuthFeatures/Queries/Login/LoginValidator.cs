using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.AuthFeatures.Queries.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        private readonly IUserRepository _userRepository;
        public LoginValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.username)
                .NotEmpty().WithMessage("Tên đăng nhập không được để trống")
                .MinimumLength(6).WithMessage("Tên đăng nhập tối thiểu 6 kí tự")
                .MustAsync(ExistByUsernameAsync).WithMessage("Tên đăng nhập không tồn tại");
            RuleFor(x => x.password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống")
                .MinimumLength(6).WithMessage("Mật khẩu tối thiểu 6 kí tự")
                .MustAsync(CheckPassword).WithMessage("Mật khẩu không chính xác");
        }

        private async Task<bool> ExistByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _userRepository.ExistsByUsernameAsync(username);
        }

        private async Task<bool> CheckPassword(LoginCommand command, string password, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByUsernameAsync(command.username);

            return user?.Password == password;

        }
    }
}
