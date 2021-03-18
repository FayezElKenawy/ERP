using Domain.Interfaces;
using Domain.Models;
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

        public UsersController(Irepository<ApplicationUser> repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var users = repo.List().ToList();
            return View(users);
        }
    }
}
