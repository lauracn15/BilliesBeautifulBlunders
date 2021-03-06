﻿using Microsoft.AspNet.Identity;
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
            var productService = CreateProductService();
            ViewBag.ProductId = new SelectList(productService.GetProducts(), "ProductId", "Title");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCartService();
            var productService = CreateProductService();

            productService.GetProductById(model.ProductId);

           
            
            if (service.CreateCart(model))
            {
                TempData["SaveResult"] = "Your cart is up to date!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Cart could not be updated.");

            return View(model);
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
                    
                };
            var productService = CreateProductService();
            ViewBag.ProductId = new SelectList(productService.GetProducts(), "ProductId", "Title");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CartEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CartId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCartService();

            if (service.UpdateCart(model))
            {
                TempData["SaveResult"] = "Your cart has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your cart could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCartService();
            var model = svc.GetCartById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCartService();
            service.DeleteCart(id);

            TempData["SaveResult"] = "This product has been removed from your cart.";

            return RedirectToAction("Index");

        }
    }
}