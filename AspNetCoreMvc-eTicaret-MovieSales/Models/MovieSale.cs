namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class MovieSale      //FilmSatis
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        //Navigation Property (Relations)
        public List<MovieSaleDetail> MovieSaleDetails { get; set; }
        public Customer Customer { get; set; }

    }
}
//MovieSales
//121 12.05.2024  4   12  860 

//MovieSaleDetails
//Id MovieSaleId  MovieId
//1     121         5       2   310
//2     121         3       1   340
//3     121         1       4   300
//4     122         5       2   310
//5     123         1       2   310
//6     123         8       3   310





