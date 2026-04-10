using MediatR;
using System.Text.Json.Serialization;

namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public int CustomerId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public int? PromotionId { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; } = new();
    }
}
