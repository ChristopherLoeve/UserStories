using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserStories.Models
{
    public class Programmer
    {
        // Define, properties used for creating an account.
        // Add Required DataAnnotations, and proper fields.
        [Required, StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required, StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(60, MinimumLength = 8)]
        public string Password { get; set; } // Skal skiftes fra public til private 
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public int ProgrammerId { get; }
        public static int InstanceCount { get; set; }
        public string ProfilePictureName { get; set; }

        public Programmer()
        {
            ProgrammerId = InstanceCount++;
            ProfilePictureName = "";
        }
        
    }
}
