using MediatR;

namespace WebBanHang.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdResult>
    {
        public int Id { get; set; }
    }
}

