using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
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

        public UsersController(Irepository<ApplicationUser> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var users =mapper.Map<List<UsersReadViewModel>>( repo.List().ToList());
           
            return View(users);
        }
        public  IActionResult Edit(string id)
        {
            var user = mapper.Map<UsersReadViewModel>(repo.Find(id));
            return  View(user);
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
