using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User?> FindByUsernameAsync(string username);
        Task<bool> ExistsByUsernameAsync(string username);
    }
}
