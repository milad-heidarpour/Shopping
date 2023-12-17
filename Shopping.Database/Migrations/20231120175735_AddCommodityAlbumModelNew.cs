using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class AddCommodityAlbumModelNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommodityAlbum_Commodities_CommodityId",
                table: "CommodityAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommodityAlbum",
                table: "CommodityAlbum");

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

            migrationBuilder.RenameTable(
                name: "CommodityAlbum",
                newName: "CommoditiesAlbum");

            migrationBuilder.RenameIndex(
                name: "IX_CommodityAlbum_CommodityId",
                table: "CommoditiesAlbum",
                newName: "IX_CommoditiesAlbum_CommodityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommoditiesAlbum",
                table: "CommoditiesAlbum",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("01256efd-22ff-4824-bd5d-cd74f787e4ac"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("6a2af55a-564b-40a5-b2e4-fffbd4598523"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("0a8152f1-25f0-42ea-8b80-a3b00ad59c6e"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/08/29 21:27:35", new Guid("01256efd-22ff-4824-bd5d-cd74f787e4ac") });

            migrationBuilder.AddForeignKey(
                name: "FK_CommoditiesAlbum_Commodities_CommodityId",
                table: "CommoditiesAlbum",
                column: "CommodityId",
                principalTable: "Commodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommoditiesAlbum_Commodities_CommodityId",
                table: "CommoditiesAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommoditiesAlbum",
                table: "CommoditiesAlbum");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6a2af55a-564b-40a5-b2e4-fffbd4598523"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a8152f1-25f0-42ea-8b80-a3b00ad59c6e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01256efd-22ff-4824-bd5d-cd74f787e4ac"));

            migrationBuilder.RenameTable(
                name: "CommoditiesAlbum",
                newName: "CommodityAlbum");

            migrationBuilder.RenameIndex(
                name: "IX_CommoditiesAlbum_CommodityId",
                table: "CommodityAlbum",
                newName: "IX_CommodityAlbum_CommodityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommodityAlbum",
                table: "CommodityAlbum",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CommodityAlbum_Commodities_CommodityId",
                table: "CommodityAlbum",
                column: "CommodityId",
                principalTable: "Commodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
