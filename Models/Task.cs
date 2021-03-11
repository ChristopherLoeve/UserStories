using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public class Task : Card
    {
        public bool TaskDone { get; set; }
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
