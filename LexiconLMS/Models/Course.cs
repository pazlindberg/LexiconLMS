using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        
        [Display(Name = "Start")]
        public DateTime StartDate { get; set; } 
        
        public ICollection<User> Users { get; set; }
        public ICollection<Module> Modules { get; set; }


    }
}
