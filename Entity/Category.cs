using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
