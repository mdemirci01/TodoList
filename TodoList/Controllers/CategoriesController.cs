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
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace TodoList.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            var category = new Category();
            return View(category);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreateDate = DateTime.Now;
                category.CreatedBy = User.Identity.Name;
                category.UpdateDate = DateTime.Now;
                category.UpdatedBy = User.Identity.Name;

                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.UpdateDate = DateTime.Now;
                category.UpdatedBy = User.Identity.Name;

                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void ExportToExcel()
        {
            var grid = new GridView();
            grid.DataSource = from data in db.Categories.ToList()
                              select new
                              {
                                  data.Name,
                                  data.CreateDate,
                                  data.CreatedBy,
                                  data.UpdateDate,
                                  data.UpdatedBy
                              };
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Kategori.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);
            grid.RenderControl(htmlTextWriter);
            Response.Write(sw.ToString());
            Response.End();
        }


        public void ExportToCsv()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("Kategori Adi,Olusturulma Tarihi,Olusturan Kullanici,Guncellenme Tarihi,Guncelleyen Kullanici");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Kategori.csv");
            Response.ContentType = "text/csv";
            var categori = db.Categories;
            foreach (var categories in categori)
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4}",

                    categories.Name,
                    categories.CreateDate,
                    categories.CreatedBy,
                    categories.UpdateDate,
                    categories.UpdatedBy
                    )
                    );
            }
            Response.Write(sw.ToString());
            Response.End();
        }

    }
}
