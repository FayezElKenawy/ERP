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
        private readonly UsersRepository repo;

        public UsersController(UsersRepository repo)
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
