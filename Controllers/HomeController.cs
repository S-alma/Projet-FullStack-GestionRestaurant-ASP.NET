using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionRestaurant.Models;

namespace GestionRestaurant.Controllers
{
    public class HomeController : Controller
    {
        BD_Gestion_restaurantEntities db = new BD_Gestion_restaurantEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.UTILISATEURs.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(UTILISATEUR uTILISATEUR)
        {
            if (db.UTILISATEURs.Any(x => x.Nom_utilisateur == uTILISATEUR.Nom_utilisateur))
            {
                ViewBag.Notification = "Ce compte existe déja";
                return View();
            }
            else
            {
                db.UTILISATEURs.Add(uTILISATEUR);
                db.SaveChanges();
                Session["Id_utilisateurSS"] = uTILISATEUR.Id_utilisateur.ToString();
                Session["Nom_utilisateurSS"] = uTILISATEUR.Nom_utilisateur.ToString();
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UTILISATEUR uTILISATEUR)
        {
            var checklogin = db.UTILISATEURs.Where(x => x.Nom_utilisateur.Equals(uTILISATEUR.Nom_utilisateur) && x.Mot_de_passe.Equals(uTILISATEUR.Mot_de_passe)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["Id_utilisateurSS"] = uTILISATEUR.Id_utilisateur.ToString();
                Session["Nom_utilisateurSS"] = uTILISATEUR.Nom_utilisateur.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Nom d'utilisateur ou mot de passe incorrecte";
            }
            return View();
        }
    }
}