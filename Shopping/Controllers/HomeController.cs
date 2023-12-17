using Microsoft.AspNetCore.Mvc;

namespace Shopping.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
