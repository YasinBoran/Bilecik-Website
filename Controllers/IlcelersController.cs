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
    public class IlcelersController : Controller
    {
        private IlcelerEntities db = new IlcelerEntities();

        // GET: Ilcelers
        public ActionResult Index()
        {
            return View(db.Ilcelers.ToList());
        }

        // GET: Ilcelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilceler ilceler = db.Ilcelers.Find(id);
            if (ilceler == null)
            {
                return HttpNotFound();
            }
            return View(ilceler);
        }

        // GET: Ilcelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ilcelers/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ilce")] Ilceler ilceler)
        {
            if (ModelState.IsValid)
            {
                db.Ilcelers.Add(ilceler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilceler);
        }

        // GET: Ilcelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilceler ilceler = db.Ilcelers.Find(id);
            if (ilceler == null)
            {
                return HttpNotFound();
            }
            return View(ilceler);
        }

        // POST: Ilcelers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ilce")] Ilceler ilceler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilceler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilceler);
        }

        // GET: Ilcelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilceler ilceler = db.Ilcelers.Find(id);
            if (ilceler == null)
            {
                return HttpNotFound();
            }
            return View(ilceler);
        }

        // POST: Ilcelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilceler ilceler = db.Ilcelers.Find(id);
            db.Ilcelers.Remove(ilceler);
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
        public ActionResult Ilceler()
        {
            var nufuslar =db.Ilcelers.ToList();
            return View(nufuslar);
        }
    }
}
