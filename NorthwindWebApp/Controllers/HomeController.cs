using Microsoft.AspNetCore.Mvc;
using NorthwindWebApp.Models;

namespace NorthwindWebApp.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new HomeViewModel();
        return View(model);
    }
}
