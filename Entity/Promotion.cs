using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
