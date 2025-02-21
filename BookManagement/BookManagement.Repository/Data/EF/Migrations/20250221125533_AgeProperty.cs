using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagement.Repository.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class AgeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Books",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(YEAR, PublicationYear, GETDATE())",
                stored: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Books");
        }
    }
}
