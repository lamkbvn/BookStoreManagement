using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.DeleteImportReceipt
{
    public class DeleteImportReceiptValidator : AbstractValidator<DeleteImportReceiptCommand>
    {
        private readonly IImportReceiptRepository _importReceiptRepository;

        public DeleteImportReceiptValidator(IImportReceiptRepository importReceiptRepository)
        {
            _importReceiptRepository = importReceiptRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(ReceiptExistsAsync).WithMessage("Import receipt does not exist");
        }

        private async Task<bool> ReceiptExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _importReceiptRepository.ExistsByIdAsync(id);
        }
    }
}
