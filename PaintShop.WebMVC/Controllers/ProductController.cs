using Microsoft.AspNet.Identity;
using PaintShop.Models;
using PaintShop.Services;
using PaintShop.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaintShop.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
            return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);

            service.CreateProduct(model);

            return RedirectToAction("Create");
        }
    }
}