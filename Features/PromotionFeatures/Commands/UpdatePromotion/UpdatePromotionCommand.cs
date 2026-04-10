using MediatR;
using System.Text.Json.Serialization;

namespace WebBanHang.Features.PromotionFeatures.Commands.UpdatePromotion
{
    public class UpdatePromotionCommand : IRequest<UpdatePromotionResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal MaximumDiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
