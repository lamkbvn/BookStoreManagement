using MediatR;
using System.Text.Json.Serialization;

namespace WebBanHang.Features.OrderFeatures.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<UpdateOrderResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
