using AutoMapper;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Profiels
{
    public class UsersProfile:Profile
    {
        public UsersProfile()
        {
            CreateMap<ApplicationUser, UsersReadViewModel>();
            CreateMap<UsersCreateViewModel , ApplicationUser>();
            CreateMap<UsersUpdateViewModel, ApplicationUser>();
            CreateMap<UsersReadViewModel, UsersUpdateViewModel>();
            CreateMap<UsersReadViewModel, ApplicationUser>();
            CreateMap<UserCreateViewModel, ApplicationUser>();
        }
    }
}
