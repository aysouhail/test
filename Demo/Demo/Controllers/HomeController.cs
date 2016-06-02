using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string title = "What's a shame!";
            string message = "Can't join the DataBase server! Verify your check list!";
            try
            {
                DBModelContainer ctx = new DBModelContainer();
                var homeObj = ctx.HomeSet.FirstOrDefault();
                if (homeObj != null)
                {
                    title = homeObj.Title;
                    message = homeObj.Message;
                }
            }
            catch 
            {
            
            }
            ViewBag.Title = title;
            ViewBag.Message = message;
            return View();
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