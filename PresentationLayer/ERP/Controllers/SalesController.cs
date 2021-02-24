using Domain.Models;
using Domain.ViewModels;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            var invoices = new InvoiceCustomerViewModel
            {
                Products= productRepo.List().ToList(),
                Customers = CustomerRepo.List().ToList(),
                Invoices= salesRepo.List().ToList(),
                Details= detailrepo.List().ToList()

            };
            return View(invoices);
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
        public IActionResult Create([Bind("InvoiceNo,downdetails,ProductID,InvoiceDate,InvoiceType,CustID,InvoiceTotal,InvoiceDiscount,InvoiceNetTotal,InvoicePaid,InvoiceChange")] 
        InvoiceCustomerViewModel Modeldetails)
        {
            try
            {
                string totaljson = Modeldetails.downdetails.ToString();
                SalesInvoice hh = (SalesInvoice)totals(totaljson);
                var smodel = new SalesInvoice
                {
                    InvoiceNo = Modeldetails.InvoiceNo,
                    InvoiceDate = Modeldetails.InvoiceDate,
                    InvoiceType = Modeldetails.InvoiceType,
                    InvoiceTotal = (double)returnzero(hh.InvoiceTotal.ToString()),
                    InvoiceDiscount = (double)returnzero(hh.InvoiceDiscount.ToString()),
                    InvoiceNetTotal = (double)returnzero(hh.InvoiceNetTotal.ToString()),
                    InvoicePaid = (double)returnzero(hh.InvoicePaid.ToString()),
                    CustID = Modeldetails.CustID,
                    InvoiceChange = (double)returnzero(hh.InvoiceChange.ToString())
                };
                salesRepo.Add(smodel);
                string h = Modeldetails.ProductID.ToString();
                List<SalesDetails>items = JsonConvert.DeserializeObject<List<SalesDetails>>(h.ToString());
                foreach (var item in items)
                {
                    var model = new SalesDetails
                    {
                        InvoiceId = Modeldetails.InvoiceNo,
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        SalesPrice = item.SalesPrice,
                        Total = item.Total,
                        discount = returnzero(item.discount.ToString()),
                        VatAmount = item.VatAmount,
                        TotalWithVat = item.TotalWithVat,
                        Cost = productRepo.Find(item.ProductID).Cost,//get cost of product
                        
                    };
                   var pro= productRepo.Find(item.ProductID);
                    var productupdate = new Product
                    {
                        ProductId=pro.ProductId,
                         Balance=(double)(pro.Balance-item.Quantity),
                         ArabicName = pro.ArabicName,
                        EnglishName = pro.EnglishName,
                        Model = pro.Model,
                        Desc = pro.Desc,
                        Cost = pro.Cost,
                        SalePrice = pro.SalePrice,
                        OpenBalance = pro.OpenBalance,
                        OpenCost = pro.OpenCost
                    };
                    productRepo.Update(item.ProductID,productupdate);
                    detailrepo.Add(model);
                }
                return RedirectToAction(nameof(Create));
            }
            catch(Exception e)
            { 
                throw;
            }
        }
      public  double returnzero(string value)
        {
            if (value==null||value=="")
            {
                return 0.0;
            }
                return double.Parse(value); 
        }
        public object totals(string total)
        {

            List<SalesInvoice> totals = JsonConvert.DeserializeObject<List<SalesInvoice>>(total.ToString());
            object h="";
            foreach (var item in totals)
            {
                SalesInvoice t = new SalesInvoice
                {
                    InvoiceChange = item.InvoiceChange,
                    InvoicePaid=item.InvoicePaid,
                    InvoiceDiscount=item.InvoiceDiscount,
                    InvoiceNetTotal=item.InvoiceNetTotal,
                    InvoiceTotal = item.InvoiceTotal
                };
                 h = t;
            }

            return h;
        }
        // GET: SalesController/Edit/5
        public ActionResult Edit(string id)
        {
            var model = new InvoiceCustomerViewModel
            {
                invoice = salesRepo.Find(id),
                Details=detailrepo.List().Where(i=>i.InvoiceId==id).ToList()

            };
            return View(model);
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
