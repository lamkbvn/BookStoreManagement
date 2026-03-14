namespace WebBanHang.Features.ProductFeatures.Queries.GetProducts
{
    public class GetProductsResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = "";
        public int Quantity { get; set; }
    }
}

