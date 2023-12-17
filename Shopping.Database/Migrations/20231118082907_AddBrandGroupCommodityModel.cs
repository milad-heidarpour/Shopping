using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class AddBrandGroupCommodityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("56b35188-7751-47e1-856f-2bca8299d5c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("075fce83-52e7-4340-990d-e6f9bb27b154"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d914a789-6332-487b-a9ae-361e7f9945ee"));

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandEnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandFaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandDes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupEnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupFaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commodities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductFaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductEnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotShow = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commodities_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commodities_ProductClassifications_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ProductClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("6e3f2c83-4030-4b26-b6a1-6cf2463d7423"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("a242b082-f6f8-4689-8eb8-a9c356a84b8b"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("6e308a07-0937-4d59-bfad-4ec069975b1c"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/27 11:59:06", new Guid("6e3f2c83-4030-4b26-b6a1-6cf2463d7423") });

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_BrandId",
                table: "Commodities",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_GroupId",
                table: "Commodities",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commodities");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductClassifications");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a242b082-f6f8-4689-8eb8-a9c356a84b8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6e308a07-0937-4d59-bfad-4ec069975b1c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6e3f2c83-4030-4b26-b6a1-6cf2463d7423"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("56b35188-7751-47e1-856f-2bca8299d5c0"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("d914a789-6332-487b-a9ae-361e7f9945ee"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("075fce83-52e7-4340-990d-e6f9bb27b154"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/27 10:52:55", new Guid("d914a789-6332-487b-a9ae-361e7f9945ee") });
        }
    }
}
