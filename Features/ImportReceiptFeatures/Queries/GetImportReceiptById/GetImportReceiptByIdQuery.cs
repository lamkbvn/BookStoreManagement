using MediatR;

namespace WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceiptById
{
    public class GetImportReceiptByIdQuery : IRequest<GetImportReceiptByIdResult>
    {
        public int Id { get; set; }
    }
}
