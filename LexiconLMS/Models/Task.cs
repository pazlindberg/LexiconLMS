using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models
{
    
    public class Task
    {
        public int Id { get; set; }
        //public string Type { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Start")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Slut")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime EndDate { get; set; }


        [Display(Name = "Modul")]
        public int ModuleId { get; set; }

        [Display(Name = "Aktivitet")]
        public int TaskTypeId { get; set; }


        [Display(Name = "Modul")]
        public Module Module { get; set; }

        [Display(Name = "Aktivitet")]
        public TaskType TaskType { get; set; }

    }
}
