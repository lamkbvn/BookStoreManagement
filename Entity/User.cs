using System.ComponentModel.DataAnnotations;
using WebBanHang.Enum;

namespace WebBanHang.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Fullname { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public Role Role { get; set; } = Role.Admin;
    }
}
