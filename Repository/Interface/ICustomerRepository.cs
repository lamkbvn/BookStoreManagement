using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> Update(Customer customer);

        Task<bool> CheckExistPhoneNumber(string phoneNumber);
    }
}
