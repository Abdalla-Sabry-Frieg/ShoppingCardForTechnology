using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure_.Migrations
{
    /// <inheritdoc />
    public partial class removeRelationBetitemtypeitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_itemTypes_ItemTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_Items_ItemId",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_ItemId",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "orderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ItemType",
                table: "orderItems",
                column: "ItemType");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_Items_ItemType",
                table: "orderItems",
                column: "ItemType",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_Items_ItemType",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_ItemType",
                table: "orderItems");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "orderItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ItemId",
                table: "orderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_itemTypes_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "itemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_Items_ItemId",
                table: "orderItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
