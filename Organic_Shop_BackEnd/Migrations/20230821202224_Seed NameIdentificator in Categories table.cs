using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class SeedNameIdentificatorinCategoriestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE public.""Categories"" SET ""NameIdentificator"" = 'bread' WHERE ""Id"" = '1';
                                    UPDATE public.""Categories"" SET ""NameIdentificator"" = 'dairy' WHERE ""Id"" = '2';
                                    UPDATE public.""Categories"" SET ""NameIdentificator"" = 'fruits' WHERE ""Id"" = '3';
                                    UPDATE public.""Categories"" SET ""NameIdentificator"" = 'seasonings' WHERE ""Id"" = '4';
                                    UPDATE public.""Categories"" SET ""NameIdentificator"" = 'vegetables' WHERE ""Id"" = '5';");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
