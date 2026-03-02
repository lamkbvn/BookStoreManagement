using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Command.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;
        public RegisterValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Tên đăng nhập không được để trống")
                .MinimumLength(6).WithMessage("Tên đăng nhập tối thiểu 6 kí tự")
                .MustAsync(HasUsernameAsync).WithMessage("Tên đăng nhập đã tồn tại");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống")
                .MinimumLength(6).WithMessage("Mật khẩu tối thiểu 6 kí tự");
            RuleFor(x => x.Fullname)
                .NotEmpty().WithMessage("Tên người dùng không được để trống")
                .MinimumLength(12).WithMessage(" Tên người dùng tối thiểu 12 kí tự");
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role không được để trống")
                .IsInEnum().WithMessage("Role không hợp lệ");

        }

        private async Task<bool> HasUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return !await _userRepository.ExistsByUsernameAsync(username);
        }
    }
}
