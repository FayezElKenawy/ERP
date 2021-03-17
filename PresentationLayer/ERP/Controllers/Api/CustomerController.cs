using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ViewModels;
using Domain.Data;
using AutoMapper;

namespace ERP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CustomerController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        // GET: api/<ProductController>
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    return context.Products.ToList().ToList();
        //}
        [HttpPost]
        public IActionResult All()
        {
            var customers = context.Customers.Skip(0).Take(50).ToList();
            var maped = mapper.Map<List<CustomerReadViewModel>>(customers);
            var count = context.Customers.Count();
            var data = new { drew = 1, dataFiltered = count,total= count, data = customers };
            return Ok(data);
        }
    }
}
