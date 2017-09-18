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

        public List<TaskType> Actions { get; set; }

        public List<Condition> Changes { get; set; }
    }
}
