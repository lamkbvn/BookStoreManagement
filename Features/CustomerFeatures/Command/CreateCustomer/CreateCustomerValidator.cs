using FluentValidation;

namespace WebBanHang.Features.CustomerFeatures.Command.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Tên người dùng không được để trống")
              .MinimumLength(10).WithMessage("Tên người dùng có tối thiểu 10 kí tự");
            RuleFor(x => x.Phone)
              .NotEmpty().WithMessage("Số điện thoại không được để trống")
              .Length(10).WithMessage("Số điện thoại bao gồm 10 số");

        }
    }
}
