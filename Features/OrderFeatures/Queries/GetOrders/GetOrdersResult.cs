namespace WebBanHang.Features.OrderFeatures.Queries.GetOrders
{
    public class GetOrdersResult
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string? CustomerName { get; set; }
        public string? UserName { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? PromotionCode { get; set; }
        public int ItemCount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
