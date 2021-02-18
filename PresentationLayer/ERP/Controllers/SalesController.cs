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
        public ActionResult _invoicetable()
        {
            return PartialView();
        }
        public ActionResult Create()
        {
            var id = int.Parse(salesRepo.MaxId());
            ViewBag.InvoiceId = (id + 1).ToString();
            var model = new InvoiceCustomerViewModel
            {
                 Products=productRepo.List().ToList(),
                 Customers=CustomerRepo.List().ToList()

            };
            return View(model);
        }
        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IEnumerable< InvoiceCustomerViewModel> listdetails)
        {
            try
            {
                //var smodel = new SalesInvoice
                //{
                //    InvoiceNo = Modeldetails.InvoiceId,
                //    InvoiceDate = Modeldetails.InvoiceDate,
                //    InvoiceType = Modeldetails.InvoiceType,
                //    InvoiceTotal = Modeldetails.InvoiceTotal,
                //    InvoiceDiscount = Modeldetails.InvoiceDiscount,
                //    InvoiceNetTotal = Modeldetails.InvoiceNetTotal,
                //    InvoicePaid = Modeldetails.InvoicePaid,
                //    CustID= Modeldetails.CustID,
                //    InvoiceChange= Modeldetails.InvoiceChange
                //};
                //salesRepo.Add(smodel);
                //foreach (var item in listdetails)
                //{
                //    var model = new SalesDetails
                //    {
                //        InvoiceId = item.InvoiceId,
                //        ProductID = item.ProductID,
                //        Quantity = item.Quantity,
                //        SalesPrice = item.SalesPrice,
                //        Total = item.Total,
                //        discount = item.discount,
                //        VatAmount = item.VatAmount,
                //        TotalWithVat = item.TotalWithVat,
                //        Cost = productRepo.Find(item.ProductID).Cost//get cost of product
                //    };
                //    detailrepo.Add(model);
                //}

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex.ToString();
                return RedirectToAction(nameof(Create));
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
