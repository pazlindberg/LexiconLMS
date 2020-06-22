using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models.ViewModel
{
    public class ModuleEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste ange ett namn")]
        [MaxLength(30, ErrorMessage = "Max 30 tecken")]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du måste ange en beskrivning")]
        [MaxLength(30, ErrorMessage = "Max 30 tecken")]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Du måste ange en starttid")]
        [Display(Name = "Startdatum")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Du måste ange en sluttid")]
        [Display(Name = "Slutdatum")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
