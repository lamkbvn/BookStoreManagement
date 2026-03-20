using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Commands.DeleteInventory
{
    public class DeleteInventoryValidator
        : AbstractValidator<DeleteInventoryCommand>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public DeleteInventoryValidator(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .MustAsync(InventoryExistsAsync).WithMessage("Inventory does not exist");
        }

        private async Task<bool> InventoryExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.ExistsByIdAsync(id);
        }
    }
}
