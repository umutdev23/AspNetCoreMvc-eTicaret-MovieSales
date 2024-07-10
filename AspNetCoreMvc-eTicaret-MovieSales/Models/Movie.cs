using Microsoft.AspNetCore.Components.Web;

namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class Movie      //Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Summary { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsLocal { get; set; }   //Yerli-Yabancı
        public bool IsPopuler { get; set; }   //Popüler
        public bool IsDiscount { get; set; }    //İndirimde olanlar
        public int GenreId { get; set; }

        //Navigation Property (Relations)
        public Genre Genre { get; set; }
        public List<MovieSaleDetail> MovieSaleDetails { get; set; }
    }
}
