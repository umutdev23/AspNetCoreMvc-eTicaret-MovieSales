using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieSaleDetailRepository : IMovieSaleDetailRepository
    {
        private readonly MovieDbContext _context;

        public MovieSaleDetailRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(MovieSaleDetail movieSaleDetail)
        {
            _context.MovieSaleDetails.Add(movieSaleDetail);    //ara katmana ekler.
            _context.SaveChanges(); //veritabanı güncellenir.
        }

        public bool AddRange(List<SepetDetay> sepet, int movieSaleId)
        {
            foreach (var item in sepet)
            {
                MovieSaleDetail newDetail = new MovieSaleDetail()
                {
                    MovieSaleId = movieSaleId,
                    MovieId = item.MovieId,
                    Number = item.MovieQuantity,
                    UnitPrice = item.MoviePrice
                };
                _context.MovieSaleDetails.Add(newDetail); //arakatmana ekler.
            }
            try
            {
                _context.SaveChanges(); //veritabanına hepsini birden gönderiyoruz. SaveChanges() metodunun transaction özelliğinden yararlanıyoruz.
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return false;
        }

        public void Delete(MovieSaleDetail movieSaleDetail)
        {
            _context.MovieSaleDetails.Remove(movieSaleDetail);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.MovieSaleDetails.Remove(Get(id));
            _context.SaveChanges();
        }
        public MovieSaleDetail Get(int id)
        {
            return _context.MovieSaleDetails.Find(id);
        }
        public List<MovieSaleDetail> GetAll()
        {
            return _context.MovieSaleDetails.ToList();
        }
        public void Update(MovieSaleDetail movieSaleDetail)
        {
            _context.MovieSaleDetails.Update(movieSaleDetail);
            _context.SaveChanges();
        }

    }
}
