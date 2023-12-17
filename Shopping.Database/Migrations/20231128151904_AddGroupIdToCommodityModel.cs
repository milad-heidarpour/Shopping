using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class AddGroupIdToCommodityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("86c012f4-3674-4bb8-a1d9-4e69636e3992"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("74c7e038-7df4-428b-8474-578469d96e82"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fe22ad78-3ac7-4bc3-8602-09765ec2fb48"));

            migrationBuilder.DropColumn(
                name: "ProductClassificationId",
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
                values: new object[] { new Guid("17a74ae2-887d-4b54-ae47-a759cb3b31a6"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("3fc8bc3c-146c-4b1c-a7b5-f490ef7db97c"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "ProfileImg", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("bc02544c-7b35-4256-8c75-fbccf20118ac"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "Admin.jpg", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/09/07 18:49:04", new Guid("17a74ae2-887d-4b54-ae47-a759cb3b31a6") });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("3fc8bc3c-146c-4b1c-a7b5-f490ef7db97c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc02544c-7b35-4256-8c75-fbccf20118ac"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("17a74ae2-887d-4b54-ae47-a759cb3b31a6"));

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Commodities");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductClassificationId",
                table: "Commodities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("86c012f4-3674-4bb8-a1d9-4e69636e3992"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("fe22ad78-3ac7-4bc3-8602-09765ec2fb48"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "ProfileImg", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("74c7e038-7df4-428b-8474-578469d96e82"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "Admin.jpg", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/09/07 12:10:43", new Guid("fe22ad78-3ac7-4bc3-8602-09765ec2fb48") });

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
    }
}
