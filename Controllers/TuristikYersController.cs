using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proje.Models;

namespace Proje.Controllers
{
    public class TuristikYersController : Controller
    {
        private TuristikYerEntities db = new TuristikYerEntities();

        // GET: TuristikYers
        public ActionResult Index()
        {
            return View(db.TuristikYers.ToList());
        }

        // GET: TuristikYers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuristikYer turistikYer = db.TuristikYers.Find(id);
            if (turistikYer == null)
            {
                return HttpNotFound();
            }
            return View(turistikYer);
        }

        // GET: TuristikYers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TuristikYers/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TuristikYer1,Aciklama")] TuristikYer turistikYer)
        {
            if (ModelState.IsValid)
            {
                db.TuristikYers.Add(turistikYer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turistikYer);
        }

        // GET: TuristikYers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuristikYer turistikYer = db.TuristikYers.Find(id);
            if (turistikYer == null)
            {
                return HttpNotFound();
            }
            return View(turistikYer);
        }

        // POST: TuristikYers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TuristikYer1,Aciklama")] TuristikYer turistikYer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turistikYer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turistikYer);
        }

        // GET: TuristikYers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuristikYer turistikYer = db.TuristikYers.Find(id);
            if (turistikYer == null)
            {
                return HttpNotFound();
            }
            return View(turistikYer);
        }

        // POST: TuristikYers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuristikYer turistikYer = db.TuristikYers.Find(id);
            db.TuristikYers.Remove(turistikYer);
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
        public ActionResult TuristikYerler()
        {
            var yer = db.TuristikYers.ToList();
            return View(yer);
        }
    }
}
