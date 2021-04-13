using Domain.Data;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace ERP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products.ToList().ToList();
        }
        [HttpPost]
        public IActionResult All()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);
            var partcod= Request.Form["columns[0][search][value]"];
            var partname = Request.Form["columns[1][search][value]"];
            var balance = Request.Form["columns[2][search][value]"];
           

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<Product> products = context.Products.
                Where(m => string.IsNullOrEmpty(partcod) ? true : (m.ProductId.Contains(partcod))).
                Where(m => string.IsNullOrEmpty(partname) ? true : (m.ArabicName.Contains(partname))).
                Where(m => string.IsNullOrEmpty(balance) ? true : (m.Balance.ToString().Contains(balance)));

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                products = products.OrderBy(sortColumn + " " + sortColumnDirection);
            var data = products.Skip(skip).Take(pageSize).ToList();
            var count = products.Count();
            var jdata = new { drew = 1, recordsFiltered = count, recordsTotal=count, data= data };
            return Ok(jdata);
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
