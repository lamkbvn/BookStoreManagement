namespace WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceipts
{
    public class GetImportReceiptsResult
    {
        public int Id { get; set; }
        public DateTime ImportDate { get; set; }
        public string? SupplierName { get; set; }
        public string? UserName { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
