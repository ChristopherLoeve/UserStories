using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public class Fix : Card
    {
        public int Id { get; set; }
        public static int StatId { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        public bool Fixed { get; set; }
        //public DateTime CreationDate { get; set; }

        public Fix(string title, string description) : base( title, description, DateTime.Now)
        {
            Id = StatId;
            StatId++;
            Description = description;
            Fixed = false;
            CreationDate = DateTime.Now;
            
        }
        public Fix() : base()
        {
            Id = StatId;
            StatId++;
            Fixed = false;
            CreationDate = DateTime.Now;
        }

    }
}
