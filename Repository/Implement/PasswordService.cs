using Microsoft.AspNetCore.Identity;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Repository.Implement
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordService(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string inputPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                hashedPassword,
                inputPassword);

            return result == PasswordVerificationResult.Success;
        }
    }
}
