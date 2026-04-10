using MediatR;

namespace WebBanHang.Features.SupplierFeatures.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

