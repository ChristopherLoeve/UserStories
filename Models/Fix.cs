using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public class Fix : Card
    {
        public bool Fixed { get; set; }

        public Fix()
        {
            Fixed = false;
        }

        public Fix(int id, string title, string description) : base(id, title, description)
        {
            Fixed = false;

        }
    }
}
