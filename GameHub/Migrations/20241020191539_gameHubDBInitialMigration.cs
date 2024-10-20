using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class gameHubDBInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    ReleaseDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "Description", "Genre", "Price", "ReleaseDate", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 1, "Open world action role-playing video game.", "Role-playing", 39.990000000000002, new DateTimeOffset(new DateTime(2011, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), 120, "The Elder Scrolls V: Skyrim" },
                    { 2, "Action role-playing game set in a lush, open world.", "Action", 49.990000000000002, new DateTimeOffset(new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), 150, "The Witcher 3: Wild Hunt" },
                    { 3, "Open-world, action-adventure story set in Night City.", "Action", 59.990000000000002, new DateTimeOffset(new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), 80, "Cyberpunk 2077" },
                    { 4, "Sandbox game that allows players to build with a variety of different blocks in a 3D procedurally generated world.", "Sandbox", 26.949999999999999, new DateTimeOffset(new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), 0, "Minecraft" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
