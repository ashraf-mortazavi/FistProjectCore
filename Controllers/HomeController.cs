using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using FistProjectCore.Models;

namespace FistProjectCore.Controllers;
=======
using PhoneBook.Models;

namespace PhoneBook.Controllers;
>>>>>>> 3a19483 (NewChange In PhoneBook Project .net core)

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
<<<<<<< HEAD
        if (configuration["IsWebsiteAccesible"].Equals("true"))
        return View();
        return Ok("this website is closed");
=======
       
        return View();
   
>>>>>>> 3a19483 (NewChange In PhoneBook Project .net core)
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
