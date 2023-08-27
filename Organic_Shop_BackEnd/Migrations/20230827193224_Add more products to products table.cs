using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic_Shop_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Addmoreproductstoproductstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM public.""Products""");

            migrationBuilder.Sql(@"INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (4, 'Spinach', 3, 'https://upload.wikimedia.org/wikipedia/commons/a/ae/Spinach_Plant_Nourishment_Meal_Fresh_Healthy_Bio.jpg', 16);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (5, 'Freshly Baked Bread', 3, 'https://p1.pxfuel.com/preview/103/128/7/bread-even-baked-white-bread-baked.jpg', 12);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (6, 'Avocado', 2, 'https://upload.wikimedia.org/wikipedia/commons/5/50/Avocado_open.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (14, 'Tomato', 2.5, 'https://upload.wikimedia.org/wikipedia/commons/8/89/Tomato_je.jpg', 16);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (15, 'Lettuce', 1.75, 'https://c0.wallpaperflare.com/preview/257/842/322/salad-lettuce-green-salad-iceberg-lettuce.jpg', 16);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (16, 'Cauliflower', 1.75, 'https://live.staticflickr.com/2803/4268224037_62efec281b_b.jpg', 16);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (17, 'Banana', 1.25, 'https://upload.wikimedia.org/wikipedia/commons/4/4c/Bananas.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (18, 'Orange', 1.69999999999999996, 'https://upload.wikimedia.org/wikipedia/commons/c/c4/Orange-Fruit-Pieces.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (19, 'Apple', 2, 'https://upload.wikimedia.org/wikipedia/commons/1/15/Red_Apple.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (20, 'Grape', 2, 'https://c1.wallpaperflare.com/preview/289/915/579/grapes-fruit-winegrowing-red-grapes.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (21, 'Peach', 2, 'https://i1.pickpik.com/photos/724/199/672/peach-fruit-red-yellow-preview.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (22, 'Cinnamon Sticks', 0.5, 'https://live.staticflickr.com/65535/50717060276_c75e887285_b.jpg', 15);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (23, 'Saffron', 3, 'https://live.staticflickr.com/65535/50335183328_2c4f95358b_b.jpg', 15);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (24, 'Ground Turmeric', 0.5, 'https://live.staticflickr.com/7848/45585559655_1c01492223_b.jpg', 15);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (25, 'Coriander Seeds', 0.5, 'https://p1.pxfuel.com/preview/76/790/551/coriander-seeds-bowl-spices.jpg', 15);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (26, 'Lavash Bread', 1.25, 'https://live.staticflickr.com/2561/3822527016_1a5a2b779f_b.jpg', 12);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (27, 'Bagel Bread', 1, 'https://upload.wikimedia.org/wikipedia/commons/8/85/Bagel_with_sesame_3.jpg', 12);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (28, 'Strawberry', 1.94999999999999996, 'https://p1.pxfuel.com/preview/149/738/524/strawberry-strawberries-fruit-healthy-red-groceries.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (29, 'Baguette Bread', 1.25, 'https://c1.wallpaperflare.com/preview/184/318/449/baguette-bread-baked-goods-food.jpg', 12);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (30, 'Melon', 3, 'https://c1.wallpaperflare.com/preview/210/814/490/muskmelons-cantaloupes-fruit-melon.jpg', 14);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (32, 'Cheese', 3, 'https://i0.hippopx.com/photos/666/632/842/cheese-dairy-brie-cheese-sandwich-preview.jpg', 13);
                                    INSERT INTO public.""Products"" (""Id"", ""Title"", ""Price"", ""ImageUrl"", ""CategoryId"") VALUES (31, 'Milk', 2, 'https://c1.wallpaperflare.com/preview/195/500/990/milk-wood-bottle-drink-food-glass.jpg', 13);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
