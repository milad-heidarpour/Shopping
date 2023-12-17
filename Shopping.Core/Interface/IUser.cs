using Shopping.Database.Model;

namespace Shopping.Core.Interface;

public interface IUser:IDisposable
{
    Task<User> GetUser(string userMobile);
}
