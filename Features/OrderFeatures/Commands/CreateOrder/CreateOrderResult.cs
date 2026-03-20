namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderResult
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string Status { get; set; } = "Pending";
        public string? PromotionCode { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public List<OrderItemResultDto> OrderItems { get; set; } = new();
    }
}
