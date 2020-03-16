using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projetgestionproduit.Models
{
    [Table("Mortality")]
    public class Mortality
    {
        [Key]
        public int MortalityId { get; set; }
        public int Year { get; set; }
        public int Age { get; set; }
        public decimal SmokerValue { get; set; }
        public decimal NonSmokerValue { get; set; }
        public decimal SmokerValueHic1 { get; set; }
        public decimal NonSmokerValueHic1 { get; set; }
    }
}