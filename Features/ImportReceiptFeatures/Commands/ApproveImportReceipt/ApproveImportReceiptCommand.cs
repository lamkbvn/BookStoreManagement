using MediatR;
using WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.ApproveImportReceipt
{
    public class ApproveImportReceiptCommand : IRequest<CreateImportReceiptResult>
    {
        public int Id { get; set; }
    }
}
