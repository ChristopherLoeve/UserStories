﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserStories.Models
{
    public abstract class Card
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")] public string Title { get; set; }
        [Required(ErrorMessage = "Field is required")] public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public Card()
        {
            CreationDate = DateTime.Now;
        }

        protected Card(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            CreationDate = DateTime.Now;
        }
    }
}
