using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class AddImageToUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cd7bea44-982b-42c2-9c24-ff10cfedc5f1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d0c5673a-c989-4cb9-96d7-626ac309bf8f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bcdd884c-1903-4d7f-9e5c-ab2048114724"));

            migrationBuilder.AddColumn<string>(
                name: "ProfileImg",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductEnName",
                table: "Commodities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProfileImg",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ProductEnName",
                table: "Commodities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("bcdd884c-1903-4d7f-9e5c-ab2048114724"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("cd7bea44-982b-42c2-9c24-ff10cfedc5f1"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("d0c5673a-c989-4cb9-96d7-626ac309bf8f"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/30 11:20:26", new Guid("bcdd884c-1903-4d7f-9e5c-ab2048114724") });
        }
    }
}
