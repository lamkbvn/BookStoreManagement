using MediatR;

namespace WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceipts
{
    public class GetImportReceiptsQuery : IRequest<List<GetImportReceiptsResult>>
    {
    }
}
