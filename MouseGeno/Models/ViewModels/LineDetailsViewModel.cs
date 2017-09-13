using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models.ViewModels
{
    public class LineDetailsViewModel
    {
        public Line Line { get; set; }

        public ICollection<Mouse> Mice { get; set; }

        public ICollection<Cage> Cages { get; set; }
    }
}
