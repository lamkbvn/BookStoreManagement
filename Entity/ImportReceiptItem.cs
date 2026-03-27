using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class ImportReceiptItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }

        public int ImportReceiptId { get; set; }
        public ImportReceipt ImportReceipt { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
