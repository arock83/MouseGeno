using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class Condition
    {
        [Key]
        public int ConditionID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(155)]
        public string Instructions { get; set; }

        public virtual ICollection<CageCondition> CageConditions { get; set; }

    }
}
