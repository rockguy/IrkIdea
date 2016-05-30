using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Queste.Models;
using System.Data;
using System.IO;


namespace Queste.Controllers
{
    public class HomeController : Controller
    {
        
        UserContext db = new UserContext();

        public IQueryable<TypeOfQuest> GetTypes() { 
            return from t in db.TypeOfQuest
                            select t;
        }
               
        public ActionResult Index()
        {           
            ViewBag.Name = HttpContext.User.Identity.Name;
            ViewBag.Decription = System.IO.File.ReadAllLines(Server.MapPath("\\Content\\Text\\HelloGuest.txt"));
            ViewData["Types"] = GetTypes();

       
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult New_Quest()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var t in db.TypeOfQuest)
            {
                items.Add(new SelectListItem { Text = t.Title});
            }

            ViewData["QuestTypes"] = items;
            return View();
        }
        
        [HttpPost]
        public ActionResult New_Quest(Quest quest)
        {
            quest.Owner = HttpContext.User.Identity.Name;
            quest.DateOfCreation = DateTime.Now;
            db.Entry(quest).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        
        [HttpGet]
        public ActionResult List_Of_Quests() 
        {
            var  quests = from q in db.Quests
                             select q;
            return View(quests);
        }

        [HttpGet]
        public ActionResult List_Of_Quests2(string Condition) 
        {
            var   quests = from q in db.Quests
                             where q.Type==Condition.ToString()
                             select q;
            List<SelectListItem> items = new List<SelectListItem>();
                        
            foreach (var t in db.TypeOfQuest)
            {
                items.Add(new SelectListItem { Text = t.Title, Value = Convert.ToString(t.Id) });
            }
            
            ViewData["QuestTypes"] = items;
            
            return View(quests);
        }

        public ActionResult Quest_Detail(int? id) 
        {
            IQueryable<Quest> qu = from q in db.Quests
                          where q.Id == id
                          select q;
            Quest quest = qu.First();
            return View(quest);
        }
        
        public ActionResult Check_Answear(Quest quest )
        {
            var TrueQuest = from q in db.Quests
                            where q.Id == quest.Id
                            select q.Answear;
            if (TrueQuest.First() == quest.Answear)
            {
                ViewBag.Message = "Отличная работа!";
                return View("TrueAnswear");
            }
            else {
                ViewBag.Message = "Вы ошиблись... Попробуйте снова ;-)";
                return Redirect("FalseAnswear"); 
            }
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
