using AboutFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AboutFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;

        public HomeController()
        {
            db = new InMemoryRestaurantData(); // gonna change that later, we'll avoid the 'new' keyword
        }
        
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}