using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class LineGenoType
    {
        [Key]
        public int LineGenoTypeID { get; set; }

        [Required]
        public int LineID { get; set; }

        public virtual Line Line { get; set; }

        [Required]
        public int GenoTypeID { get; set; }

        public virtual GenoType GenoType { get; set; }
    }
}
