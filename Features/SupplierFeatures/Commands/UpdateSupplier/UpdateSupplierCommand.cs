using MediatR;
using System.Text.Json.Serialization;

namespace WebBanHang.Features.SupplierFeatures.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest<UpdateSupplierResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}

