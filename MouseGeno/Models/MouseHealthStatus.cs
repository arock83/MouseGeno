using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class MouseHealthStatus
    {
        [Key]
        public int MouseHealthStatusID { get; set; }

        [Required]
        public int MouseID { get; set; }

        public virtual Mouse Mouse { get; set; }

        [Required]
        public int HealthStatusID { get; set; }

        public virtual HealthStatus HealthStatus { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public ApplicationUser User { get; set; }

    }
}
