using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public class Task : Card
    {
        [Required] public bool TaskDone { get; set; }
        public Task()
        {
            TaskDone = false;
        }

        public Task(string title, string description) : base(title, description)
        {
            TaskDone = false;
        }
    }
}
