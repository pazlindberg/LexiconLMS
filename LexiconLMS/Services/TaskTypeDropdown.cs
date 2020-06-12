using LexiconLMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Services
{
    public class TaskTypeDropdown : ITaskTypeDropdown
    {
        private readonly ApplicationDbContext context;

        public TaskTypeDropdown(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return context.TaskTypes.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() });
        }
    }
}
