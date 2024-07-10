using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreRepository _genreRepo;
        private readonly IMapper _mapper;
        public GenresViewComponent(IGenreRepository genreRepo, IMapper mapper)
        {
            _genreRepo = genreRepo;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.SelectedGenreId = RouteData?.Values["id"];
            var genres = _genreRepo.GetAll();
            return View(_mapper.Map<List<GenreViewModel>>(genres));
        }
    }
}
