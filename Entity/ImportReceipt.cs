using System.ComponentModel.DataAnnotations;
using WebBanHang.Enum;

namespace WebBanHang.Entity
{
    public class ImportReceipt
    {
        [Key]
        public int Id { get; set; }
        public DateTime ImportDate { get; set; } = DateTime.Now;

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public decimal TotalAmount { get; set; } = 0;
        public ImportReceiptStatus Status { get; set; } = ImportReceiptStatus.Pending;

        public ICollection<ImportReceiptItem> ReceiptItems { get; set; } = new List<ImportReceiptItem>();
    }
}
