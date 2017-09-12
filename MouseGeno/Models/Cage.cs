using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class Cage
    {
        [Key]
        public int CageID { get; set; }

        [Required]
        [StringLength(8)]
        public string CageNumber { get; set; }

        [StringLength(3)]
        public string Cubicle { get; set; }

        [Required]
        public bool Breeding { get; set; }

        public virtual ICollection<MouseCage> MouseCages { get; set; }

        public virtual ICollection<CageCondition> CageConditions { get; set; }

    }
}
