//using AspNetCore;
using AutoMapper;
using LexiconLMS.Models;
using LexiconLMS.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LexiconLMS.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Models.Task, TaskListViewModel>();
            CreateMap<Models.Task, TaskCreateViewModel>().ReverseMap();
            CreateMap<Models.Task, TaskEditViewModel>();
            CreateMap<Models.Task, TaskDetailsViewModel>();
            CreateMap<Models.Task, TaskDeleteViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<Models.Module, ModuleEditViewModel>();
            CreateMap<Models.Module, ModuleDetailViewModel>();
            //CreateMap<Members, MemberViewModel>()
            //    .ForMember(
            //    dest => dest.NumberOfVehicles,
            //    from => from.MapFrom(s => s.Vehicles.Count));

        }

       
    }
}
