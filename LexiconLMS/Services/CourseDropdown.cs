using LexiconLMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Services
{
    public class CourseDropdown : ICourseDropdown
    {
        private readonly ApplicationDbContext context;

        public CourseDropdown(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return context.Courses.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }
    }
}
