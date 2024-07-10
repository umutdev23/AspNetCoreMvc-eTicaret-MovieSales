namespace AspNetCoreMvc_eTicaret_MovieSales.ViewModels
{
    public class MovieViewModel
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
    }
}
