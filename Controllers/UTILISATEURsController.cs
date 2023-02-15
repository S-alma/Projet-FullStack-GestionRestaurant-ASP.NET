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
    public class UTILISATEURsController : Controller
    {
        private BD_Gestion_restaurantEntities db = new BD_Gestion_restaurantEntities();

        // GET: UTILISATEURs
        public ActionResult Index()
        {
            return View(db.UTILISATEURs.ToList());
        }

        // GET: UTILISATEURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEURs.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UTILISATEURs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_utilisateur,Nom_utilisateur,Prenom_utilisateur,Adresse_mail,Mot_de_passe,Type_utilisateur")] UTILISATEUR uTILISATEUR)
        {
            if (ModelState.IsValid)
            {
                db.UTILISATEURs.Add(uTILISATEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEURs.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // POST: UTILISATEURs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_utilisateur,Nom_utilisateur,Prenom_utilisateur,Adresse_mail,Mot_de_passe,Type_utilisateur")] UTILISATEUR uTILISATEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uTILISATEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEURs.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // POST: UTILISATEURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UTILISATEUR uTILISATEUR = db.UTILISATEURs.Find(id);
            db.UTILISATEURs.Remove(uTILISATEUR);
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
