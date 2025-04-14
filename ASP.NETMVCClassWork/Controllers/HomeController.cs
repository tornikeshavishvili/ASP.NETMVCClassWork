using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace ASP.NETMVCClassWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetLanguage(string lang)
        {

            Debug.WriteLine(lang);

            if (!string.IsNullOrEmpty(lang))
            {
                // Save chosen language in a cookie (so it persists)
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie);
            }
            return Redirect(Request.UrlReferrer.ToString());  // redirect back to previous page
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

        public JsonResult MyJson()
        {
            var data = new { Name = "Tornike", Age = 30 };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}