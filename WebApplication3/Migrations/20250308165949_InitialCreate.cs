using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorFilm",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorFilm", x => new { x.ActorsId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_ActorFilm_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorFilm_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Hall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo DiCaprio" },
                    { 2, null, new DateTime(1981, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joseph Gordon-Levitt" },
                    { 3, null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" },
                    { 4, null, new DateTime(1967, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carrie-Anne Moss" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "Genre", "PosterUrl", "Title", "TrailerUrl", "Year" },
                values: new object[,]
                {
                    { 1, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", 148, "Sci-Fi", "https://example.com/inception-poster.jpg", "Inception", "https://www.youtube.com/watch?v=YoHD9XEInc0", 2010 },
                    { 2, "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", 136, "Sci-Fi", "https://example.com/matrix-poster.jpg", "The Matrix", "https://www.youtube.com/watch?v=vKQi3bBA1y8", 1999 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "johndoe", "John Doe", "password123" },
                    { 2, "janesmith", "Jane Smith", "password123" }
                });

            migrationBuilder.InsertData(
                table: "ActorFilm",
                columns: new[] { "ActorsId", "FilmsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "FilmId", "Hall", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, "Main Hall", 12.99m },
                    { 2, new DateTime(2023, 10, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 2, "Main Hall", 12.99m }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "SessionId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Booked", 1 },
                    { 2, 2, "Booked", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorFilm_FilmsId",
                table: "ActorFilm",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SessionId",
                table: "Tickets",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorFilm");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
