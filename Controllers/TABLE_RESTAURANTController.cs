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
    public class TABLE_RESTAURANTController : Controller
    {
        private BD_Gestion_restaurantEntities db = new BD_Gestion_restaurantEntities();

        // GET: TABLE_RESTAURANT
        public ActionResult Index()
        {
            var tABLE_RESTAURANT = db.TABLE_RESTAURANT.Include(t => t.RESTAURANT);
            return View(tABLE_RESTAURANT.ToList());
        }

        // GET: TABLE_RESTAURANT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TABLE_RESTAURANT tABLE_RESTAURANT = db.TABLE_RESTAURANT.Find(id);
            if (tABLE_RESTAURANT == null)
            {
                return HttpNotFound();
            }
            return View(tABLE_RESTAURANT);
        }

        // GET: TABLE_RESTAURANT/Create
        public ActionResult Create()
        {
            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant");
            return View();
        }

        // POST: TABLE_RESTAURANT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_table,Disponibilite,Nombre_personne,Id_restaurant")] TABLE_RESTAURANT tABLE_RESTAURANT)
        {
            if (ModelState.IsValid)
            {
                db.TABLE_RESTAURANT.Add(tABLE_RESTAURANT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant", tABLE_RESTAURANT.Id_restaurant);
            return View(tABLE_RESTAURANT);
        }

        // GET: TABLE_RESTAURANT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TABLE_RESTAURANT tABLE_RESTAURANT = db.TABLE_RESTAURANT.Find(id);
            if (tABLE_RESTAURANT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant", tABLE_RESTAURANT.Id_restaurant);
            return View(tABLE_RESTAURANT);
        }

        // POST: TABLE_RESTAURANT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_table,Disponibilite,Nombre_personne,Id_restaurant")] TABLE_RESTAURANT tABLE_RESTAURANT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tABLE_RESTAURANT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_restaurant = new SelectList(db.RESTAURANTs, "Id_restaurant", "Nom_restaurant", tABLE_RESTAURANT.Id_restaurant);
            return View(tABLE_RESTAURANT);
        }

        // GET: TABLE_RESTAURANT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TABLE_RESTAURANT tABLE_RESTAURANT = db.TABLE_RESTAURANT.Find(id);
            if (tABLE_RESTAURANT == null)
            {
                return HttpNotFound();
            }
            return View(tABLE_RESTAURANT);
        }

        // POST: TABLE_RESTAURANT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TABLE_RESTAURANT tABLE_RESTAURANT = db.TABLE_RESTAURANT.Find(id);
            db.TABLE_RESTAURANT.Remove(tABLE_RESTAURANT);
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
