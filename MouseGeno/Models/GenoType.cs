using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class GenoType
    {
        [Key]
        public int GenoTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortHand { get; set; }

        public virtual ICollection<Mouse> Mice { get; set; }

        public virtual ICollection<LineGenoType> LineGenoTypes { get; set; }

    }
}
