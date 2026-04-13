using WebBanHang.Enum;

namespace WebBanHang.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdResult
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public Role Role { get; set; }
    }
}
