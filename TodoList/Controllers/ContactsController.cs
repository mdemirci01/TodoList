﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;

namespace TodoList.Controllers
{
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            return View(await db.Contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            var contact = new Contact();
            return View(contact);
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email,Phone,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreateDate = DateTime.Now;
                contact.CreatedBy = User.Identity.Name;
                contact.UpdateDate = DateTime.Now;
                contact.UpdatedBy = User.Identity.Name;
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Email,Phone,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.UpdateDate = DateTime.Now;
                contact.UpdatedBy = User.Identity.Name;
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contact contact = await db.Contacts.FindAsync(id);
            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public void ExportToExcel()
        {
            var grid = new GridView();
            grid.DataSource = from data in db.Contacts.ToList()
                              select new
                              {
                                  Ad = data.FirstName,
                                  Soyad = data.LastName,
                                  Email = data.Email,
                                  Telefon = data.Phone,
                                  OlusturulmaTarihi = data.CreateDate,
                                  OlusturanKullanici = data.CreatedBy,
                                  GuncellenmeTarihi = data.UpdateDate,
                                  GuncelleyenKullanici = data.UpdatedBy
                              };
            grid.DataBind();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Test.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

            grid.RenderControl(hw);

            Response.Write(sw.ToString());
            Response.End();
        }


        public void ExportToCsv()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("Ad,Soyad,Email,Telefon,Olusturulma Tarihi,Olusturan Kullanici,Guncellenme Tarihi,Guncelleyen Kullanici");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Kişi.csv");
            Response.ContentType = "text/csv";
            var contact = db.Contacts;
            foreach (var Contact in contact)
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                    Contact.FirstName,
                    Contact.LastName,
                    Contact.Email,
                    Contact.Phone,
                    Contact.CreateDate,
                    Contact.CreatedBy,
                    Contact.UpdateDate,
                    Contact.UpdatedBy
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
