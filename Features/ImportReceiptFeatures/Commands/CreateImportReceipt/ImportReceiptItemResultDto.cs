namespace WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt
{
    public class ImportReceiptItemResultDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal SubTotal { get; set; }
    }
}
