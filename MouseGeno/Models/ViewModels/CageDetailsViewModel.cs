using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models.ViewModels
{
    public class CageDetailsViewModel
    {
        public Cage Cage { get; set; }

        public List<Mouse> MiceInCage { get; set; }
    }
}
