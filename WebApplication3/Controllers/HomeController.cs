using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Linq;
using System;
using WebApplication3.DBcontext;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DBcontext.WebCinema.Data;

namespace WebApplication3.Controllers;

public class HomeController : Controller
{
   private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        this.context = context;
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Index()
    {
       
        return View(context.Films.ToList());
    }
    // GET: HomeController/CreateFilm
    [HttpGet]
    public IActionResult CreateFilm()
    {
        return View();
    }

    // POST: HomeController/CreateFilm
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateFilm(Film film)
    {
        if (!ModelState.IsValid)
            return View(film);

        context.Films.Add(film);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
