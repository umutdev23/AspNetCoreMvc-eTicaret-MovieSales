using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Interfaces
{
    public interface IMovieSaleRepository
    {
        public List<MovieSale> GetAll();
        public MovieSale Get(int id);
        public void Add(MovieSale movieSale);
        public int AddSale(MovieSale movieSale);
        public void Update(MovieSale movieSale);
        public void Delete(MovieSale movieSale);
        public void Delete(int id);
    }
}
