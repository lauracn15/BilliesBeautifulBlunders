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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            var model = service.GetSales();

            return View(model);
        }

        public ActionResult Create()
        {
            var cartService = CreateCartService();
            ViewBag.CartId = new SelectList(cartService.GetCart(), "CartId", "CartId");
            return View();
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSalesService();
            var model = svc.GetSaleById(id);

            return View(model);
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
        private CartService CreateCartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);
            return service;
        }

        private SalesService CreateSalesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            return service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSalesService();
            var cartService = CreateCartService();

            cartService.GetCartById(model.CartId);

            if (service.CreateSales(model))
            {
                TempData["SaveResult"] = "Your transaction is up to date!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be updated.");

            return View(model);
        }



        public ActionResult Edit(int id)
        {
            var service = CreateSalesService();
            var detail = service.GetSaleById(id);
            var model =
                new SalesEdit
                {
                    SalesId = detail.SalesId,
                    CartId = detail.CartId,
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSalesService();
            var model = svc.GetSaleById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSalesService();
            service.DeleteSales(id);

            TempData["SaveResult"] = "This transaction has been deleted.";

            return RedirectToAction("Index");
        }



    }

}