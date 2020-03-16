using projetgestionproduit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new Context())
            {
            //    db.Categories.Add(
            //        new Categorie { NomCategorie = "Ordinateurs" }
            //        );
            //    db.Categories.Add(
            //        new Categorie { NomCategorie = "Smartphones" }
            //        );
            //    db.Categories.Add(
            //      new Categorie { NomCategorie = "Imprimantes" }
            //      );
                db.Produits.Add(
                  new Produit { Designation = "Hp 65 90" ,Prix = 7800,Quantite = 6, CategorieID = 1}
                  );
                db.Produits.Add(
                new Produit { Designation = "Sumsung Galxy S6", Prix = 5000, Quantite = 12, CategorieID = 2 }
                );
                db.Produits.Add(
               new Produit { Designation = "Node Book Pro", Prix = 7600, Quantite = 11, CategorieID = 1 }
               );
                db.Produits.Add(
                new Produit { Designation = "Epson", Prix = 1200, Quantite = 6, CategorieID = 3 }
                );
                db.SaveChanges();
            }
        }
    }
}
