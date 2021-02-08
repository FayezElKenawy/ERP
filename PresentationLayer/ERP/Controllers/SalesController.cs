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
        private readonly Irepository<SalesDetails> detailrepo;

        public SalesController(Irepository<Product> productRepo, Irepository<Customer> customerRepo, Irepository<SalesInvoice> salesRepo, Irepository<SalesDetails> detailrepo)
        {
            this.productRepo = productRepo;
            CustomerRepo = customerRepo;
            this.salesRepo = salesRepo;
            this.detailrepo = detailrepo;
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
            var id = int.Parse(salesRepo.MaxId());
            ViewBag.InvoiceId = (id + 1).ToString();
            var model = new InvoiceCustomerViewModel
            {
                Customers = CustomerRepo.List().ToList(),
                Products = productRepo.List().ToList()
            };
            return View(model);
        }
        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesInvoice collection,[Bind("ProductID,Quantity,SalesPrice,Total,discount")] SalesDetails details)
        {
            try
            {
                salesRepo.Add(collection);
                var model = new SalesDetails
                {
                    InvoiceId = int.Parse(collection.InvoiceId),
                    ProductID = details.ProductID,
                    Quantity = details.Quantity,
                    SalesPrice = details.SalesPrice,
                    Total = details.Total,
                    discount = details.discount,
                    Cost= productRepo.Find(details.ProductID).Cost//get cost of product
            };
                detailrepo.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
                return RedirectToAction(nameof(Index));
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
