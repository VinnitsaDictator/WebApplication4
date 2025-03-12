using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DBcontext.WebCinema.Data;
using WebApplication3.Models;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActorController
        public IActionResult Index()
        {
            return View(_context.Actors.ToList());
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Actors.Remove(actor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actor actor)
        {
            if (!ModelState.IsValid)
                return View(actor);

            _context.Actors.Add(actor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }




    }
}
