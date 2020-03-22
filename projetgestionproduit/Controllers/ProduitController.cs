using projetgestionproduit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetgestionproduit.Controllers
{
    public class ProduitController : Controller
    {
        public Context context = new Context();
        public ProduitController()
        {
        }
        public ProduitController(Context db)
        {
            this.context = db;
        }
        // GET: Produit
        public ActionResult Produits(int page=0,int size= 5,string motCle="")
        {
            int position = page * size;
            IEnumerable<Produit> produits = 
                                                context
                                                .Produits
                                                .Where(p=>p.Designation.Contains(motCle))
                                                .OrderBy(p => p.ProduitID)
                                                .Skip(position)
                                                .Take(size)
                                                .ToList();
            ViewBag.currentPage = page;
            int nbrProduit = context.Produits.Where(p => p.Designation.Contains(motCle)).ToList().Count;
            int totalPages;
            if ((nbrProduit % size) == 0)
            {
                 totalPages = nbrProduit / size;
            }
            else
            {
                totalPages = 1+ (nbrProduit / size);
            }
            ViewBag.motCle = motCle;
            ViewBag.totalPages = totalPages;
            return View("Produits",produits);
        }

        public ActionResult FormProduit()
        {
            Produit p = new Produit();
            //ViewBag.categories = context.Categories.ToList();
            var categories = context.Categories.Select(c => new {
                CategorieID = c.CategorieID,
                NomCategorie = c.NomCategorie
            }).ToList();
            ViewBag.Categories = new SelectList(categories, "CategorieID", "NomCategorie");
            return View("FormProduit",p);
        }
        [HttpPost]
        public ActionResult SaveProduit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                if(!context.Produits.Any(p=>p.Designation == produit.Designation && p.Prix == produit.Prix && p.Quantite == produit.Quantite && p.CategorieID ==produit.CategorieID))
                {
                    context.Produits.Add(produit);
                    context.SaveChanges();
                    TempData["message"] = produit.Designation + " has been saved";
                    return RedirectToAction("Produits");
                }
               else
                {
                    TempData["message"] = produit.Designation + " is already existing";
                }
            }
            var categories = context.Categories.Select(c => new {
                CategorieID = c.CategorieID,
                NomCategorie = c.NomCategorie
            }).ToList();
            ViewBag.Categories = new SelectList(categories, "CategorieID", "NomCategorie");
            return View("FormProduit", produit);
        }

        public ActionResult EditerProduit(int ProduitID)
        {
            Produit produit = context.Produits.Where(p => p.ProduitID == ProduitID).FirstOrDefault();

            //ViewBag.categories = context.Categories.ToList();
            var categories = context.Categories.Select(c => new {
                CategorieID = c.CategorieID,
                NomCategorie = c.NomCategorie
            }).ToList();
            ViewBag.Categories = new SelectList(categories, "CategorieID", "NomCategorie");
            return View("EditerProduit", produit);
        }
        [HttpPost]
        public ActionResult EditerProduit(Produit produit)
        {
            var categories = context.Categories.Select(c => new {
                CategorieID = c.CategorieID,
                NomCategorie = c.NomCategorie
            }).ToList();
            ViewBag.Categories = new SelectList(categories, "CategorieID", "NomCategorie");
            if (ModelState.IsValid)
            {

                Produit prod = context.Produits.Where(p => p.ProduitID == produit.ProduitID).FirstOrDefault();
                prod.Designation = produit.Designation;
                prod.Quantite = produit.Quantite;
                prod.Prix = produit.Prix;
                prod.CategorieID = produit.CategorieID;
                context.SaveChanges();
                TempData["message"] = produit.Designation + " has been saved";
                return RedirectToAction("Produits");
            }

            return View("EditerProduit", produit);
        }
        public ActionResult DeleteProduit(int ProduitID)
        {
            Produit produit = context.Produits.Where(p => p.ProduitID == ProduitID).FirstOrDefault();
            context.Produits.Remove(produit);
            context.SaveChanges();
            
            IEnumerable<Produit> newlist =
                                               context
                                               .Produits
                                               .Where(p => p.Designation.Contains(""))
                                               .OrderBy(p => p.ProduitID)
                                               .Skip(0)
                                               .Take(5)
                                               .ToList();


            Produits(0, 5, "");
            return View("Produits",newlist);

        }
    }
}