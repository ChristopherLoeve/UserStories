﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public class Card
    {
        [Key] public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")] public string Title { get; set; }
        [Required(ErrorMessage = "Field is required")] public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public Card()
        {
            //Id = currentId++;
            CreationDate = DateTime.Now;
        }

        protected Card(string title, string description)
        {
            //Id = currentId++;
            Title = title;
            Description = description;
            CreationDate = DateTime.Now;
        }
    }
}
