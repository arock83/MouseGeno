using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models.ViewModels
{
    public class NewLitterViewModel
    {
        public int CageID { get; set; }

        public Cage Cage { get; set; }

        public int NumOfPups { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Mouse> Parents { get; set; }

        public int MomID { get; set; }
        
        public int DadID { get; set; }

        public List<Mouse> Pups { get; set; }

    }
}
