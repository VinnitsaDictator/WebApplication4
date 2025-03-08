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

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        context = new ApplicationDbContext();
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

}
