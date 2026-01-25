using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public Inventory Inventory { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
