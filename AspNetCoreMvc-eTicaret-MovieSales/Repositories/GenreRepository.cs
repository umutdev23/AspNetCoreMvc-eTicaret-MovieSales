using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDbContext _context;

        public GenreRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);    //ara katmana ekler.
            _context.SaveChanges(); //veritabanı güncellenir.
        }
        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Genres.Remove(Get(id));
            _context.SaveChanges();
        }
        public Genre Get(int id)
        {
            return _context.Genres.Find(id);
        }
        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }
}
