using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Domain.ViewModels;
using Domain.Data;
using AutoMapper;
using Domain.Models;
using Domain.Interfaces;

namespace ERP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly Irepository<Customer> repo;

        public CustomerController(ApplicationDbContext context, IMapper mapper,Irepository<Customer> repo)
        {
            this.context = context;
            this.mapper = mapper;
            this.repo = repo;
        }
        [HttpPost("List")]//customer list
        public IActionResult All()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<Customer> customers = context.Customers.Where(m => string.IsNullOrEmpty(searchValue)
                ? true
                : (m.CustArName.Contains(searchValue) || m.CustEnName.Contains(searchValue) ||
                m.CustAdress.Contains(searchValue)));

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                customers = customers.OrderBy(sortColumn + " " + sortColumnDirection);
            var data = customers.Skip(skip).Take(pageSize).ToList();
            var maped = mapper.Map<List<CustomerReadViewModel>>(customers);
            var count = maped.Count();
            var jdata = new { drew = 1, recordsFiltered = count, recordsTotal = count, data = data };
            return Ok(jdata);
        }

        [HttpPost("Create")]//create new customer
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustID,CustArName,CustEnName,CustMobileNo,CustAdress,CustBalance,CustOpenBalance,AccountNo")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Ok();
            }
            repo.Add(customer);
            return Ok(customer);
        }
    }
}
