using PaintShop.Models;
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
            var model = new CartListItem[0];
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }
    }
}