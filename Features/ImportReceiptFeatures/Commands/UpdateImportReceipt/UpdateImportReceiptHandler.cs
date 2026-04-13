using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Enum;
using WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.UpdateImportReceipt
{
    public class UpdateImportReceiptHandler : IRequestHandler<UpdateImportReceiptCommand, CreateImportReceiptResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IMapper _mapper;

        public UpdateImportReceiptHandler(
            AppDbContext dbContext,
            IImportReceiptRepository importReceiptRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _importReceiptRepository = importReceiptRepository;
            _mapper = mapper;
        }

        public async Task<CreateImportReceiptResult> Handle(UpdateImportReceiptCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var receipt = await _importReceiptRepository.GetTrackedByIdAsync(request.Id);
                if (receipt == null)
                    throw new AppException("Phiếu nhập không tồn tại", 404);

                if (receipt.Status == ImportReceiptStatus.Approved)
                    throw new AppException("Phiếu nhập đã duyệt, không thể sửa", 400);

                receipt.SupplierId = request.SupplierId;
                receipt.UserId = request.UserId;

                var newItems = request.ReceiptItems.Select(x => new ImportReceiptItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitCost = x.UnitCost
                }).ToList();

                await _importReceiptRepository.UpdatePendingWithInventoryAdjustmentAsync(receipt, newItems);

                var result = await _importReceiptRepository.GetByIdAsync(receipt.Id);
                if (result == null)
                    throw new AppException("Không thể tải phiếu nhập sau khi cập nhật", 500);

                await transaction.CommitAsync(cancellationToken);
                return _mapper.Map<CreateImportReceiptResult>(result);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
