using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class AddCommodityAlbumModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CommodityAlbum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityImg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommodityAlbum_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("146be7d2-5e69-4f61-b46e-ef31cf46d98c"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("f5925ee5-2823-4584-9d92-ee316cb2e3e0"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("ac1c14f7-0ede-4222-a60e-a3e20099eb93"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/29 20:40:00", new Guid("146be7d2-5e69-4f61-b46e-ef31cf46d98c") });

            migrationBuilder.CreateIndex(
                name: "IX_CommodityAlbum_CommodityId",
                table: "CommodityAlbum",
                column: "CommodityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommodityAlbum");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f5925ee5-2823-4584-9d92-ee316cb2e3e0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ac1c14f7-0ede-4222-a60e-a3e20099eb93"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("146be7d2-5e69-4f61-b46e-ef31cf46d98c"));

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
        }
    }
}
