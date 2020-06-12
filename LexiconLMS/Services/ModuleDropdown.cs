using LexiconLMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Services
{
    public class ModuleDropdown : IModuleDropdown
    {
        private readonly ApplicationDbContext context;

        public ModuleDropdown(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return context.Modules.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
        }
    }
}
