using LanceCoffeeSystem.Application.Features.Brands.Commands.Create;
using LanceCoffeeSystem.Application.Features.Brands.Commands.Update;
using LanceCoffeeSystem.Application.Features.Brands.Queries.GetAllCached;
using LanceCoffeeSystem.Application.Features.Brands.Queries.GetById;
using LanceCoffeeSystem.Web.Areas.Catalog.Models;
using AutoMapper;

namespace LanceCoffeeSystem.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}