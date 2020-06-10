using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models
{
    
    public class User : IdentityUser
    {
        
        public string FirstName { get; set; }
        public int? CourseId { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return (($"{FirstName} {LastName}")); } }

       
        //// user ID from AspNetUser table.
        //public string OwnerID { get; set; }
        public Course Course { get; set; }
        

    
    }
}