using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MouseGeno.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        
        [Display(Name = "Name")]
        [StringLength(40)]
        public string Name { get; set; }

        
        [Display(Name = "Initials")]
        [StringLength(3)]
        public string Initials { get; set; }

        public virtual ICollection<MouseTask> MouseTasks { get; set; }

        public virtual ICollection<CageCondition> CageConditions { get; set; }

        public virtual ICollection<MouseHealthStatus> MouseHealthStatuses { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
