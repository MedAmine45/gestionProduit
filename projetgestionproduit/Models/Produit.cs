using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projetgestionproduit.Models
{
    [Table("Produit")]
    public class Produit
    {
        [Key]
        public int ProduitID { get; set; }
        [StringLength(70)]
        [Required]
        [MinLength(4),MaxLength(70)]
        public string Designation { get; set; }
        [Range(10,5000000)]
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public int CategorieID { get; set; }
        public virtual Categorie Categorie { get; set; }

    }
}