using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IPasswordService
    {
        string HashPassword(User user, string password);
        bool VerifyPassword(User user, string hashedPassword, string inputPassword);
    }
}
