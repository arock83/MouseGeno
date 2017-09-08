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

        public Cage Cage { get; set; }

        [Required]
        public int ConditionID { get; set; }

        public Condition Condition { get; set; }

        public DateTime Date { get; set; }

        public ApplicationUser User {get; set;}

        public string Comments { get; set; }


    }
}
