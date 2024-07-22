using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure_.Migrations
{
    /// <inheritdoc />
    public partial class removeTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorytitle",
                table: "subCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categorytitle",
                table: "subCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
