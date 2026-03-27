using MediatR;
using WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.UpdateImportReceipt
{
    public class UpdateImportReceiptCommand : IRequest<CreateImportReceiptResult>
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public List<CreateImportReceiptItemDto> ReceiptItems { get; set; } = new();
    }
}
