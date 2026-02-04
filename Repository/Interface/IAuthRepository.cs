using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IAuthRepository
    {
        string GenerateJwt(User user);
    }
}
