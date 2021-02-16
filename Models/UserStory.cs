using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public enum StoryPoint
    { 
        Small,
        Medium,
        Large
    }

    public enum Column
    {
        Backlog,
        To_Do,
        Doing,
        Done,
        Done_Done
    }
    

    public class UserStory : Card
    {
        public int BusinessValue { get; set; }
        public int Priority { get; set; }
        public StoryPoint StoryPoints { get; set; }
        public Column Column { get; set; }

        public UserStory()
        {
        }

        public UserStory(string title, string description, int businessValue, int priority, StoryPoint storyPoints, int id, Column column) : base(id, title, description)
        {
            BusinessValue = businessValue;
            Priority = priority;
            StoryPoints = storyPoints;
            Column = column;
        }
    }
}
