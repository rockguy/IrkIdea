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
        UserContext UserDb = new UserContext();
        
       
        public ActionResult Index()
        {           
            ViewBag.Name = HttpContext.User.Identity.Name;
            ViewBag.Role = UserDb.Roles;
            return View();
        }
        [HttpGet]
        public ActionResult New_Quest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New_Quest(Quest quest)
        {
            
            return View("Index");
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
            HttpContext.Profile["FirstName"] = HttpContext.User.Identity.Name;
            
           
            return "Имя Фамилия: " + HttpContext.Profile["FirstName"].ToString() +
                " " + HttpContext.Profile["LastName"].ToString() + " возраст: " +
                HttpContext.Profile["Age"].ToString();
        }
    }
}
