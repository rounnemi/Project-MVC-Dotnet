using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Models;
namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationdbContext _db;
        public MovieController(ApplicationdbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var movies = _db.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }
        public ActionResult Create()
        {
            var members = _db.Genre.ToList();
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
                if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                {
                    // Enregistrez le fichier image sur le serveur
                    var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        movie.ImageFile.CopyTo(stream);
                    }

                    // Enregistrez le chemin de l'image dans la base de données
                    movie.ImagePath = $"/images/{movie.ImageFile.FileName}";
                }

                _db.Movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Gestion des erreurs de validation
            return View("Create", movie);
        }


    }
}
