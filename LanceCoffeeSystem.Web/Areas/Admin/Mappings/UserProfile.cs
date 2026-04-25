using LanceCoffeeSystem.Infrastructure.Identity.Models;
using LanceCoffeeSystem.Web.Areas.Admin.Models;
using AutoMapper;

namespace LanceCoffeeSystem.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}