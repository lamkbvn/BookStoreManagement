namespace WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt
{
    public class CreateImportReceiptResult
    {
        public int Id { get; set; }
        public DateTime ImportDate { get; set; }
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string Status { get; set; } = "Pending";
        public int ItemCount { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ImportReceiptItemResultDto> ReceiptItems { get; set; } = new();
    }
}
