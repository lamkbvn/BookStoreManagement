namespace WebBanHang.Features.InventoryFeatures.Commands.UpdateInventory
{
    public class UpdateInventoryResult
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
