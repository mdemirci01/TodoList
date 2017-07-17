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
using System.IO;

namespace TodoList.Controllers
{
    public class MediaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Media
        public async Task<ActionResult> Index()
        {
            return View(await db.Medias.ToListAsync());
        }

        // GET: Media/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = await db.Medias.FindAsync(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            return View(media);
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            var media = new Media();
            return View(media);
        }

        // POST: Media/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Extension,FilePath,FileSize,Year,Month,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Media media)
        {
            if (ModelState.IsValid)
            {
                media.CreateDate = DateTime.Now;
                media.CreatedBy = User.Identity.Name;
                media.UpdateDate = DateTime.Now;
                media.UpdatedBy = User.Identity.Name;
                db.Medias.Add(media);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = await db.Medias.FindAsync(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            return View(media);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Extension,FilePath,FileSize,Year,Month,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Media media)
        {
            if (ModelState.IsValid)
            {
                media.UpdateDate = DateTime.Now;
                media.UpdatedBy = User.Identity.Name;

                db.Entry(media).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(media);
        }

        // GET: Media/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = await db.Medias.FindAsync(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Media media = await db.Medias.FindAsync(id);
            db.Medias.Remove(media);
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
        public async Task<ActionResult> ExportToExcel()
        {
            return View(await db.Medias.ToListAsync());
        }

        public void ExportToCsv()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("Medya Adi-Aciklama-Uzanti-Dosya Yolu-Dosya Boyutu-Yıl-Ay-Olusturulma Tarihi-Olusturan Kullanici-Guncellenme Tarihi-Guncelleyen Kullanici");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Medya.csv");
            Response.ContentType = "text/csv";
            var medya = db.Medias;
            foreach (var medias in medya)
            {
                sw.WriteLine(string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}",

                    medias.Name,
                    medias.Description,
                    medias.Extension,
                    medias.FilePath,
                    medias.FileSize,
                    medias.Year,
                    medias.Month,
                    medias.CreateDate,
                    medias.CreatedBy,
                    medias.UpdateDate,
                    medias.UpdatedBy
                    )
                    );
            }
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
