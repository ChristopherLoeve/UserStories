using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public class Fix
    {
        public int Id { get; set; }
        public static int StatId {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Fixed { get; set; }

        public Fix(string description)
        {
            StatId++;
            Id = StatId;
            Description = description;
            Fixed = false;
        }
        public Fix()
        {
            //auto
            StatId++;
            Id = StatId;
            Fixed = false;
        }

    }
}
