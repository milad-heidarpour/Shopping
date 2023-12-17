using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shopping.Database.Context;

namespace Shopping.Classes;

public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _roleName;
    public RoleAttribute(string roleName)
    {
        _roleName = roleName;
    }
    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        var identity= context.HttpContext.User.Identity;
        if (identity.IsAuthenticated)
        {
            var userMobile = identity.Name;

            DatabaseContext _context = new DatabaseContext();
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumb == userMobile && u.Role.RoleEnName == _roleName);

            if (user == null)
            {
                context.Result = new RedirectResult("~/account/login");
            }
        }
        else
        {
            context.Result = new RedirectResult("~/account/login ");
        }
    }
}
