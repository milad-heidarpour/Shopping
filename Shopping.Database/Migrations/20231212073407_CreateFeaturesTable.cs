using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Database.Migrations
{
    public partial class CreateFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FeatureGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureGroupId = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureSections_FeatureGroups_FeatureGroupId",
                        column: x => x.FeatureGroupId,
                        principalTable: "FeatureGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureSectionId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_FeatureSections_FeatureSectionId",
                        column: x => x.FeatureSectionId,
                        principalTable: "FeatureSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("a6004e07-8fc6-4f6f-9bf6-fe420a145837"), "Admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnName", "RoleFaName" },
                values: new object[] { new Guid("f9518484-6379-4abd-87b9-87993f17b9d4"), "User", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "Gender", "LName", "Password", "PhoneNumb", "ProfileImg", "RePassword", "RegisterDate", "RoleId" },
                values: new object[] { new Guid("5c45a8c3-db9a-4f9d-aeec-5926c984710c"), "میلاد", "مرد", "حیدرپور", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "09030826556", "Admin.jpg", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", "1402/09/21 11:04:07", new Guid("a6004e07-8fc6-4f6f-9bf6-fe420a145837") });

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureSectionId",
                table: "Features",
                column: "FeatureSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureSections_FeatureGroupId",
                table: "FeatureSections",
                column: "FeatureGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "FeatureSections");

            migrationBuilder.DropTable(
                name: "FeatureGroups");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f9518484-6379-4abd-87b9-87993f17b9d4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c45a8c3-db9a-4f9d-aeec-5926c984710c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a6004e07-8fc6-4f6f-9bf6-fe420a145837"));

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
    }
}
