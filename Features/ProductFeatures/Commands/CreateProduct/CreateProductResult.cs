namespace WebBanHang.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
    }
}

