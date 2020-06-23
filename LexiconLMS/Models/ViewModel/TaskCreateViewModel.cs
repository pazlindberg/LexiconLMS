using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models.ViewModel
{
    public class TaskCreateViewModel
    {
        public int Id { get; set; }
        //public string Type { get; set; }
        [Required(ErrorMessage = "Du måste ange ett namn")]
        [MaxLength(50, ErrorMessage = "Max 50 tecken")]
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Du måste ange en starttid")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Starttid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Du måste ange en sluttid")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Sluttid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Modul")]
        public int ModuleId { get; set; }
        [Display(Name = "Aktivitet")]
        public int TaskTypeId { get; set; }

        //[Display(Name = "Modul")]
        //public Module Module { get; set; }
        //[Display(Name = "Aktivitet")]
        //public TaskType TaskType { get; set; }
    }
}
