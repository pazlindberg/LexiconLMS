﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Models
{
    public class TaskType
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
