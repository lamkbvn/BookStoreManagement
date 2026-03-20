using MediatR;

namespace WebBanHang.Features.PromotionFeatures.Commands.UpdatePromotion
{
    public class UpdatePromotionCommand : IRequest<UpdatePromotionResult>
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal MaximumDiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
