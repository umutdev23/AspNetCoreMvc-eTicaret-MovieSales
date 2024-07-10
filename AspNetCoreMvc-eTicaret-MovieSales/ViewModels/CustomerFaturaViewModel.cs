using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.ViewModels
{
    public class CustomerFaturaViewModel
    {
        public CustomerViewModel customerViewModel { get; set; }
        public MovieSaleViewModel satisViewModel { get; set; }
        public List<SepetDetay> sepetDetayListesi { get; set; }
    }
}
