using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models.ViewModels
{
    public class CageAssignViewModel
    {
        public Mouse Mouse { get; set; }

        public int? CurrentCageID { get; set; }

        public Cage CurrentCage { get; set; }

        public int NewCageID { get; set; }

        public int MouseID { get; set; }

        public DateTime Date { get; set; }

        public List<Cage> NotUsedStandardCages { get; set; }

        public List<Cage> NotUsedBreederCages { get; set; }

        public List<Cage> UsedStandardCages { get; set; }

        public List<Cage> UsedBreederCages { get; set; }
    }
}
