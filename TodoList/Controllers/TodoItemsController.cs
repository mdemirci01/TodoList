using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace TodoList.Controllers
{
    public class TodoItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TodoItems
        public async Task<ActionResult> Index()
        {
            var todoItems = db.TodoItems.Include(t => t.Category).Include(t => t.Customer).Include(t => t.Department).Include(t => t.Manager).Include(t => t.Organizator).Include(t => t.Side);
            return View(await todoItems.ToListAsync());
        }

        // GET: TodoItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }

        // GET: TodoItems/Create
        public ActionResult Create()
        {
            var todoitem = new TodoItem();
            todoitem.MeetingDate = DateTime.Now;
            todoitem.FinishDate = DateTime.Now;
            todoitem.PlannedDate = DateTime.Now;
            todoitem.ReviseDate = DateTime.Now;
            todoitem.ScheduledOrganizationDate = DateTime.Now;
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName");
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName");
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name");
            return View(todoitem);
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MailingSubjects,PosterSubject,PosterCount,Elearning,TypesOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganizations,TypesOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmountOfCompensationForPoster,CorporateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.CreateDate = DateTime.Now;
                todoItem.CreatedBy = User.Identity.Name;
                todoItem.UpdateDate = DateTime.Now;
                todoItem.UpdatedBy = User.Identity.Name;
                db.TodoItems.Add(todoItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", todoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName", todoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoItem.SideId);
            return View(todoItem);
        }

        // GET: TodoItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", todoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName", todoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoItem.SideId);
            return View(todoItem);
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MailingSubjects,PosterSubject,PosterCount,Elearning,TypesOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganizations,TypesOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmountOfCompensationForPoster,CorporateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.UpdateDate = DateTime.Now;
                todoItem.UpdatedBy = User.Identity.Name;
                db.Entry(todoItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", todoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName", todoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoItem.SideId);
            return View(todoItem);
        }

        // GET: TodoItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            db.TodoItems.Remove(todoItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> ExportToExcel()
        {
            return View(await db.TodoItems.ToListAsync());
        }
        public void ExportToCsv()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("Başlık-Açıklama-Kategori-Durum-Toplantı Tarihi-Planlanan Tarih-Bitirilme Tarihi-Revize Tarihi-Görüşme Konusu-Destekleyen Firma-Destekleyen Hekim-Görüşme Katılımcı Sayısı-Planlanan Organizasyon Tarihi-Mail Konuları-Afiş Konusu-Afiş Sayısı-Elearning-Yapılan Taramaların Türleri-Yapılan Taramalardaki Aso Sayısı-Organizasyon Türleri-Organizasyondaki Aso Sayısı-Aşı Organizasyon Türleri-Aşı Organizasyonundaki ASO Sayısı-Afiş İçin Tazminat Miktari-Kurumsal Verimlilik Raporu-Olusturulma Tarihi-Olusturan Kullanici-Guncellenme Tarihi-Guncelleyen Kullanici");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Departman.csv");
            Response.ContentType = "text/csv";
            var todoitem = db.TodoItems;
            foreach (var todoitems in todoitem)
            {
                sw.WriteLine(string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-{13}-{14}-{15}-{16}-{17}-{18}-{19}-{20}-{21}-{22}-{23}-{24}-{25}-{26}-{27}",

                    todoitems.Title,
                    todoitems.Description,
                    todoitems.Status,                 
                    todoitems.MeetingDate,
                    todoitems.PlannedDate,
                    todoitems.FinishDate,
                    todoitems.ReviseDate,
                    todoitems.ConversationSubject,
                    todoitems.SupporterCompany,
                    todoitems.SupporterDoctor,
                    todoitems.ConversationAttendeeCount,
                    todoitems.ScheduledOrganizationDate,
                    todoitems.MailingSubjects,
                    todoitems.PosterSubject,
                    todoitems.PosterCount,
                    todoitems.Elearning,
                    todoitems.TypesOfScans,
                    todoitems.AsoCountInScans,
                    todoitems.TypesOfOrganization,
                    todoitems.AsoCountInOrganizations,
                    todoitems.TypesOfVaccinationOrganization,
                    todoitems.AsoCountInVaccinationOrganization,
                    todoitems.AmountOfCompensationForPoster,
                    todoitems.CorporateProductivityReport,
                    todoitems.CreateDate,
                    todoitems.CreatedBy,
                    todoitems.UpdateDate,
                    todoitems.UpdatedBy
                    )
                    );
            }
            Response.Write(sw.ToString());
            Response.End();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
