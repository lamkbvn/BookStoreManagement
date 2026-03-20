using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.UpdateInventory
{
    public class UpdateInventoryValidator
        : AbstractValidator<UpdateInventoryCommand>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public UpdateInventoryValidator(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .MustAsync(InventoryExistsAsync).WithMessage("Inventory does not exist");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0")
                .LessThanOrEqualTo(10000).WithMessage("Quantity must not exceed 10000");
        }

        private async Task<bool> InventoryExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.ExistsByIdAsync(id);
        }
    }
}
