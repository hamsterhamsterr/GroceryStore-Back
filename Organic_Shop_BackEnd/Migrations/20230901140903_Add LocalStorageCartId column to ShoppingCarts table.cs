using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalStorageCartIdcolumntoShoppingCartstable : Migration
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
                keyValue: "03f26e96-7f2b-46c1-8377-1d40ec71ad4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8985d6d4-9db1-4472-a221-77308523acf5");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "03f26e96-7f2b-46c1-8377-1d40ec71ad4c", null, "User", "USER" },
                    { "8985d6d4-9db1-4472-a221-77308523acf5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
