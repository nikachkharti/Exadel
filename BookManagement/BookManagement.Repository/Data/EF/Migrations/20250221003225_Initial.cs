using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManagement.Repository.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicationYear = table.Column<DateTime>(type: "DATE", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "PublicationYear", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("522f3f16-5ae3-42ea-9c19-90995b097805"), "Miguel de Cervantes", new DateTime(1605, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don Quixote", 9 },
                    { new Guid("b6a80edc-d005-47c6-8241-619109da1504"), "Fiodor Dostoevsky", new DateTime(1880, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Brothers Karamazov", 11 },
                    { new Guid("ef924032-43a1-4531-ad96-5ee190790af8"), "Alexander Dumas", new DateTime(1844, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Musketers", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
