using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models.ViewModels
{
    public class CageAssignViewModel
    {
        public Mouse Mouse { get; set; }

        public int cageID { get; set; }

        public int mouseID { get; set; }

        public DateTime date { get; set; }

        public List<Cage> NotUsedStandardCages { get; set; }

        public List<Cage> NotUsedBreederCages { get; set; }

        public List<Cage> UsedStandardCages { get; set; }

        public List<Cage> UsedBreederCages { get; set; }
    }
}
