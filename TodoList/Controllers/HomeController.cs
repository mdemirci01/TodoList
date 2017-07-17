using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.CustomerCount = db.Customers.Count();
            ViewBag.StatusNewCount = db.TodoItems.Where(t => t.Status==Status.New).Count();
            ViewBag.StatusWaitingCount = db.TodoItems.Where(t => t.Status == Status.Waiting).Count();
            ViewBag.StatusCompletedCount = db.TodoItems.Where(t => t.Status == Status.New).Count();

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
                    Session["StatusMessage"] = "Kişi formu başarıyla kaydedildi";
                    return RedirectToAction("Index");
                }

            }
            return View(contact);
        }
    }
}