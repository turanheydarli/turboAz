using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Turbo.Persistence.Migrations
{
    public partial class AddCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Keywords = table.Column<string>(type: "text", nullable: true),
                    CategoryOrder = table.Column<int>(type: "integer", nullable: false),
                    HomepageOrder = table.Column<int>(type: "integer", nullable: false),
                    ShowProductsOnIndex = table.Column<bool>(type: "boolean", nullable: false),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: false),
                    FeaturedOrder = table.Column<int>(type: "integer", nullable: false),
                    Visibility = table.Column<bool>(type: "boolean", nullable: false),
                    ShowImageOnNavigation = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 27, 13, 14, 9, 32, DateTimeKind.Utc).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 27, 13, 14, 9, 32, DateTimeKind.Utc).AddTicks(1395));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryOrder", "Created", "Description", "FeaturedOrder", "HomepageOrder", "IsFeatured", "Keywords", "Name", "ParentId", "ShowImageOnNavigation", "ShowProductsOnIndex", "Slug", "Title", "Updated", "Visibility" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 27, 13, 14, 9, 32, DateTimeKind.Utc).AddTicks(1271), "Test Description", 1, 1, true, "test,keyword", "Test", null, true, true, "test", "Test Category Name", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 27, 13, 14, 9, 32, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 27, 13, 14, 9, 32, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 13, 11, 6, 18, 204, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 13, 11, 6, 18, 204, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 13, 11, 6, 18, 204, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 13, 11, 6, 18, 204, DateTimeKind.Utc).AddTicks(6999));
        }
    }
}
