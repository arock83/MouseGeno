using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class MouseTask
    {
        [Key]
        public int MouseTaskID { get; set; }

        [Required]
        public int TaskTypeID { get; set; }

        public virtual TaskType TaskType { get; set; }

        [Required]
        public int MouseID { get; set; }

        public virtual Mouse Mouse { get; set; }

        public ApplicationUser User { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Data { get; set; }

        public string Comments { get; set; }
    }
}
