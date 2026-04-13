namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomerById
{
    public class GetCustomerByIdResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
