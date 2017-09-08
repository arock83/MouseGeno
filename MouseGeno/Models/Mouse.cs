using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public DateTime Birth { get; set; }

        public DateTime Death { get; set; }

        public int GenoTypeID { get; set; }

        public GenoType GenoType { get; set; }

        [Required]
        public int LineID { get; set; }

        public Line Line { get; set; }

        public int MomID { get; set; }

        public int DadID { get; set; }

        public virtual ICollection<MouseCage> MouseCages { get; set; }

        public virtual ICollection<MouseTask> MouseTasks { get; set; }


    }
}
