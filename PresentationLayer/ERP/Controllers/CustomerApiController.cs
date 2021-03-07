using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Irepository<Customer> customerrepo;
        public CustomerApiController(Irepository<Customer> customerrepo, ApplicationDbContext context)
        {
            this.customerrepo = customerrepo;
            _context = context;
        }


        [HttpPost]
        public IActionResult GetAllCustomers()
        {
            var customers = _context.Customers.Skip(0).Take(10).ToList();
            var count = customers.Count();
            var jsndata = new { draw = 1, recordsFiltered = count, recordsTotal= count, data=customers };
            return Ok(jsndata);
        }
    }
}
