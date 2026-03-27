using MediatR;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt
{
    public class CreateImportReceiptCommand : IRequest<CreateImportReceiptResult>
    {
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public List<CreateImportReceiptItemDto> ReceiptItems { get; set; } = new();
    }
}
