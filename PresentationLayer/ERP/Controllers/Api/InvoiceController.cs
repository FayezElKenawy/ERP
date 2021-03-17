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
    }
}
