using LanceCoffeeSystem.Application.Features.Products.Commands.Create;
using LanceCoffeeSystem.Application.Features.Products.Queries.GetAllCached;
using LanceCoffeeSystem.Application.Features.Products.Queries.GetAllPaged;
using LanceCoffeeSystem.Application.Features.Products.Queries.GetById;
using LanceCoffeeSystem.Domain.Entities.Catalog;
using AutoMapper;

namespace LanceCoffeeSystem.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}