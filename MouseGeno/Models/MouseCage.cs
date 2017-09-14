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

        public virtual Mouse Mouse { get; set; }

        [Required]
        public int CageID { get; set; }

        public virtual Cage Cage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
