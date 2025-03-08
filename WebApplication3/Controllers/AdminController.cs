using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.DBcontext.WebCinema.Data;

namespace WebApplication3.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ApplicationDbContext context, ILogger<AdminController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Îòîáðàæåíèå ñïèñêà ôèëüìîâ
    [HttpGet("films")]
    public IActionResult Films()
    {
        var films = _context.Films.ToList();
        return View(films);
    }

    // Äîáàâëåíèå íîâîãî ôèëüìà
    [HttpGet("films/add")]
    public IActionResult AddFilm() => View();

    [HttpPost("films/add")]
    public IActionResult AddFilm(Film film)
    {
        if (ModelState.IsValid)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
            return RedirectToAction("Films");
        }
        return View(film);
    }

    // Óïðàâëåíèå àêòåðàìè
    [HttpGet("actors")]
    public IActionResult Actors()
    {
        var actors = _context.Actors.ToList();
        return View(actors);
    }

    // Óïðàâëåíèå ñåàíñàìè
    [HttpGet("sessions")]
    public IActionResult Sessions()
    {
        var sessions = _context.Sessions.ToList();
        return View(sessions);
    }

   
}
