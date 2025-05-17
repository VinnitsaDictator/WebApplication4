using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DBcontext.WebCinema.Data;
using WebApplication3.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var sessions = await _context.Sessions.Include(s => s.Film).ToListAsync();
            return View(sessions);
        }

        // GET: Sessions/Create
       
        [HttpGet]
        public IActionResult CreateSession()
        {
            ViewBag.Films = new SelectList(_context.Films, "Id", "Title");
            return View();
        }



        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSession(Session session)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Films = new SelectList(_context.Films, "Id", "Title");
                return View(session);
            }

            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // POST: Sessions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // GET: Sessions/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return NotFound();

            ViewBag.Films = new SelectList(_context.Films, "Id", "Title", session.FilmId);
            return View(session);
        }

        // POST: Sessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmId,StartTime,EndTime,Hall")] Session session)
        {
            if (id != session.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Films = new SelectList(_context.Films, "Id", "Title", session.FilmId);
                return View(session);
            }

            _context.Update(session);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}



