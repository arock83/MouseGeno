using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class GeneExpression
    {
        [Key]
        public int GeneExpressionID { get; set; }

        [Required]
        [StringLength(18)]
        public string FullName { get; set; }

        [Required]
        [StringLength(10)]
        public string ShortHand { get; set; }

        [InverseProperty("PK1")]
        public virtual ICollection<Mouse> PK1GenoTypes { get; set; }

        [InverseProperty("PK2")]
        public virtual ICollection<Mouse> PK2GenoTypes { get; set; }
    }
}
