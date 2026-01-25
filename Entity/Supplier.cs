using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
