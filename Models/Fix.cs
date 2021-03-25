using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public class Fix : Card
    {
        [Required] public bool Fixed { get; set; }

        public Fix()
        {
            Fixed = false;
        }

        public Fix(string title, string description) : base(title, description)
        {
            Fixed = false;

        }
    }
}
