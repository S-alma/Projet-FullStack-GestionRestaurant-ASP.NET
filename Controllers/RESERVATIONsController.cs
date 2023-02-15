using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionRestaurant.Models;

namespace GestionRestaurant.Controllers
{
    public class RESERVATIONsController : Controller
    {
        private BD_Gestion_restaurantEntities db = new BD_Gestion_restaurantEntities();

        // GET: RESERVATIONs
        public ActionResult Index()
        {
            var rESERVATIONs = db.RESERVATIONs.Include(r => r.TABLE_RESTAURANT).Include(r => r.UTILISATEUR);
            return View(rESERVATIONs.ToList());
        }

        // GET: RESERVATIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVATION rESERVATION = db.RESERVATIONs.Find(id);
            if (rESERVATION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVATION);
        }

        // GET: RESERVATIONs/Create
        public ActionResult Create()
        {
            ViewBag.Id_table = new SelectList(db.TABLE_RESTAURANT, "Id_table", "Id_table");
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur");
            return View();
        }

        // POST: RESERVATIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_reservation,Date_reservation,Id_utilisateur,Id_table")] RESERVATION rESERVATION)
        {
            if (ModelState.IsValid)
            {
                db.RESERVATIONs.Add(rESERVATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_table = new SelectList(db.TABLE_RESTAURANT, "Id_table", "Id_table", rESERVATION.Id_table);
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", rESERVATION.Id_utilisateur);
            return View(rESERVATION);
        }

        // GET: RESERVATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVATION rESERVATION = db.RESERVATIONs.Find(id);
            if (rESERVATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_table = new SelectList(db.TABLE_RESTAURANT, "Id_table", "Id_table", rESERVATION.Id_table);
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", rESERVATION.Id_utilisateur);
            return View(rESERVATION);
        }

        // POST: RESERVATIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_reservation,Date_reservation,Id_utilisateur,Id_table")] RESERVATION rESERVATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_table = new SelectList(db.TABLE_RESTAURANT, "Id_table", "Id_table", rESERVATION.Id_table);
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", rESERVATION.Id_utilisateur);
            return View(rESERVATION);
        }

        // GET: RESERVATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVATION rESERVATION = db.RESERVATIONs.Find(id);
            if (rESERVATION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVATION);
        }

        // POST: RESERVATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESERVATION rESERVATION = db.RESERVATIONs.Find(id);
            db.RESERVATIONs.Remove(rESERVATION);
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
    }
}
