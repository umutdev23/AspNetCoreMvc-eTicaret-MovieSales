using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMovieSaleRepository _movieSaleRepo;
        private readonly IMovieSaleDetailRepository _movieSaleDetailRepo;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepo, IMapper mapper, IMovieSaleRepository movieSaleRepo, IMovieSaleDetailRepository movieSaleDetailRepo)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _movieSaleRepo = movieSaleRepo;
            _movieSaleDetailRepo = movieSaleDetailRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customer = _customerRepo.GetAll().FirstOrDefault(c => c.Email == model.Email && c.Password == model.Password);
                if (customer == null)
                {
                    ModelState.AddModelError(string.Empty, "Hatalı email veya şifre girişi!");
                }
                else
                {
                    HttpContext.Session.SetJson("user", customer); //login olan kullanı bilgilerini session'a kayıt ediyoruz.
                    return RedirectToAction("ConfirmAddress");
                }
            }

            return View(model);
        }
        public IActionResult ConfirmAddress()
        {
            //Dışarıdan gelebilecek ataklara karşı öncelikle kullanıcıyı session'dan çekip kontrol ediyoruz.
            var customer = HttpContext.Session.GetJson<Customer>("user");
            if (customer == null)
            {
                return RedirectToAction("Login");
            }

            return View(_mapper.Map<CustomerViewModel>(customer));
        }
        [HttpPost]
        public IActionResult ConfirmAddress(CustomerViewModel model)
        {
            _customerRepo.Update(_mapper.Map<Customer>(model));
            HttpContext.Session.SetJson("user", model);

            return RedirectToAction("ConfirmPayment");
        }

        public IActionResult ConfirmPayment()
        {
            var customer = HttpContext.Session.GetJson<Customer>("user");
            if (customer == null)
            {
                return RedirectToAction("Login");
            }
            //sepet bilgileri session'dan çekilecek
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet");
            SepetDetay sd = new SepetDetay();
            int toplamAdet = sd.ToplamAdet(sepet);
            decimal toplamTutar = sd.ToplamTutar(sepet);

            MovieSaleViewModel movieSaleViewModel = new MovieSaleViewModel();
            movieSaleViewModel.CustomerId = customer.Id;
            movieSaleViewModel.Date = DateTime.Now;
            movieSaleViewModel.TotalQuantity = toplamAdet;
            movieSaleViewModel.TotalPrice = toplamTutar;

            CustomerFaturaViewModel customerFaturaViewModel = new CustomerFaturaViewModel()
            {
                customerViewModel = _mapper.Map<CustomerViewModel>(customer),
                satisViewModel = movieSaleViewModel,
                sepetDetayListesi = sepet
            };

            return View(customerFaturaViewModel);
        }
        [HttpPost]
        public IActionResult ConfirmPayment(CustomerFaturaViewModel model)
        {
            //MovieSale nesnesi oluşturulup veritabanına satış kaydı açılacak.
            var satisId = _movieSaleRepo.AddSale(_mapper.Map<MovieSale>(model.satisViewModel));

            //Sepet session'dan çekilecek.
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet");

            //Veritabanından dönen MoviSaleId (açılan satışın id'si) kullanılarak sepet bilgileri MovieSaleDetails tablosuna kayıt edilecek (AddRange()); 
            if(_movieSaleDetailRepo.AddRange(sepet, satisId))
            {
                TempData["mesaj"] = "Satış işlemi başarıyla tamamlandı.";
                HttpContext.Session.Remove("sepet"); //Sepet bilgileri session'dan silinir. Ancak müşteri isterse yeniden alışverişe devam edebilir.

                //Satılan ürünlerin (movieSaleDetail.MovieId) stok miktarları satış adetleri kadar eksiltilmeli.
            }
            else
            {
                TempData["mesaj"] = "Satış işlemi gerçekleşmedi, bilgilerinizi kontrol edin!";
            }

            return View("MessageShow"); 
        }

        public IActionResult Create()       //Customer Register
        {
            return View();
        }
    }
}
