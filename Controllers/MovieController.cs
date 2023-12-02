using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Models;
using TP3.Services;

namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _IMovieService;
     private readonly IGenreRepository _GenreRepository;
        public MovieController(IMovieService IMovieService, IGenreRepository GenreRepository
            )
        {
            _IMovieService= IMovieService;
            _GenreRepository= GenreRepository;
        }

        public ActionResult Index()
        {
            var movies = _IMovieService.GetMovieOrdreCroissant();

            return View(movies);
        }
        public ActionResult Create()
        {
            var members = _GenreRepository.Genres();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.GenreName.ToString(),
                Value = members.Id.ToString()
            });
            return View();
        }


        public ActionResult CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _IMovieService.Add(movie);
                return RedirectToAction("Index");
            }

            // Gestion des erreurs de validation
            return View("Create", movie);
        }


    }
}
