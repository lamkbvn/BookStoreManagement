using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.UpdateOrder
{
    public class UpdateOrderValidator
        : AbstractValidator<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .MustAsync(OrderExistsAsync).WithMessage("Order does not exist");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required")
                .Must(x => x == "Pending" || x == "Paid" || x == "Cancelled")
                .WithMessage("Status must be Pending, Paid, or Cancelled");
        }

        private async Task<bool> OrderExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _orderRepository.ExistsByIdAsync(id);
        }
    }
}
