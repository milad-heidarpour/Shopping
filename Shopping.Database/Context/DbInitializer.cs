using Microsoft.EntityFrameworkCore;
using Shopping.Database.Model;
using Shopping.Database.Classes;

namespace Shopping.Database.Context;

internal class DbInitializer
{
    private ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    internal async void Seed()
    {
        Role adminRole = new Role()
        {
            Id = Guid.NewGuid(),
            RoleEnName = "Admin",
            RoleFaName = "مدیر",
        };
        _modelBuilder.Entity<Role>().HasData(adminRole);

        Role userRole = new Role()
        {
            Id = Guid.NewGuid(),
            RoleEnName = "User",
            RoleFaName = "کاربر",
        };
        _modelBuilder.Entity<Role>().HasData(userRole);

        User SiteAdmin = new User()
        {
            Id = Guid.NewGuid(),
            RoleId = adminRole.Id,
            FName = "میلاد",
            LName = "حیدرپور",
            PhoneNumb = "09030826556",
            ProfileImg= "Admin.jpg",
            Password = await new Security().HashPassword(await new Security().HashPassword("27736124")),
            RePassword= await new Security().HashPassword(await new Security().HashPassword("27736124")),
            Gender = "مرد",
            RegisterDate = await new DateAndTime().GetPersianDate(),
        };
        _modelBuilder.Entity<User>().HasData(SiteAdmin);
    }
}