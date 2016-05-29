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
        
        UserContext db = new UserContext();
        
               
        public ActionResult Index()
        {           
            ViewBag.Name = HttpContext.User.Identity.Name;
            
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult New_Quest()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult New_Quest(Quest quest)
        {
            quest.Owner = HttpContext.User.Identity.Name;
            quest.DateOfCreation = DateTime.Now;
            db.Entry(quest).State = EntityState.Added;
            db.SaveChanges();
            return View("Index");
        }
        
        [HttpGet]
        public ActionResult List_Of_Quests() 
        {
            var quests = from q in db.Quests
                         select q;

            List<SelectListItem> items = new List<SelectListItem>();
            
            
foreach (var t in db.TypeOfQuest)
            {
                items.Add(new SelectListItem { Text = t.Title, Value = Convert.ToString(t.Id) });
            }
            
            ViewData["QuestTypes"] = items;
            
            return View(quests);
        }
        
        


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
