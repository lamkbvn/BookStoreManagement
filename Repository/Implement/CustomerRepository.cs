using Microsoft.EntityFrameworkCore;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Repository.Implement
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) { _context = context; }


        public async Task<Customer?> GetByIdAsync(int id) => await _context.Customers.FindAsync(id);
        public async Task<IEnumerable<Customer>> GetAllAsync() => await _context.Customers.ToListAsync();
        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> CheckExistPhoneNumber(string phoneNumber)
        {
            return await _context.Customers.AnyAsync(c => c.Phone == phoneNumber);

        }
    }
}
