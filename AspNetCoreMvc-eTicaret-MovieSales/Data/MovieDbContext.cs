using AspNetCoreMvc_eTicaret_MovieSales.Models;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;

namespace AspNetCoreMvc_eTicaret_MovieSales.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MovieSale> MovieSales { get; set; }
        public DbSet<MovieSaleDetail> MovieSaleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API validation
            modelBuilder.Entity<Genre>().
                Property(g => g.Name).HasMaxLength(100);
            modelBuilder.Entity<Movie>().
                Property(m => m.Name).HasMaxLength(200);
            modelBuilder.Entity<Movie>().
                Property(m => m.IsPopuler).HasDefaultValue(true);
            modelBuilder.Entity<Customer>().
                Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Movie>().
                Property(m => m.ImageUrl).HasDefaultValue("/images/filmadi.jpg");

            //Seed Data
            modelBuilder.Entity<Genre>().HasData(
                    new Genre() { Id = 1, Name = "Komedi", Description = "Komik olaylar"},
                    new Genre() { Id = 2, Name = "Savaş", Description = "Tarihi savaşlar, kan, şiddet" },
                    new Genre() { Id = 3, Name = "Romantik Komedi", Description = "Hem romantik hem komik" },
                    new Genre() { Id = 4, Name = "Dram", Description = "Acıklı hikayeler" },
                    new Genre() { Id = 5, Name = "Korku", Description = "Korku, gerilim" },
                    new Genre() { Id = 6, Name = "Bilim Kurgu", Description = "Robotlar, uzay" },
                    new Genre() { Id = 7, Name = "Fantastik", Description = "Gerçek dışı, heyecanlı" },
                    new Genre() { Id = 8, Name = "Aksiyon", Description = "Hareket, aksiyon dolu sahneler" }
                );
            modelBuilder.Entity<Movie>().HasData(
            new Movie() { Id = 1, Name = "Truva", Director = "Wolfgan Pettersen", Cast = "Bradd Pitt, Orlando Bloom", Stock = 12, Price = 350, Summary = "Tarihten Truva savaşından kesitler", ReleaseDate = Convert.ToDateTime("01.01.1992"), ImageUrl = "/images/truva.jpg", GenreId = 2 },
            new Movie() { Id = 2, Name = "Baskın", Director = "Gareth Evans", Cast = "Ananda George, Donny Alamsyah", Stock = 10, Price = 340, Summary = "Operasyon timinin uyuşturucu baskınları", ReleaseDate = Convert.ToDateTime("01.01.1998"), ImageUrl = "/images/baskin.jpg", GenreId = 8 },
            new Movie() { Id = 3, Name = "Titanic", Director = "James Cameron", Cast = "Leonardo Di Caprio, Cate Winslet", Stock = 15, Price = 320, Summary = "Lüks Titanic gemisinin hazin öyküsü", ReleaseDate = Convert.ToDateTime("01.01.1999"), ImageUrl = "/images/titanic.jpg", GenreId = 4 },
            new Movie() { Id = 4, Name = "Fight Club", Director = "David Lyinch", Cast = "Bradd Pitt, Edward Norton", Stock = 10, Price = 330, Summary = "Dövüş kulübü, ilk kural bahsetmemek", ReleaseDate = Convert.ToDateTime("01.01.2002"), ImageUrl = "/images/fight.jpg", GenreId = 8 },
            new Movie() { Id = 5, Name = "Soysuzlar Çetesi", Director = "Quantin Tarantino", Cast = "Bradd Pitt, Christoph Wals", Stock = 20, Price = 310, Summary = "2.Dünya savaşından kesitler", ReleaseDate = Convert.ToDateTime("01.01.2006"), ImageUrl = "/images/soysuzlar.jpg", GenreId = 2 },
            new Movie() { Id = 6, Name = "Soysuzlar Çetesi", Director = "Quantin Tarantino", Cast = "Bradd Pitt, Christoph Wals", Stock = 20, Price = 310, Summary = "2.Dünya savaşından kesitler", ReleaseDate = Convert.ToDateTime("01.01.2006"), ImageUrl = "/images/soysuzlar.jpg", GenreId = 2 },
            new Movie() { Id = 7, Name = "Soysuzlar Çetesi", Director = "Quantin Tarantino", Cast = "Bradd Pitt, Christoph Wals", Stock = 20, Price = 310, Summary = "2.Dünya savaşından kesitler", ReleaseDate = Convert.ToDateTime("01.01.2006"), ImageUrl = "/images/soysuzlar.jpg", GenreId = 2 },
            new Movie() { Id = 8, Name = "Soysuzlar Çetesi", Director = "Quantin Tarantino", Cast = "Bradd Pitt, Christoph Wals", Stock = 20, Price = 310, Summary = "2.Dünya savaşından kesitler", ReleaseDate = Convert.ToDateTime("01.01.2006"), ImageUrl = "/images/soysuzlar.jpg", GenreId = 2 }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, Name = "Ali Uçar", Email = "ali@gmail.com", Password = "123", Phone = "533 345 56 67", Address = "Beşiktaş-İstanbul" },
                new Customer() { Id = 2, Name = "Oya Uçar", Email = "oya@gmail.com", Password = "123", Phone = "543 345 56 67", Address = "Kadıköy-İstanbul" },
                new Customer() { Id = 3, Name = "Neşe Sever", Email = "nese@gmail.com", Password = "123", Phone = "545 345 56 67", Address = "Bakırköy-İstanbul" },
                new Customer() { Id = 4, Name = "Hasan Kaya", Email = "hasan@gmail.com", Password = "123", Phone = "532 345 56 67", Address = "Fatih-İstanbul" }
                );
        }
        public DbSet<AspNetCoreMvc_eTicaret_MovieSales.ViewModels.CustomerViewModel> CustomerViewModel { get; set; } = default!;

    }
}
