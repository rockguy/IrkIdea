using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Queste.Models;
using System.Data;


namespace Queste.Controllers
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
/*
        [HttpGet]
        [Authorize]
        public ActionResult New_Event()
        {
            return View();
        }
        [HttpPost]
        public string New_Event(Quest Ue)
        {
            Ue.DateOfCreating = DateTime.Now;
            db.Entry(Ue).State = EntityState.Added;
            db.SaveChanges();
            return "Nice job";
        }
  */
        [Authorize(Roles = "admin")]
        public string ViewRole()
        {
            return "Ваша роль: Администратор";
        }
        public string ViewProfile()
        {
            HttpContext.Profile["FirstName"] = "Vova";
            HttpContext.Profile["LastName"] = "Pupkin";
            HttpContext.Profile.SetPropertyValue("Age", 28);

            return "Имя Фамилия: " + HttpContext.Profile["FirstName"].ToString() +
                " " + HttpContext.Profile["LastName"].ToString() + " возраст: " +
                HttpContext.Profile["Age"].ToString();
        }
    }
}
