namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryByProductId
{
    public class GetInventoryByProductIdResult
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
