using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductstodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "5ba0fbe5-b125-470b-b9a1-c890783944d7", null, "Admin", "ADMIN" },
                    { "ea82a3e8-ebb6-4c24-bc0b-7720b16b1156", null, "User", "USER" }
                });

            migrationBuilder.Sql(@"DELETE FROM public.""Products""");
            migrationBuilder.Sql(@"INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (14, 'Tomato', 2.5, 'https://images.unsplash.com/photo-1561136594-7f68413baa99?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 5);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (31, 'Milk', 2, 'https://c1.wallpaperflare.com/preview/195/500/990/milk-wood-bottle-drink-food-glass.jpg', 2);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (15, 'Lettuce', 1.75, 'https://images.unsplash.com/photo-1622205313162-be1d5712a43f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 5);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (6, 'Avocado', 2, 'https://images.unsplash.com/photo-1601039641847-7857b994d704?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (5, 'Freshly Baked Bread', 3, 'https://images.unsplash.com/photo-1549931319-a545dcf3bc73?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 1);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (16, 'Cauliflower', 1.75, 'https://images.unsplash.com/photo-1584615467033-75627d04dffe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 5);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (17, 'Banana', 1.25, 'https://images.unsplash.com/photo-1606050627722-3646950540ca?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (18, 'Orange', 1.69999999999999996, 'https://images.unsplash.com/photo-1591206369811-4eeb2f03bc95?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (19, 'Apple', 2, 'https://images.unsplash.com/photo-1522507806580-0be3530796be?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (21, 'Peach', 2, 'https://images.unsplash.com/photo-1639588473831-dd9d014646ae?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (22, 'Cinnamon Sticks', 0.5, 'https://images.unsplash.com/photo-1607430866111-3f2b5804f850?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 4);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (23, 'Saffron', 3, 'https://live.staticflickr.com/65535/50335183328_2c4f95358b_b.jpg', 4);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (24, 'Ground Turmeric', 0.5, 'https://live.staticflickr.com/7848/45585559655_1c01492223_b.jpg', 4);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (25, 'Coriander Seeds', 0.5, 'https://images.unsplash.com/photo-1608797179072-4268dd68eff2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 4);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (26, 'Lavash Bread', 1.25, 'https://live.staticflickr.com/2561/3822527016_1a5a2b779f_b.jpg', 1);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (27, 'Bagel Bread', 1, 'https://images.unsplash.com/photo-1645995884824-8a7230f158f8?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 1);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (28, 'Strawberry', 1.94999999999999996, 'https://images.unsplash.com/photo-1543528176-61b239494933?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (29, 'Baguette Bread', 1.25, 'https://images.unsplash.com/photo-1602557618699-b5a418628614?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 1);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (32, 'Cheese', 3, 'https://i0.hippopx.com/photos/666/632/842/cheese-dairy-brie-cheese-sandwich-preview.jpg', 2);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (4, 'Spinach', 2.5, 'https://images.unsplash.com/photo-1588891557811-5f2fba9e3009?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 5);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (20, 'Grape', 2, 'https://images.unsplash.com/photo-1578829779691-99b60bd8c7be?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);
                                   INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (30, 'Melon', 3, 'https://images.unsplash.com/photo-1636619299895-ecbb6c9f027f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=640&q=80', 3);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ba0fbe5-b125-470b-b9a1-c890783944d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea82a3e8-ebb6-4c24-bc0b-7720b16b1156");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "825c9425-19fc-4b0c-b78f-8f7831ae6ac3", null, "User", "USER" },
                    { "cf36b3a2-672e-461e-9913-0dc44e59bba2", null, "Admin", "ADMIN" }
                });
        }
    }
}
