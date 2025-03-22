using Microsoft.AspNetCore.Mvc;
using WebApplication3.DBcontext.WebCinema.Data;
using WebApplication3.Models;
using WebApplication3.Extensions;
using System.Collections.Generic;

namespace WebApplication3.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var favoriteFilms = HttpContext.Session.GetObjectFromJson<List<Film>>("FavoriteFilms") ?? new List<Film>();
            return View(favoriteFilms);
        }

        public IActionResult AddToFavorites(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            var favoriteFilms = HttpContext.Session.GetObjectFromJson<List<Film>>("FavoriteFilms") ?? new List<Film>();
            favoriteFilms.Add(film);
            HttpContext.Session.SetObjectAsJson("FavoriteFilms", favoriteFilms);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult RemoveFromFavorites(int id)
        {
            var favoriteFilms = HttpContext.Session.GetObjectFromJson<List<Film>>("FavoriteFilms") ?? new List<Film>();
            var film = favoriteFilms.Find(f => f.Id == id);
            if (film != null)
            {
                favoriteFilms.Remove(film);
                HttpContext.Session.SetObjectAsJson("FavoriteFilms", favoriteFilms);
            }

            return RedirectToAction("Index");
        }

    }
}
