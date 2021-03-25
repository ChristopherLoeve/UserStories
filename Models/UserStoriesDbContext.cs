using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserStories.Models
{
    public class UserStoriesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserStoryDb; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Programmer> Programmers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Fix> Fixes { get; set; }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<Task> Tasks { get; set; }


    }
}
