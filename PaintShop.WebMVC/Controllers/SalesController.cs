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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}