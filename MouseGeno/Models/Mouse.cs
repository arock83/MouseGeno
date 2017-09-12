using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models
{
    public class Mouse
    {
        [Key]
        public int MouseID { get; set; }

        public string EarTag { get; set; }

        public string ToeClip { get; set; }

        [Required]
        public string Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [DataType(DataType.Date)]
        public DateTime Death { get; set; }

        [Required]
        public int LineID { get; set; }

        public virtual Line Line { get; set; }

        [ForeignKey("Mom")]
        public int? MomID { get; set; }

        public Mouse Mom{get; set;}

        [ForeignKey("Dad")]
        public int? DadID { get; set; }

        public Mouse Dad { get; set; }

        [ForeignKey("MomID")]
        public virtual ICollection<Mouse> MotherOfPups { get; set; }

        [ForeignKey("DadID")]
        public virtual ICollection<Mouse> FatherOfPups { get; set; }

        public int? PK1ID { get; set; }

        [NotMapped]
        public GeneExpression PK1 { get; set; }

        public int? PK2ID { get; set; }

        [NotMapped]
        public GeneExpression PK2 { get; set; }

        public bool SynCre { get; set; }

        public virtual ICollection<MouseCage> MouseCages { get; set; }

        public virtual ICollection<MouseTask> MouseTasks { get; set; }

        public virtual ICollection<MouseHealthStatus> MouseHealthStatuses { get; set; }

    }
}
