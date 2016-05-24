using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IrkIdea.Models;
using System.Data;


namespace IrkIdea.Controllers
{
    public class HomeController : Controller
    {
        
        Context db = new Context();
        
       
        public ActionResult Index()
        {
         
            ViewBag.Events = db.UsersEvents;
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult New_Event()
        {
            return View();
        }
        [HttpPost]
        public string New_Event(UserEvent Ue)
        {
            Ue.DateOfCreating = DateTime.Now;
            db.Entry(Ue).State = EntityState.Added;
            db.SaveChanges();
            return "Nice job";
        }
       
    }
}
