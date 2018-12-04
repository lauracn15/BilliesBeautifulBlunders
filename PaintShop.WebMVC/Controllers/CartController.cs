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
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);
            var model = service.GetCart();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCartService();

            if (service.CreateCart(model))
            {
                TempData["SaveResult"] = "Your cart is up to date!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Cart could not be updated.");

            return View(model);
        }

        private CartService CreateCartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCartService();
            var model = svc.GetCartById(id);

            return View(model);
        }
        
 
        public ActionResult Edit(int id)
        {
            var service = CreateCartService();
            var detail = service.GetCartById(id);
            var model =
                new CartEdit
                {
                    CartId = detail.CartId,
                    ProductId = detail.ProductId,
                    AmountOfProducts = detail.AmountOfProducts
                };
            return View(model);
        }


    }
}