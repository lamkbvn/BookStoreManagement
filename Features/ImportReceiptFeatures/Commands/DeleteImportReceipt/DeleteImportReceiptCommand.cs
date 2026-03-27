using MediatR;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.DeleteImportReceipt
{
    public class DeleteImportReceiptCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
