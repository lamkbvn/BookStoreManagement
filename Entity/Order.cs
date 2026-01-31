using System.ComponentModel.DataAnnotations;
using WebBanHang.Enum;

namespace WebBanHang.Entity
{

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
