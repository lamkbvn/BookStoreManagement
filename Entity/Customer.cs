using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime CreateAt { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
