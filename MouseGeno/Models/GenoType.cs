using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class GenoType
    {
        [Key]
        public int GenoTypeID { get; set; }

        [Required]
        public int PK1ID { get; set; }

        [NotMapped]
        public GeneExpression PK1 { get; set; }

        [Required]
        public int PK2ID { get; set; }

        [NotMapped]
        public GeneExpression PK2 { get; set; }

        [Required]
        public bool SynCre { get; set; }

        [StringLength(155)]
        public string Comments { get; set; }

        public virtual ICollection<Mouse> Mice { get; set; }

    }
}
