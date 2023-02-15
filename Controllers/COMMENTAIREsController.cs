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
    public class COMMENTAIREsController : Controller
    {
        private BD_Gestion_restaurantEntities db = new BD_Gestion_restaurantEntities();

        // GET: COMMENTAIREs
        public ActionResult Index()
        {
            var cOMMENTAIREs = db.COMMENTAIREs.Include(c => c.RESTAURANT).Include(c => c.UTILISATEUR);
            return View(cOMMENTAIREs.ToList());
        }

        // GET: COMMENTAIREs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIREs.Find(id);
            if (cOMMENTAIRE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENTAIRE);
        }

        // GET: COMMENTAIREs/Create
        public ActionResult Create()
        {
            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant");
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur");
            return View();
        }

        // POST: COMMENTAIREs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_commentaire,Type_commentaire,Date_commentaire,Commentaire1,Id_utilisateur,Id_restaurant")] COMMENTAIRE cOMMENTAIRE)
        {
            if (ModelState.IsValid)
            {
                db.COMMENTAIREs.Add(cOMMENTAIRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant", cOMMENTAIRE.Id_restaurant);
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", cOMMENTAIRE.Id_utilisateur);
            return View(cOMMENTAIRE);
        }

        // GET: COMMENTAIREs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIREs.Find(id);
            if (cOMMENTAIRE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant", cOMMENTAIRE.Id_restaurant);
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", cOMMENTAIRE.Id_utilisateur);
            return View(cOMMENTAIRE);
        }

        // POST: COMMENTAIREs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_commentaire,Type_commentaire,Date_commentaire,Commentaire1,Id_utilisateur,Id_restaurant")] COMMENTAIRE cOMMENTAIRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMENTAIRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant", cOMMENTAIRE.Id_restaurant);
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", cOMMENTAIRE.Id_utilisateur);
            return View(cOMMENTAIRE);
        }

        // GET: COMMENTAIREs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIREs.Find(id);
            if (cOMMENTAIRE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENTAIRE);
        }

        // POST: COMMENTAIREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIREs.Find(id);
            db.COMMENTAIREs.Remove(cOMMENTAIRE);
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
