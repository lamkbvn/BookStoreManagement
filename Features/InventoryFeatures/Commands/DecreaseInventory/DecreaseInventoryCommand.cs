using MediatR;
using System.Text.Json.Serialization;

namespace WebBanHang.Features.InventoryFeatures.Commands.DecreaseInventory
{
    public class DecreaseInventoryCommand : IRequest<DecreaseInventoryResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
