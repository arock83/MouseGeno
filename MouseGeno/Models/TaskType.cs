using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class TaskType
    {
        [Key]
        public int TaskTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructions { get; set; }

        public string MeasurementType { get; set; }


    }
}
