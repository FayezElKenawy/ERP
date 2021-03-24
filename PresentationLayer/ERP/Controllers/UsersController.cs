﻿using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SrvicesLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class UsersController : Controller
    {
        private readonly Irepository<ApplicationUser> repo;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> manager;
        private readonly Irepository<IdentityRole> roleRepo;

        public UsersController(Irepository<ApplicationUser> repo,IMapper mapper,UserManager<ApplicationUser>manager,Irepository<IdentityRole> roleRepo)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.manager = manager;
            this.roleRepo = roleRepo;
        }
        public IActionResult Index()
        {
            var users = mapper.Map<List<UsersReadViewModel>>(repo.List().ToList()).Select(user =>
            new UsersReadViewModel
            {
                Id = user.Id,
                FristName = user.FristName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Roles = manager.GetRolesAsync(mapper.Map<ApplicationUser>(user)).Result.ToList()
            });
           
            return View(users);
        }
        public  IActionResult Edit(string id)
        {
            var user = repo.Find(id);
            var userview = new UsersRolesViewModel {
                Id = user.Id,
                FristName = user.FristName,
                LastName = user.LastName,
                UserName=user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = roleRepo.List().Select(role => new RolesReadViewModel { 
                RoleId=role.Id,
                RoleName=role.Name,
                Assign=manager.IsInRoleAsync(user,role.ToString()).Result
                }).ToList()
            };
            return  View(userview);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string Id,UsersReadViewModel model)
        {
            var user =mapper.Map<ApplicationUser>(mapper.Map<UsersUpdateViewModel>(model));
            repo.Update(Id, user);
            return RedirectToAction(nameof(Index));
        }
    }
}