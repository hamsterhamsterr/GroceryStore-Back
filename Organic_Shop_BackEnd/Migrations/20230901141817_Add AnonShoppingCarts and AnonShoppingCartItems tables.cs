using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddAnonShoppingCartsandAnonShoppingCartItemstables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0b87851-7d05-4775-829d-e54e9498ee67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2551531-8d5a-4c62-b59c-67d5ed853500");

            migrationBuilder.CreateTable(
                name: "AnonShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<long>(type: "bigint", nullable: false),
                    LocalCartId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnonShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    AnonShoppingCartId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnonShoppingCartItems_AnonShoppingCarts_AnonShoppingCartId",
                        column: x => x.AnonShoppingCartId,
                        principalTable: "AnonShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnonShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "825c9425-19fc-4b0c-b78f-8f7831ae6ac3", null, "User", "USER" },
                    { "cf36b3a2-672e-461e-9913-0dc44e59bba2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnonShoppingCartItems_AnonShoppingCartId",
                table: "AnonShoppingCartItems",
                column: "AnonShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_AnonShoppingCartItems_ProductId",
                table: "AnonShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnonShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AnonShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825c9425-19fc-4b0c-b78f-8f7831ae6ac3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf36b3a2-672e-461e-9913-0dc44e59bba2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0b87851-7d05-4775-829d-e54e9498ee67", null, "Admin", "ADMIN" },
                    { "c2551531-8d5a-4c62-b59c-67d5ed853500", null, "User", "USER" }
                });
        }
    }
}
