using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseGeno.Models.ViewModels
{
    public class TaskOnCageViewModel
    {
        public List<Mouse> MiceInCage { get; set; }

        public TaskType TaskType { get; set; }

        public Cage Cage { get; set; }

        public DateTime Date { get; set; }

        public List<MouseTask> MouseTasks { get; set; }

    }
}
