using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models.ViewModels
{
    public class CageLineViewModel
    {
        public Line Line { get; set; }

        public IEnumerable<CagedMice> MiceInCages { get; set; }

        public class CagedMice
        {
            public Cage Cage { get; set; }
            public IEnumerable<Mouse> Mice { get; set; }
        }
    }
}
