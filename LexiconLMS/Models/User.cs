using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models
{
    
    public class User : IdentityUser
    {
        [Display(Name = "FirstName")]
        [StringLength(30)]
        public string FirstName { get; set; }
        
        
        [Display(Name = "LastName")]
        [StringLength(30)]
        public string LastName { get; set; }

        public string FullName { get { return (($"{FirstName} {LastName}")); } }


        public int? CourseId { get; set; }

        [Display(Name = "Course Name")]
        public Course Course { get; set; }
        

    
    }
}