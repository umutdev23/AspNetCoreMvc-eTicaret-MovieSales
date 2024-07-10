using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MovieDbContext _context;

        public CustomerRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);    //ara katmana ekler.
            _context.SaveChanges(); //veritabanı güncellenir.
        }
        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Customers.Remove(Get(id));
            _context.SaveChanges();
        }
        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

    }
}
