using AutoMapper;
using Domain.Data;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public InvoiceController(ApplicationDbContext context,IMapper mapper)
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
        [HttpGet]
        public IActionResult All()
        {
            var invoices = context.SalesInvoices.Skip(0).Take(50).ToList();
            var maped = mapper.Map<List<InvoiceReadViewModel>>(invoices);
            var count = context.SalesInvoices.Count();
            var data = new { dataFiltered = count,total= count, data= maped };
            return Ok(data);
        }
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
