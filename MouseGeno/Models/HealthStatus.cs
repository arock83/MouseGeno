using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class HealthStatus
    {
        [Key]
        public int HealthStatusID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(155)]
        public string Description { get; set; }
    }
}
