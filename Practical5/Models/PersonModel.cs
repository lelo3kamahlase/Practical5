using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INF272Lecture4v1.Models
{
    public class PersonModel
    { 
 
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Current Age")]
        public int Age { get; set; } = 0;

        [Display(Name = "Living Status")]
        public bool IsAlive { get; set; } = true;
    }
}
}