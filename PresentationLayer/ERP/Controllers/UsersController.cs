﻿using AutoMapper;
using Domain.baseData;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SrvicesLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers
{
   // [Authorize(Roles =RolesName.Admin)]
    public class UsersController : Controller
    {
        private readonly Irepository<ApplicationUser> repo;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> manager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(Irepository<ApplicationUser> repo, IMapper mapper, UserManager<ApplicationUser> manager,  ILogger<RegisterModel> logger, RoleManager<IdentityRole> roleManager)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.manager = manager;
            _logger = logger;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var users = mapper.Map<List<UsersReadViewModel>>(manager.Users.ToList()).Select(user =>
            new UsersReadViewModel
            {
                Id = user.Id,
                FristName = user.FristName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                IsDeleted =user.IsDeleted.ToString(),
                Roles = manager.GetRolesAsync(mapper.Map<ApplicationUser>(user)).Result.ToList()
            });
           
            return View(users);
        }
        
        public  IActionResult Edit(string id)
        {
            var user = manager.FindByIdAsync(id).Result;
            var userview = new UsersRolesViewModel {
                Id = user.Id,
                FristName = user.FristName,
                LastName = user.LastName,
                UserName=user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = roleManager.Roles.ToList().Select(role => new RolesReadViewModel { 
                RoleId=role.Id,
                RoleName=role.Name,
                Assign=manager.IsInRoleAsync(user,role.ToString()).Result
                }).ToList()
            };
            return  View(userview);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string Id, UsersRolesViewModel model)
        {
            var exist =await manager.FindByIdAsync(Id);
            if (exist == null)
                return NotFound();
            var userRoles = await manager.GetRolesAsync(exist);
            foreach (var role in model.Roles)
            {
                
                if (userRoles.Any(r=>r==role.RoleName)&&!role.Assign)
                {
                    await manager.RemoveFromRoleAsync(exist, role.RoleName);
                }
                if (!userRoles.Any(r => r == role.RoleName) && role.Assign)
                    await manager.AddToRoleAsync(exist, role.RoleName);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            var user = new UserCreateViewModel {
                Roles =roleManager.Roles.ToList().Select(role => new RolesReadViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Assign = false
                }).ToList()
            };
            return  View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            var user = new ApplicationUser { 
            Id=Guid.NewGuid().ToString(),
            FristName=model.FristName,
            LastName=model.LastName,
            UserName=model.UserName,
            Email=model.Email,
            PhoneNumber=model.PhoneNumber
            };
            if (!repo.check(model.Email.ToString()))
            {
                ModelState.AddModelError(string.Empty, "Email Exsits");
                return View( model);
            }
            else if (!repo.check(model.PhoneNumber.ToString()))
            {
                ModelState.AddModelError(string.Empty, "Mobile Exsits");
                return View(model);
            }
            else
            {
                var result = await manager.CreateAsync(user, "P@ssw0rd");
                foreach (var role in model.Roles)
                {
                    if (role.Assign)
                    {
                        await manager.AddToRoleAsync(user, role.RoleName);
                    }
                }
                if (!result.Succeeded)
                {
                     ModelState.AddModelError(string.Empty, result.ToString());
                    _logger.LogError("not added" + result.ToString());
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
        }


    }
}
