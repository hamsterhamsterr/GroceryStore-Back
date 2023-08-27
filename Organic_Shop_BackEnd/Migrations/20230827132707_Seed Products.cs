using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.""Products"" (""Title"", ""Price"", ""ImageUrl"", ""CategoryId"")
                VALUES
                ('Spinach', 2.5, 'https://upload.wikimedia.org/wikipedia/commons/a/ae/Spinach_Plant_Nourishment_Meal_Fresh_Healthy_Bio.jpg', 16),
                ('Freshly Baked Bread', 3, 'https://p1.pxfuel.com/preview/103/128/7/bread-even-baked-white-bread-baked.jpg', 12),
                ('Avocado', 1.75, 'https://upload.wikimedia.org/wikipedia/commons/5/50/Avocado_open.jpg', 14)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"Products\"");
        }
    }
}
