namespace WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt
{
    public class CreateImportReceiptItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}
