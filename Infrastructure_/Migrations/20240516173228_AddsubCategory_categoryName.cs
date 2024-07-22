using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure_.Migrations
{
    /// <inheritdoc />
    public partial class AddsubCategory_categoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "categoryName",
                table: "subCategories",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryName",
                table: "subCategories");
        }
    }
}
