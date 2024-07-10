namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class MovieSaleDetail    //Film Satış Detayları
    {
        public int Id { get; set; }
        public int MovieSaleId { get; set; }
        public int MovieId { get; set; }
        public int Number { get; set; }
        public decimal UnitPrice { get; set; }

        //Navigation Property (Relations)
        public MovieSale MovieSale { get; set; }
        public Movie Movie { get; set; }



        //(Satış Id = 1275)                         -> MovieSale (FilmSatis)
        // 10.06.2024 11.40          Ali Uçar (1)   -> MovieSale (FilmSatis)

        //      Film        Adet    Fiyat   Tutar     (Sepet Detayları)
        //    Gladyatör       2     320      640    -> MovieSaleDetail
        //    Nothing Hill    3     310      930    -> MovieSaleDetail
        //    Truva           1     350      350    -> MovieSaleDetail


        //        Toplam      6              1920   ->  MovieSale (FilmSatis)

    }
}
