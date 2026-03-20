namespace WebBanHang.Features.InventoryFeatures.Queries.GetInventoryById
{
    public class GetInventoryByIdResult
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
