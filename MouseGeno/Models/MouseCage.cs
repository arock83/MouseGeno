using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class MouseCage
    {
        [Key]
        public int MouseCageID { get; set; }

        [Required]
        public int MouseID { get; set; }

        public Mouse Mouse { get; set; }

        [Required]
        public int CageID { get; set; }

        public Cage Cage { get; set; }
    }
}
