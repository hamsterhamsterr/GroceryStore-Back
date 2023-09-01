using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLocalStorageCartIdcolumnfromShoppingCartstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6700cf98-7e5a-4c58-8a5f-318cb07084d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81bf14f7-69df-4688-a6cc-9389b4112e15");

            migrationBuilder.DropColumn(
                name: "LocalStorageCartId",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0b87851-7d05-4775-829d-e54e9498ee67", null, "Admin", "ADMIN" },
                    { "c2551531-8d5a-4c62-b59c-67d5ed853500", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0b87851-7d05-4775-829d-e54e9498ee67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2551531-8d5a-4c62-b59c-67d5ed853500");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "LocalStorageCartId",
                table: "ShoppingCarts",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6700cf98-7e5a-4c58-8a5f-318cb07084d3", null, "Admin", "ADMIN" },
                    { "81bf14f7-69df-4688-a6cc-9389b4112e15", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
