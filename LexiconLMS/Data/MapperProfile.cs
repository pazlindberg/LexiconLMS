using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexiconLMS.Models;
using LexiconLMS.Models.ViewModel;

namespace LexiconLMS.Data
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>();
            //CreateMap<User, UserViewModel>()
            //    .ForMember(
            //    dest => dest.FirstName,
            //    from => from.MapFrom(s => s.FirstName));

            //CreateMap<User, UserViewModel>()
            //    .ForMember(
            //    dest => dest.LastName,
            //    from => from.MapFrom(s => s.LastName));

            //CreateMap<User, UserViewModel>()
            //    .ForMember(
            //    dest => dest.Email,
            //    from => from.MapFrom(s => s.Email));

            //CreateMap<User, UserViewModel>()
            //    .ForMember(
            //    dest => dest.PhoneNumber,
            //    from => from.MapFrom(s => s.PhoneNumber));
        }
    }
}
