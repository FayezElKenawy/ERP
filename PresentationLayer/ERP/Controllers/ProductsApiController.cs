using AutoMapper;
using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
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
    public class ProductsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Irepository<Product> productrepo;
        private readonly IMapper _mapper;
        public ProductsApiController(ApplicationDbContext context, Irepository<Product> productrepo, IMapper mapper)
        {
            _context = context;
            this.productrepo = productrepo;
            _mapper = mapper;
        }
        /*https://stackoverflow.com/questions/60604161/how-open-popup-dialog-windows-and-save-data-net-core-mvc-via-ajax */
        [HttpPost]
        public IActionResult ProductsList()//for data table
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);
            var draw = Request.Form["draw"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<Product> products = _context.Products.Where(m => string.IsNullOrEmpty(searchValue)
                ? true
                : (m.ProductId.Contains(searchValue) || m.ArabicName.Contains(searchValue) || m.EnglishName.Contains(searchValue) || m.Desc.Contains(searchValue)));

            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //    products = products.OrderBy(p=>p string.Concat(sortColumn, " ", sortColumnDirection));

            var readProduct = (_mapper.Map<List<ProductReadViewModel>>(products)).Skip(skip).Take(pageSize);
            var allrecords = products.Count();
            var jsonData = new { draw = draw, recordsFiltered = allrecords, recordsTotal=allrecords, data=readProduct };
            return Ok(jsonData);
        }
    }
}
