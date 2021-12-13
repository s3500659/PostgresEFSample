using AutoMapper;
using PostgresEF.Dtos;
using PostgresEF.Models;

namespace PostgresEF.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ReadProductDto>();


        }
    }
}
