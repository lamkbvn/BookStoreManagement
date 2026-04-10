using FluentValidation;
using WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.UpdateImportReceipt
{
    public class UpdateImportReceiptValidator : AbstractValidator<UpdateImportReceiptCommand>
    {
        private readonly IImportReceiptRepository _importReceiptRepository;

        public UpdateImportReceiptValidator(IImportReceiptRepository importReceiptRepository)
        {
            _importReceiptRepository = importReceiptRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(ReceiptExistsAsync).WithMessage("Import receipt does not exist");

            RuleFor(x => x.SupplierId)
                .NotEmpty().WithMessage("SupplierId is required")
                .GreaterThan(0).WithMessage("SupplierId must be greater than 0")
                .MustAsync(SupplierExistsAsync).WithMessage("Supplier does not exist");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required")
                .GreaterThan(0).WithMessage("UserId must be greater than 0")
                .MustAsync(UserExistsAsync).WithMessage("User does not exist");

            RuleFor(x => x.ReceiptItems)
                .NotEmpty().WithMessage("ReceiptItems cannot be empty")
                .Must(x => x.Count > 0).WithMessage("At least one ReceiptItem is required")
                .Must(HaveDistinctProducts).WithMessage("Duplicate products are not allowed in one receipt");

            RuleForEach(x => x.ReceiptItems)
                .SetValidator(new CreateImportReceiptItemValidator(_importReceiptRepository));

            RuleFor(x => x).CustomAsync(ValidateProductsBelongToSupplierAsync);
        }

        private async Task<bool> ReceiptExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _importReceiptRepository.ExistsByIdAsync(id);
        }

        private async Task<bool> SupplierExistsAsync(int supplierId, CancellationToken cancellationToken)
        {
            return await _importReceiptRepository.SupplierExistsAsync(supplierId);
        }

        private async Task<bool> UserExistsAsync(int userId, CancellationToken cancellationToken)
        {
            return await _importReceiptRepository.UserExistsAsync(userId);
        }

        private static bool HaveDistinctProducts(List<CreateImportReceiptItemDto> items)
        {
            return items.Select(x => x.ProductId).Distinct().Count() == items.Count;
        }

        private async Task ValidateProductsBelongToSupplierAsync(
            UpdateImportReceiptCommand command,
            ValidationContext<UpdateImportReceiptCommand> context,
            CancellationToken cancellationToken)
        {
            for (var i = 0; i < command.ReceiptItems.Count; i++)
            {
                var item = command.ReceiptItems[i];
                var belongs = await _importReceiptRepository.IsProductOfSupplierAsync(item.ProductId, command.SupplierId);
                if (belongs) continue;

                context.AddFailure(
                    $"ReceiptItems[{i}].ProductId",
                    $"ProductId {item.ProductId} không thuộc SupplierId {command.SupplierId}");
            }
        }
    }
}
