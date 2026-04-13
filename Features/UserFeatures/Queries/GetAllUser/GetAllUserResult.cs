using WebBanHang.Enum;

namespace WebBanHang.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserResult
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public Role Role { get; set; }
    }
}
