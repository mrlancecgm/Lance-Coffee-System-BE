using LanceCoffeeSystem.Web.Areas.Admin.Models;
using AutoMapper;
using System.Security.Claims;

namespace LanceCoffeeSystem.Web.Areas.Admin.Mappings
{
    public class ClaimsProfile : Profile
    {
        public ClaimsProfile()
        {
            CreateMap<Claim, RoleClaimsViewModel>().ReverseMap();
        }
    }
}