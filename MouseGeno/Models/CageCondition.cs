using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class CageCondition
    {
        [Key]
        public int CageConditionID { get; set; }

        [Required]
        public int CageID { get; set; }

        public virtual Cage Cage { get; set; }

        [Required]
        public int ConditionID { get; set; }

        public virtual Condition Condition { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ApplicationUser User {get; set;}

        public string Comments { get; set; }


    }
}
