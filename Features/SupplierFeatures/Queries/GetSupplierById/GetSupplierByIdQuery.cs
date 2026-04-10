using MediatR;

namespace WebBanHang.Features.SupplierFeatures.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery : IRequest<GetSupplierByIdResult>
    {
        public int Id { get; set; }
    }
}

