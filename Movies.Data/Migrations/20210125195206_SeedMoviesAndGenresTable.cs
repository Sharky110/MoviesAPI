using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Data.Migrations
{
    public partial class SeedMoviesAndGenresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Detective')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Triller')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Drama')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Horror')");

            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('In The End', (SELECT Id FROM Genres WHERE Name = 'Detective'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Numb', (SELECT Id FROM Genres WHERE Name = 'Detective'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Breaking The Habit', (SELECT Id FROM Genres WHERE Name = 'Detective'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Fear of the dark', (SELECT Id FROM Genres WHERE Name = 'Triller'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Number of the beast', (SELECT Id FROM Genres WHERE Name = 'Triller'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('The Trooper', (SELECT Id FROM Genres WHERE Name = 'Triller'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('What''s left of the flag', (SELECT Id FROM Genres WHERE Name = 'Drama'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Drunken Lullabies', (SELECT Id FROM Genres WHERE Name = 'Drama'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('If I Ever Leave this World Alive', (SELECT Id FROM Genres WHERE Name = 'Drama'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Californication', (SELECT Id FROM Genres WHERE Name = 'Horror'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Tell Me Baby', (SELECT Id FROM Genres WHERE Name = 'Horror'))");
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, GenreId) Values ('Parallel Universe', (SELECT Id FROM Genres WHERE Name = 'Horror'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Movies");

            migrationBuilder
                .Sql("DELETE FROM Genres");
        }
    }
}
