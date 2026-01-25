using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public required string Code { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
