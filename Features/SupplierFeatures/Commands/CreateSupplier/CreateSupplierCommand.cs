using MediatR;

namespace WebBanHang.Features.SupplierFeatures.Commands.CreateSupplier
{
    public class CreateSupplierCommand : IRequest<CreateSupplierResult>
    {
        public string Name { get; set; } = "";
    }
}

