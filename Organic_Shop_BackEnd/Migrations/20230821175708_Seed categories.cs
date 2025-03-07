﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Seedcategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO public.""Categories"" (""Name"")
                VALUES
                ('Хлеб'),
                ('Молочный продукты'),
                ('Фрукты'),
                ('Специи'),
                ('Овощи')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"Categories\"");
        }
    }
}
