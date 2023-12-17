using Microsoft.AspNetCore.Mvc;
using Shopping.Classes;
using Shopping.Core.Interface;
using Shopping.Database.Model;

namespace Shopping.Areas.Admin.Controllers;
[Area("Admin")]
[Role("Admin")]
public class AdminController : Controller
{
    IUser _user;
    public AdminController(IUser user)
    {
        _user = user;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
}
