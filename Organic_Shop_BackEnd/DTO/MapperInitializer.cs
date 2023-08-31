using AutoMapper;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.DTO
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<ApiUser, RegisterUserDTO>().ReverseMap();
            CreateMap<ApiUser, LoginUserDTO>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDTO>().ReverseMap();
            CreateMap<Order, GetOrderDTO>().ReverseMap();
            CreateMap<OrderItem, GetOrderItemDTO>().ReverseMap();
        }
    }
}
