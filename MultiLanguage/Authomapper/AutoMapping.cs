using AutoMapper;
using MultiLanguage.Core.ViewModels;
using Multipisus.DataLayer.Entities;

namespace MultiLanguage.Authomapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ApplicationUser, UserViewModels>().ReverseMap();
        }
    }
}
