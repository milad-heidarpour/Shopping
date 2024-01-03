using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using Shopping.Database.Classes;
using Shopping.Database.Context;
using Shopping.Database.Model;

namespace Shopping.Core.Service;

public class AccountService : IAccount
{
    private readonly DatabaseContext _context;
    string imgPath = "wwwroot/Images/UsersProfile";
    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }
    public async Task<bool> RegisterUser(RegisterViewModel register)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumb == register.PhoneNumb);
            if (user != null)
            {
                return await Task.FromResult(false);
            }

            if (register.Password == register.RePassword && register.Gender == "مرد")
            {
                User ManUser = new User()
                {
                    Id = Guid.NewGuid(),
                    RoleId = _context.Roles.SingleOrDefault(r => r.RoleEnName == "User").Id,
                    FName = null,
                    LName = null,
                    ProfileImg = "Man.png",
                    PhoneNumb = register.PhoneNumb,
                    Password = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                    RePassword = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                    Gender = register.Gender,
                    RegisterDate = await new DateAndTime().GetPersianDate(),
                };

                _context.Users.Add(ManUser);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);



                //create profile image and add to users profile folder
                //int imgCode = new Random().Next(10000, 1000000);
                //string imgName = register.PhoneNumb + profileImg.FileName;


                //if (!Directory.Exists(imgPath))
                //    Directory.CreateDirectory(imgPath);
                //string savePath = Path.Combine(imgPath, imgName);

                //using (Stream Stream = new FileStream(savePath, FileMode.Create))
                //{
                //    await profileImg.CopyToAsync(Stream);
                //}

                // add product to database(products table)
                //register.ProfileImg = imgName;

                //User newUser = new User()
                //{
                //    Id = Guid.NewGuid(),
                //    RoleId = _context.Roles.SingleOrDefault(r => r.RoleEnName == "User").Id,
                //    FName = register.FName,
                //    LName = register.LName,
                //    ProfileImg = register.ProfileImg,
                //    PhoneNumb = register.PhoneNumb,
                //    Password = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                //    RePassword = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                //    Gender = register.Gender,
                //    RegisterDate = await new DateAndTime().GetPersianDate(),
                //};
                //_context.Users.Add(newUser);
                //await _context.SaveChangesAsync();
                //return await Task.FromResult(true);
            }
            else if (register.Password == register.RePassword && register.Gender == "زن")
            {
                User WomanUser = new User()
                {
                    Id = Guid.NewGuid(),
                    RoleId = _context.Roles.SingleOrDefault(r => r.RoleEnName == "User").Id,
                    FName = null,
                    LName = null,
                    ProfileImg = "Woman.png",
                    PhoneNumb = register.PhoneNumb,
                    Password = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                    RePassword = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                    Gender = register.Gender,
                    RegisterDate = await new DateAndTime().GetPersianDate(),
                };

                _context.Users.Add(WomanUser);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<User> Login(LoginViewModel login)
    {
        try
        {
            var hashPassword = await new Security().HashPassword(await new Security().HashPassword(login.Password));
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.PhoneNumb == login.PhoneNumb && u.Password == hashPassword);
            if (user != null)
            {
                return await Task.FromResult(user);
            }
            return null;

        }
        catch (Exception)
        {
            return null;
            //throw;
        }
    }

}
