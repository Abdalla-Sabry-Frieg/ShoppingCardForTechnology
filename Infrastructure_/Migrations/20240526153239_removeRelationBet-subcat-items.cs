using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure_.Migrations
{
    /// <inheritdoc />
    public partial class removeRelationBetsubcatitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_subCategories_subCategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_subCategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "subCategoryId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subCategoryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_subCategoryId",
                table: "Items",
                column: "subCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_subCategories_subCategoryId",
                table: "Items",
                column: "subCategoryId",
                principalTable: "subCategories",
                principalColumn: "Id");
        }
    }
}
