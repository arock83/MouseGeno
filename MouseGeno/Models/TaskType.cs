﻿using System;
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
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(155)]
        public string Instructions { get; set; }

        [StringLength(8)]
        public string MeasurementType { get; set; }


    }
}
