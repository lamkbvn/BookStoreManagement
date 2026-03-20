namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class OrderItemResultDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
