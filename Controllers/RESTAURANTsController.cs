using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GestionRestaurant.Models;

namespace GestionRestaurant.Controllers
{
    public class RESTAURANTsController : Controller
    {
        private BD_Gestion_restaurantEntities db = new BD_Gestion_restaurantEntities();

        // GET: RESTAURANTs
        public ActionResult Index()
        {
            var rESTAURANTs = db.RESTAURANTs.Include(r => r.UTILISATEUR);
            return View(rESTAURANTs.ToList());
        }

        // GET: RESTAURANTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANT rESTAURANT = db.RESTAURANTs.Find(id);
            if (rESTAURANT == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANT);
        }

        // GET: RESTAURANTs/Create
        public ActionResult Create()
        {
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur");
            return View();
        }

        // POST: RESTAURANTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_restaurant,Nom_restaurant,Adresse_restaurant,Nombre_etoile,Nombre_table,Id_utilisateur,Telephone,Image_restaurant,Description")] RESTAURANT rESTAURANT)
        {
            if (ModelState.IsValid)
            {
                WebImage image;
                var fileName = "";
                var imagePath = "";

                image = WebImage.GetImageFromRequest();
                if (image != null)
                {
                    fileName = Guid.NewGuid().ToString() + "_" +
                        Path.GetFileName(image.FileName);
                    imagePath = @"\Image\" + fileName;

                    image.Save(@"~" + imagePath);

                    rESTAURANT.Image_restaurant = imagePath;
                }

                db.RESTAURANTs.Add(rESTAURANT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", rESTAURANT.Id_utilisateur);
            return View(rESTAURANT);
        }

        // GET: RESTAURANTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANT rESTAURANT = db.RESTAURANTs.Find(id);
            if (rESTAURANT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", rESTAURANT.Id_utilisateur);
            return View(rESTAURANT);
        }

        // POST: RESTAURANTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_restaurant,Nom_restaurant,Adresse_restaurant,Nombre_etoile,Nombre_table,Id_utilisateur,Telephone,Image_restaurant,Description")] RESTAURANT rESTAURANT)
        {
            if (ModelState.IsValid)
            {
                WebImage image;
                var fileName = "";
                var imagePath = "";

                image = WebImage.GetImageFromRequest();
                if (image != null)
                {
                    fileName = Guid.NewGuid().ToString() + "_" +
                        Path.GetFileName(image.FileName);
                    imagePath = @"\Image\" + fileName;

                    image.Save(@"~" + imagePath);

                    rESTAURANT.Image_restaurant = imagePath;
                }

                db.Entry(rESTAURANT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_utilisateur = new SelectList(db.UTILISATEURs, "Id_utilisateur", "Nom_utilisateur", rESTAURANT.Id_utilisateur);
            return View(rESTAURANT);
        }

        // GET: RESTAURANTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANT rESTAURANT = db.RESTAURANTs.Find(id);
            if (rESTAURANT == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANT);
        }

        // POST: RESTAURANTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESTAURANT rESTAURANT = db.RESTAURANTs.Find(id);
            db.RESTAURANTs.Remove(rESTAURANT);
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
