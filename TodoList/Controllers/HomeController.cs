using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kurumsal()
        {
            var department = new Department();
            department.Name = "Pazarlama";
            return View(department);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var contact = new Contact();
            return View(contact);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    contact.CreateDate = DateTime.Now;
                    contact.UpdateDate = DateTime.Now;
                    contact.CreatedBy = User.Identity.Name;
                    contact.UpdatedBy = User.Identity.Name;
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(contact);
        }
    }
}