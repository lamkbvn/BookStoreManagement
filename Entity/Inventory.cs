using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
