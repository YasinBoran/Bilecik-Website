using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proje.Models;

namespace Proje.Controllers
{
    public class ResimlersController : Controller
    {
        private ResimlerEntities1 db = new ResimlerEntities1();

        // GET: Resimlers
        public ActionResult Index()
        {
            return View(db.Resimlers.ToList());
        }

        // GET: Resimlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resimler resimler = db.Resimlers.Find(id);
            if (resimler == null)
            {
                return HttpNotFound();
            }
            return View(resimler);
        }

        // GET: Resimlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resimlers/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase resimler)
        {
            if (resimler != null)
            {
                string ImageFileName = Path.GetFileName(resimler.FileName);
                string FolderPath =
                Path.Combine(Server.MapPath("~/Content/resimler"),ImageFileName);
                resimler.SaveAs(FolderPath);
                Resimler rsm = new Resimler();
                rsm.Link = Path.GetFileName(resimler.FileName);
                db.Resimlers.Add(rsm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.msg = "Yüklemek istediğiniz resim bulunamadı.";
            return View(resimler);
        }

        // GET: Resimlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resimler resimler = db.Resimlers.Find(id);
            if (resimler == null)
            {
                return HttpNotFound();
            }
            return View(resimler);
        }

        // POST: Resimlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Link")] Resimler resimler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resimler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resimler);
        }

        // GET: Resimlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resimler resimler = db.Resimlers.Find(id);
            if (resimler == null)
            {
                return HttpNotFound();
            }
            return View(resimler);
        }

        // POST: Resimlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resimler resimler = db.Resimlers.Find(id);
            string ImageFileName = resimler.Link;
            string FolderPath =
            Path.Combine(Server.MapPath("~/Content/Resimler"),ImageFileName);
            if (System.IO.File.Exists(FolderPath))
            {
                System.IO.File.Delete(FolderPath);
            }

            db.Resimlers.Remove(resimler);
            db.SaveChanges();
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
        public ActionResult Anasayfa()
        {
            var resimliste = db.Resimlers.ToList();
            return View(resimliste);
        }
    }
}
