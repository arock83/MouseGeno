using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class Cage
    {
        [Key]
        public int CageID { get; set; }

        [Required]
        
        public string CageNumber { get; set; }

        [Required]
        public string WaterSupply { get; set; }

        [Required]
        public string FoodSupply { get; set; }

        public virtual ICollection<MouseCage> MouseCages { get; set; }

        public virtual ICollection<CageCondition> CageConditions {get; set;}


    }
}
