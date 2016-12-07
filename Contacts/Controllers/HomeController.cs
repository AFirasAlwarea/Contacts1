using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//C:\Users\deltagare\Source\Repos\Contacts\Contacts\App_Data\Contacts.Models.PeopleDB.mdf
namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        PeopleDB db = new PeopleDB();

        public JsonResult AjaxThatReturnsJson()
        {
            object veryIP = new { FirstName = "Firas", LastName = "Alwarea" };
            return Json(veryIP, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AjaxThatReturnsJsonList()
        {
            var friends = db.Person.ToList();
            return Json(friends, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult AjaxThatReturnsJsonPerson(int? Id)
        {
            object myInfo = null;

            myInfo = db.Person.SingleOrDefault(P => P.Id == Id);

            if (myInfo == null)
            {
                myInfo = new { Id = 0, FirstName = "Not", LastName = "Found" };
            }

            return Json(myInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AngularSPA()
        {
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