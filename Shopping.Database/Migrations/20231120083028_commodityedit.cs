using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class commodityedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_ProductClassifications_GroupId",
                table: "Commodities");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_GroupId",
                table: "Commodities");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9fc6ce31-da00-464c-af42-061c15e7b258"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5988bd6-de70-43f3-992b-11664c0c6ceb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c1149e7b-3d0c-4910-a53b-d347721dccaa"));

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Commodities");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductClassificationId",
                table: "Commodities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImg",
                table: "Commodities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("3032770f-c509-4db6-b53b-666b939e1cf9"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("35d130f2-7cd7-406a-8801-ba1477aa8dae"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("db604566-0037-4ceb-be8e-e0df63754dd4"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/29 12:00:28", new Guid("3032770f-c509-4db6-b53b-666b939e1cf9") });

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_ProductClassificationId",
                table: "Commodities",
                column: "ProductClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_ProductClassifications_ProductClassificationId",
                table: "Commodities",
                column: "ProductClassificationId",
                principalTable: "ProductClassifications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_ProductClassifications_ProductClassificationId",
                table: "Commodities");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_ProductClassificationId",
                table: "Commodities");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("35d130f2-7cd7-406a-8801-ba1477aa8dae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("db604566-0037-4ceb-be8e-e0df63754dd4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3032770f-c509-4db6-b53b-666b939e1cf9"));

            migrationBuilder.DropColumn(
                name: "ProductClassificationId",
                table: "Commodities");

            migrationBuilder.DropColumn(
                name: "ProductImg",
                table: "Commodities");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Commodities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("9fc6ce31-da00-464c-af42-061c15e7b258"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("c1149e7b-3d0c-4910-a53b-d347721dccaa"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("c5988bd6-de70-43f3-992b-11664c0c6ceb"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/29 11:34:19", new Guid("c1149e7b-3d0c-4910-a53b-d347721dccaa") });

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_GroupId",
                table: "Commodities",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_ProductClassifications_GroupId",
                table: "Commodities",
                column: "GroupId",
                principalTable: "ProductClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
