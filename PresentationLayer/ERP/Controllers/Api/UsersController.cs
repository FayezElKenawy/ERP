using Domain.baseData;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> manager;
        public UsersController(UserManager<ApplicationUser> manager)
        {
            this.manager = manager;
        }


        [HttpPatch("{UserId}")]
        public IActionResult Delete(string UserId, JsonPatchDocument<ApplicationUser> user)
        {
            var newUser = manager.FindByIdAsync(UserId).Result;
            user.ApplyTo(newUser,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           var r= manager.UpdateAsync(newUser).Result;
            return new ObjectResult(newUser);
        }
    }
}
