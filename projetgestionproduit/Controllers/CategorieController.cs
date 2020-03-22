using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projetgestionproduit.Models;

namespace projetgestionproduit.Controllers
{
    public class CategorieController : Controller
    {
        public Context context = new Context();
        public CategorieController()
        {
        }
        public CategorieController(Context db)
        {
            this.context = db;
        }

        // GET: Categorie
        public ActionResult Categories(int page = 0, int size = 5, string motCle = "")
        {
            int position = page * size;
            IEnumerable<Categorie> categories =
                                                context
                                                .Categories
                                                .Where(c => c.NomCategorie.Contains(motCle))
                                                .OrderBy(c => c.CategorieID)
                                                .Skip(position)
                                                .Take(size)
                                                .ToList();
            ViewBag.currentPage = page;
            int nbrCategorie = context.Categories.Where(c => c.NomCategorie.Contains(motCle)).ToList().Count;
            int totalPages;
            if ((nbrCategorie % size) == 0)
            {
                totalPages = nbrCategorie / size;
            }
            else
            {
                totalPages = 1 + (nbrCategorie / size);
            }
            ViewBag.motCle = motCle;
            ViewBag.totalPages = totalPages;
            return View("Categories", categories);
        }

        public ActionResult FormCategorie()
        {
            Categorie c = new Categorie();
            return View("FormCategorie", c);
        }
        [HttpPost]
        public ActionResult SaveCategorie(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                if (!context.Categories.Any(c => c.NomCategorie == categorie.NomCategorie ))
                {
                    context.Categories.Add(categorie);
                    context.SaveChanges();
                    TempData["message"] = categorie.NomCategorie + " has been saved";
                    return RedirectToAction("Categories");
                }
                else
                {
                    TempData["message"] = categorie.NomCategorie + " is already existing";
                }
            }
            return View("FormCategorie", categorie);
        }

        public ActionResult DeleteCategorie(int CategorieID)
        {
            Categorie categorie = context.Categories.FirstOrDefault(c => c.CategorieID == CategorieID);
            if (categorie != null)
            {
                context.Categories.Remove(categorie);
                context.SaveChanges();
            }
            IEnumerable<Categorie> categorieUpdate = context.Categories.ToList();
            IEnumerable<Categorie> newlist =
                                                         context
                                                          .Categories
                                                            .Where(c => c.NomCategorie.Contains(""))
                                                         .OrderBy(c => c.CategorieID)
                                                            .Skip(0)
                                                            .Take(5)
                                                            .ToList();

            return View("Categories", newlist);
        }

        public ActionResult EditerCategorie(int CategorieID)
        {
            Categorie categorie = context.Categories.FirstOrDefault(c => c.CategorieID == CategorieID);
            return View("EditerCategorie", categorie);
        }
        [HttpPost]
        public ActionResult EditerCategorie(Categorie categorie)
        {
            Categorie cat = context.Categories.Where(c => c.CategorieID == categorie.CategorieID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                cat.NomCategorie = categorie.NomCategorie;
                context.SaveChanges();
                TempData["message"] = cat.NomCategorie + " has been saved";
                return RedirectToAction("Categories");
            }

            return View("EditerCategorie", cat);
        }

        public ActionResult DetailsCategorie(int CategorieID)
        {
            Categorie categorie = context.Categories.FirstOrDefault(c => c.CategorieID == CategorieID);
            return View("DetailsCategorie", categorie);
        }


    }
}