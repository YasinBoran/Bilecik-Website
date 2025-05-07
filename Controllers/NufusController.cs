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
    public class NufusController : Controller
    {
        private NufuslarEntities1 db = new NufuslarEntities1();

        // GET: Nufus
        public ActionResult Index()
        {
            return View(db.Nufus.ToList());
        }

        // GET: Nufus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nufus nufus = db.Nufus.Find(id);
            if (nufus == null)
            {
                return HttpNotFound();
            }
            return View(nufus);
        }

        // GET: Nufus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nufus/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Yil,Bozuyuk,Golpazari,Inhisar,Merkez,Osmaneli,Pazaryeri,Sogut,Yenipazar")] Nufus nufus)
        {
            if (ModelState.IsValid)
            {
                db.Nufus.Add(nufus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nufus);
        }

        // GET: Nufus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nufus nufus = db.Nufus.Find(id);
            if (nufus == null)
            {
                return HttpNotFound();
            }
            return View(nufus);
        }

        // POST: Nufus/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Yil,Bozuyuk,Golpazari,Inhisar,Merkez,Osmaneli,Pazaryeri,Sogut,Yenipazar")] Nufus nufus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nufus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nufus);
        }

        // GET: Nufus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nufus nufus = db.Nufus.Find(id);
            if (nufus == null)
            {
                return HttpNotFound();
            }
            return View(nufus);
        }

        // POST: Nufus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nufus nufus = db.Nufus.Find(id);
            db.Nufus.Remove(nufus);
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
        public ActionResult NufusDagilimi()
        {   
            var nufuslar = db.Nufus.ToList();
            return View(nufuslar);
        }
    }
}
