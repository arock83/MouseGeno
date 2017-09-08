using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class Line
    {
        [Key]
        public int LineID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(155)]
        public string Description { get; set; }

        public virtual ICollection<Mouse> Mice { get; set; }

        public virtual ICollection<LineGenoType> LineGenoTypes { get; set; }

    }
}
