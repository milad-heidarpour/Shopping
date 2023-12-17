using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class UserRegisterFLNameNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3fc8bc3c-146c-4b1c-a7b5-f490ef7db97c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc02544c-7b35-4256-8c75-fbccf20118ac"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("17a74ae2-887d-4b54-ae47-a759cb3b31a6"));

            migrationBuilder.AlterColumn<string>(
                name: "LName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("76361a31-0015-4008-bca6-aa7a21af054d"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("82c4ade6-1c37-47b3-8bcd-47ba295aebb6"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "ProfileImg", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("3add057d-a202-4efc-a232-f35c8da9f9ec"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "Admin.jpg", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/09/12 12:08:44", new Guid("82c4ade6-1c37-47b3-8bcd-47ba295aebb6") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("76361a31-0015-4008-bca6-aa7a21af054d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3add057d-a202-4efc-a232-f35c8da9f9ec"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("82c4ade6-1c37-47b3-8bcd-47ba295aebb6"));

            migrationBuilder.AlterColumn<string>(
                name: "LName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("17a74ae2-887d-4b54-ae47-a759cb3b31a6"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("3fc8bc3c-146c-4b1c-a7b5-f490ef7db97c"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "ProfileImg", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("bc02544c-7b35-4256-8c75-fbccf20118ac"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "Admin.jpg", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/09/07 18:49:04", new Guid("17a74ae2-887d-4b54-ae47-a759cb3b31a6") });
        }
    }
}
