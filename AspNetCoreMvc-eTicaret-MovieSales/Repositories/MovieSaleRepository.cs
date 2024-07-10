using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieSaleRepository : IMovieSaleRepository
    {
        private readonly MovieDbContext _context;

        public MovieSaleRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(MovieSale movieSale)
        {
            _context.MovieSales.Add(movieSale);    //ara katmana ekler.
            _context.SaveChanges(); //veritabanı güncellenir.
        }
        public int AddSale(MovieSale movieSale)
        {
            _context.MovieSales.Add(movieSale);    //ara katmana ekler.
            _context.SaveChanges(); //veritabanına kayıt edilir ve sql server tarafından otomatik olarak Id (PKey) verilir ve kayıt edilen nesneye atanır.
            return movieSale.Id;    //(Sql -> @@IDENTITY)
        }
        public void Delete(MovieSale movieSale)
        {
            _context.MovieSales.Remove(movieSale);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.MovieSales.Remove(Get(id));
            _context.SaveChanges();
        }
        public MovieSale Get(int id)
        {
            return _context.MovieSales.Find(id);
        }
        public List<MovieSale> GetAll()
        {
            return _context.MovieSales.ToList();
        }
        public void Update(MovieSale movieSale)
        {
            _context.MovieSales.Update(movieSale);
            _context.SaveChanges();
        }

    }
}
