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
    

    public class UserStory
    {
        //dette er et id
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")] public string Title { get; set; }
        [Required(ErrorMessage = "Field is required")] public string Description { get; set; }
        public int BusinessValue { get; set; }
        public DateTime CreationDate { get; set; }
        public int Priority { get; set; }
        public StoryPoint StoryPoints { get; set; }
        public Column Column { get; set; }

        public UserStory()
        {
            CreationDate = DateTime.Now;
        }

        public UserStory(string title, string description, int businessValue, int priority, StoryPoint storyPoints, int id, Column column)
        {
            Id = id;
            Title = title;
            Description = description;
            BusinessValue = businessValue;
            CreationDate = DateTime.Now;
            Priority = priority;
            StoryPoints = storyPoints;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Id}: {Title}";
        }
    }
}
