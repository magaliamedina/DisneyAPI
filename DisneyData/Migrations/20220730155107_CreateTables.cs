using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyData.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<long>(type: "bigint", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Characters_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Image", "Name" },
                values: new object[] { 1, null, "Romantic" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Image", "Name" },
                values: new object[] { 2, null, "Infantil" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Image", "Name" },
                values: new object[] { 3, null, "Terror" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "CreationDate", "GenreID", "Image", "Score", "Title" },
                values: new object[] { 1, new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 5, "The Notebook" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "CreationDate", "GenreID", "Image", "Score", "Title" },
                values: new object[] { 2, new DateTime(2008, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 5, "Shrek" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "CreationDate", "GenreID", "Image", "Score", "Title" },
                values: new object[] { 3, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 2, "It" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "ID", "Age", "History", "Image", "MovieID", "Name", "Weight" },
                values: new object[] { 1, 30, "Two young in love.", null, 1, "Rachel McAdams", 60L });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MovieID",
                table: "Characters",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID",
                table: "Movies",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
