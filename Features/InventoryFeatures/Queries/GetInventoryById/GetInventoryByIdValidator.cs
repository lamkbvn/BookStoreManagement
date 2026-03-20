using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryById
{
    public class GetInventoryByIdValidator
        : AbstractValidator<GetInventoryByIdQuery>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public GetInventoryByIdValidator(IInventoryRepository inventoryRepository)
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
