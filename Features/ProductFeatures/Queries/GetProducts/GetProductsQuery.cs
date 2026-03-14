using MediatR;

namespace WebBanHang.Features.ProductFeatures.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<GetProductsResult>>
    {
    }
}

