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
        }
    }
}
