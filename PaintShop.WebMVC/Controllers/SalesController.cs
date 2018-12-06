using Microsoft.AspNet.Identity;
using PaintShop.Models;
using PaintShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaintShop.WebMVC.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [Authorize]
        public ActionResult Index()
        {
            var model = new SalesListItem[0];

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        private CartService CreateCartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);
            return service;
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }

        private SalesService CreateSalesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSalesService();
            var model = svc.GetSaleById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSale(SalesCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSalesService();

            if (service.CreateSales(model))
            {
                TempData["SaveResult"] = "Your transaction is up to date!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be updated.");

            return View(model);
        }







    }

}