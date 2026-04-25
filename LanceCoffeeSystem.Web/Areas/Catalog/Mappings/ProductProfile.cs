using LanceCoffeeSystem.Application.Features.Products.Commands.Create;
using LanceCoffeeSystem.Application.Features.Products.Commands.Update;
using LanceCoffeeSystem.Application.Features.Products.Queries.GetAllCached;
using LanceCoffeeSystem.Application.Features.Products.Queries.GetById;
using LanceCoffeeSystem.Web.Areas.Catalog.Models;
using AutoMapper;

namespace LanceCoffeeSystem.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}