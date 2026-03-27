using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Enum;
using WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.ApproveImportReceipt
{
    public class ApproveImportReceiptHandler : IRequestHandler<ApproveImportReceiptCommand, CreateImportReceiptResult>
    {
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IMapper _mapper;

        public ApproveImportReceiptHandler(IImportReceiptRepository importReceiptRepository, IMapper mapper)
        {
            _importReceiptRepository = importReceiptRepository;
            _mapper = mapper;
        }

        public async Task<CreateImportReceiptResult> Handle(ApproveImportReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _importReceiptRepository.GetTrackedByIdAsync(request.Id);
            if (receipt == null)
                throw new AppException("Phiếu nhập không tồn tại", 404);

            if (receipt.Status == ImportReceiptStatus.Approved)
                throw new AppException("Phiếu nhập đã được duyệt", 400);

            receipt.Status = ImportReceiptStatus.Approved;
            await _importReceiptRepository.UpdateAsync(receipt);

            var result = await _importReceiptRepository.GetByIdAsync(receipt.Id);
            if (result == null)
                throw new AppException("Không thể tải phiếu nhập sau khi duyệt", 500);

            return _mapper.Map<CreateImportReceiptResult>(result);
        }
    }
}
