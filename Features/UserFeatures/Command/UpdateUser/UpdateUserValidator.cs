using FluentValidation;

namespace WebBanHang.Features.UserFeatures.Command.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
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
    }
}
