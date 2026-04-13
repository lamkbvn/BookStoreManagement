using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;
using WebBanHang.Enum;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.DeleteImportReceipt
{
    public class DeleteImportReceiptHandler : IRequestHandler<DeleteImportReceiptCommand, Unit>
    {
        private readonly AppDbContext _dbContext;
        private readonly IImportReceiptRepository _importReceiptRepository;

        public DeleteImportReceiptHandler(AppDbContext dbContext, IImportReceiptRepository importReceiptRepository)
        {
            _dbContext = dbContext;
            _importReceiptRepository = importReceiptRepository;
        }

        public async Task<Unit> Handle(DeleteImportReceiptCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var receipt = await _importReceiptRepository.GetTrackedByIdAsync(request.Id);
                if (receipt == null)
                    throw new AppException("Phiếu nhập không tồn tại", 404);

                if (receipt.Status == ImportReceiptStatus.Approved)
                    throw new AppException("Phiếu nhập đã duyệt, không thể xóa", 400);

                await _importReceiptRepository.DeletePendingWithInventoryRollbackAsync(receipt);
                await transaction.CommitAsync(cancellationToken);
                return Unit.Value;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
