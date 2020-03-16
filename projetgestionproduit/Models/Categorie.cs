using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projetgestionproduit.Models
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public int CategorieID { get; set; }
        [StringLength(30)]
        [Required, MinLength(4)]
        public string NomCategorie { get; set; }
        public virtual ICollection<Produit> produits { get; set; }

    }
}