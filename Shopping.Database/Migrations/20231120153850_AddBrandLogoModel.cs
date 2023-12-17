using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class AddBrandLogoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ProductImg",
                table: "Commodities");

            migrationBuilder.DropColumn(
                name: "BrandImg",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "GroupImg",
                table: "ProductClassifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BrandLogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandLogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandLogos_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("8cdcf8e1-7300-42fb-b27b-0c981454da97"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("fe3b1c0f-e7af-4b7a-ae4d-3f50e8b9bd12"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("bd9495f2-e361-40b9-b810-7234e1754152"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/29 19:08:49", new Guid("fe3b1c0f-e7af-4b7a-ae4d-3f50e8b9bd12") });

            migrationBuilder.CreateIndex(
                name: "IX_BrandLogos_BrandId",
                table: "BrandLogos",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandLogos");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8cdcf8e1-7300-42fb-b27b-0c981454da97"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd9495f2-e361-40b9-b810-7234e1754152"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fe3b1c0f-e7af-4b7a-ae4d-3f50e8b9bd12"));

            migrationBuilder.DropColumn(
                name: "GroupImg",
                table: "ProductClassifications");

            migrationBuilder.AddColumn<string>(
                name: "ProductImg",
                table: "Commodities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandImg",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
