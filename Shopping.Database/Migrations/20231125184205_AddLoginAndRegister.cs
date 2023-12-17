using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class AddLoginAndRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("abc8ed9c-fd30-4018-be36-b5f6ba46727f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97a26a61-dee4-4955-82cc-c871f8beb586"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("180d6dc9-1575-4a7e-9416-c4245cd5d63d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("d07b4b32-4c40-4ac3-8a39-f447bb729343"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("d0b3475b-0eae-40ae-bf21-eca5748e8d4f"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "ProfileImg", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("7553ca10-7eea-4a0a-be86-ae258ce7982c"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "Admin.jpg", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/09/04 22:12:05", new Guid("d0b3475b-0eae-40ae-bf21-eca5748e8d4f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d07b4b32-4c40-4ac3-8a39-f447bb729343"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7553ca10-7eea-4a0a-be86-ae258ce7982c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d0b3475b-0eae-40ae-bf21-eca5748e8d4f"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("180d6dc9-1575-4a7e-9416-c4245cd5d63d"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("abc8ed9c-fd30-4018-be36-b5f6ba46727f"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "ProfileImg", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("97a26a61-dee4-4955-82cc-c871f8beb586"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "wwwroot/images/usersprofile/Admin.jpg", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/09/04 21:04:51", new Guid("180d6dc9-1575-4a7e-9416-c4245cd5d63d") });
        }
    }
}
