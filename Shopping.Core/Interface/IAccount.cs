
using Microsoft.AspNetCore.Http;
using Shopping.Core.ViewModels;
using Shopping.Database.Model;

namespace Shopping.Core.Interface;

public interface IAccount:IDisposable
{
    Task<bool> RegisterUser(RegisterViewModel register);
    Task<User> Login(LoginViewModel login);
}
