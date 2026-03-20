namespace WebBanHang.Features.OrderFeatures.Commands.UpdateOrder
{
    public class UpdateOrderResult
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string? CustomerName { get; set; }
        public string? UserName { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}
