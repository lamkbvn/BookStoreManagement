using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Queries.GetOrderById
{
    public class GetOrderByIdValidator
        : AbstractValidator<GetOrderByIdQuery>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdValidator(IOrderRepository orderRepository)
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
