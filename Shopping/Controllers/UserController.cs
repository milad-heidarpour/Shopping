using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Core.Interface;

namespace Shopping.Controllers;

[Authorize]
public class UserController : Controller
{
    IUser _user;
    public UserController(IUser user)
    {
        _user = user;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _user.GetUser(User.Identity.Name);
        if (user != null) 
        {
            if (user.Role.RoleEnName=="Admin")
            {
                return Redirect("~/admin/admin");
            }
            return await Task.FromResult(View(user));
        }
        return await Task.FromResult(View());
    }
}
