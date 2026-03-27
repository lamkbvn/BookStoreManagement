using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Enum;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.DeleteImportReceipt
{
    public class DeleteImportReceiptHandler : IRequestHandler<DeleteImportReceiptCommand, Unit>
    {
        private readonly IImportReceiptRepository _importReceiptRepository;

        public DeleteImportReceiptHandler(IImportReceiptRepository importReceiptRepository)
        {
            _importReceiptRepository = importReceiptRepository;
        }

        public async Task<Unit> Handle(DeleteImportReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _importReceiptRepository.GetTrackedByIdAsync(request.Id);
            if (receipt == null)
                throw new AppException("Phiếu nhập không tồn tại", 404);

            if (receipt.Status == ImportReceiptStatus.Approved)
                throw new AppException("Phiếu nhập đã duyệt, không thể xóa", 400);

            await _importReceiptRepository.DeletePendingWithInventoryRollbackAsync(receipt);
            return Unit.Value;
        }
    }
}
