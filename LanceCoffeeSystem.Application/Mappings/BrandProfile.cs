using LanceCoffeeSystem.Application.Features.Brands.Commands.Create;
using LanceCoffeeSystem.Application.Features.Brands.Queries.GetAllCached;
using LanceCoffeeSystem.Application.Features.Brands.Queries.GetById;
using LanceCoffeeSystem.Domain.Entities.Catalog;
using AutoMapper;

namespace LanceCoffeeSystem.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}