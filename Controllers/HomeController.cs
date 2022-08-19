using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FistProjectCore.Models;

namespace FistProjectCore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration )
    {
        _logger = logger;
        this.configuration = configuration;
    }

    public IActionResult Index()
    {
        if (configuration["IsWebsiteAccesible"].Equals("true"))
        return View();
        return Ok("this website is closed");
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
}
