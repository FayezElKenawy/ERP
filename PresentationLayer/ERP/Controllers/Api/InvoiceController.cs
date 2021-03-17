using AutoMapper;
using Domain.Data;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
        [HttpPost]
        public IActionResult All()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<SalesInvoice> invoices = context.SalesInvoices.Where(m => string.IsNullOrEmpty(searchValue)
                ? true
                : (m.InvoiceNo.Contains(searchValue) || m.CustID.Contains(searchValue) ||
                m.InvoiceDate.ToShortDateString().Contains(searchValue)));

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                invoices = invoices.OrderBy(sortColumn + " " + sortColumnDirection);
            var data = invoices.Skip(skip).Take(pageSize).ToList();
            var count = invoices.Count();
            var jdata = new { drew = 1, recordsFiltered = count, recordsTotal = count, data = data };
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
