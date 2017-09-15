using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public int LineID { get; set; }

        public Line Line { get; set; }

        [Required]
        [StringLength(155)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
