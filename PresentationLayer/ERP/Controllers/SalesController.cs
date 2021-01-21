using Domain.Models;
using Domain.ViewModels;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class SalesController : Controller
    {
        private readonly Irepository<Product> productRepo;
        private readonly Irepository<Customer> CustomerRepo;
        private readonly Irepository<SalesInvoice> salesRepo;

        public SalesController(Irepository<Product> productRepo, Irepository<Customer> customerRepo, Irepository<SalesInvoice> salesRepo)
        {
            this.productRepo = productRepo;
            CustomerRepo = customerRepo;
            this.salesRepo = salesRepo;
        }

        // GET: SalesController
        public ActionResult Index()
        {
            var Invoices = salesRepo.List().ToList();
            return View(Invoices);
        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesController/Create
        public ActionResult Create()
        {
            var model = new SalesDetails
            {
                Products = productRepo.List().ToList(),
                
            };
           
           
            return View(model);
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
