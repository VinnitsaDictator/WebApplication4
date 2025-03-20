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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
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
        // GET: ActorController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var actor = await _context.Actors.FindAsync(id);
            if (actor == null) return NotFound();

            return View(actor);
        }

        // POST: ActorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Biography,BirthDate")] Actor actor)
        {
            if (id != actor.Id) return NotFound();

            if (!ModelState.IsValid) return View(actor);

            _context.Update(actor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
