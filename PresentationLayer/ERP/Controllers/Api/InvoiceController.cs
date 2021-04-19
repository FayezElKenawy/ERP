using AutoMapper;
using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
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
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly Irepository<SalesInvoice> repo;

        public InvoiceController(ApplicationDbContext context,IMapper mapper,Irepository<SalesInvoice> repo)
        {
            this.context = context;
            this.mapper = mapper;
            this.repo = repo;
        }
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
            var data = invoices.OrderByDescending(m=>m.InvoiceDate).Skip(skip).Take(pageSize).ToList();
            var count = invoices.Count();
            var jdata = new { drew = 1, recordsFiltered = count, recordsTotal = count, data = data };
            return Ok(jdata);
        }

        [HttpPatch("{InvoiceNo}")]
        public IActionResult Delete(string InvoiceNo, JsonPatchDocument<SalesInvoice> invoice)
        {
            var newUser = repo.Find(InvoiceNo);
            invoice.ApplyTo(newUser, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var r = repo.Update(InvoiceNo,newUser);
            return new ObjectResult(newUser);
        }
    }
}
