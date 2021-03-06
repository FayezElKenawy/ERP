using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Data;
using Domain.Interfaces;
using AutoMapper;
using Domain.ViewModels;

namespace ERP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Irepository<Product> productrepo;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context,Irepository<Product>productrepo,IMapper mapper)
        {
            _context = context;
            this.productrepo = productrepo;
            _mapper = mapper;
        }

        // GET: Products 
        public  IActionResult Index()
        {
            var products=productrepo.List().ToList();


            return View( (_mapper.Map<List<ProductReadViewModel>>(products)).Skip(0).Take(10));
        }
        //Return json products
        /*https://stackoverflow.com/questions/60604161/how-open-popup-dialog-windows-and-save-data-net-core-mvc-via-ajax */
        [HttpPost]
        public IActionResult ProductsList()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];
            var products = productrepo.List().ToList();
            var readProduct= (_mapper.Map<List<ProductReadViewModel>>(products)).Skip(skip).Take(pageSize);
            var allrecords = products.Count();
            var jsonData = new { recordsFiltered = allrecords, allrecords, readProduct };
            return Ok(jsonData);
        }
        // GET: Products/Details/
        public IActionResult Details(string id)
        {
            var product = productrepo.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            //var product =  _context.Products
            //    .FirstOrDefaultAsync(m => m.ProductId == id.ToString());

            return View(_mapper.Map<ProductReadViewModel>(product));
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductId,ArabicName,EnglishName,Model,Desc,Cost,SalePrice")] ProductCreateVieewModel product)
        {
            if (ModelState.IsValid)
            {
                var pro = _mapper.Map<Product>(product);
                productrepo.Add(pro);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(string id)
        {
            var product = productrepo.Find(id);
            if (product == null)
            {
                return NotFound();
            }
           
            return View(_mapper.Map<ProductReadViewModel>(product));
        }

        // POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string ProductId, [Bind("ProductId,ArabicName,EnglishName,Model,Desc,Cost,SalePrice")] ProductReadViewModel product)
        {
            var pro = productrepo.Find(ProductId);
            if (pro ==null)
            {
                return NotFound();
            }
            var rpro = _mapper.Map<ProductUpdateViewModel>(product);
             _mapper.Map(rpro, pro);
            productrepo.Update(ProductId, pro);
            productrepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string ProductId)
        {
            if (ProductId == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == ProductId);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string ProductId)
        {
            return _context.Products.Any(e => e.ProductId == ProductId);
        }
    }
}
