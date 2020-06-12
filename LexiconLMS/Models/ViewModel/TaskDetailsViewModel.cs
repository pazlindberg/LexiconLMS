using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models.ViewModel
{
    public class TaskDetailsViewModel
    {
        public int Id { get; set; }
        //public string Type { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Starttid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Sluttid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime EndDate { get; set; }
        //[Display(Name = "Modul")]
        //public int ModuleId { get; set; }
        //[Display(Name = "Aktivitet")]
        //public int TaskTypeId { get; set; }

        [Display(Name = "Modul")]
        public Module Module { get; set; }
        [Display(Name = "Aktivitet")]
        public TaskType TaskType { get; set; }
    }
}
