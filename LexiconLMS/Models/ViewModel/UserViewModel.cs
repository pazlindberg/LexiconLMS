using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models.ViewModel
{
    public class UserViewModel
    {


        public string Id { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        [StringLength(30)]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "LastName")]
        [StringLength(30)]
        public string LastName { get; set; }

        public string FullName { get { return (($"{FirstName} {LastName}")); } }

        
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Role { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }

        

    }
}
