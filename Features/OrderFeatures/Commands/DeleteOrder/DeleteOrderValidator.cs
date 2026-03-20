using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.DeleteOrder
{
    public class DeleteOrderValidator
        : AbstractValidator<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .MustAsync(OrderExistsAsync).WithMessage("Order does not exist");
        }

        private async Task<bool> OrderExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _orderRepository.ExistsByIdAsync(id);
        }
    }
}
