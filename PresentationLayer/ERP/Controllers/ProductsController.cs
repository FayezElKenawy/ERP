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

namespace ERP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Irepository<Product> productrepo;

        public ProductsController(ApplicationDbContext context,Irepository<Product>productrepo)
        {
            _context = context;
            this.productrepo = productrepo;
        }

        // GET: Products 
        public  IActionResult Index()
        {
            return View( productrepo.List());
        }
        //Return json products
        /*https://stackoverflow.com/questions/60604161/how-open-popup-dialog-windows-and-save-data-net-core-mvc-via-ajax */
        //public JsonResult ProductsList()
        //{

        //    return Json(_context.Products.ToList());
        //}
        // GET: Products/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id.ToString());
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductId,ArabicName,EnglishName,Model,Desc,Cost,SalePrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                productrepo.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string ProductId, [Bind("ProductId,ArabicName,EnglishName,Model,Desc,Cost,SalePrice")] Product product)
        {
            if (ProductId != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
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
