using MediatR;

namespace WebBanHang.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

