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

        [Required]
        [Display(Name = "Kurs")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Beskrivning")]
        [StringLength(31)]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime StartDate { get; set; }

        [Display(Name = "Elever")]
        public ICollection<User> Users { get; set; }
        public ICollection<Module> Modules { get; set; }


    }
}
