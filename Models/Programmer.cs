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
        public int ProgrammerId { get; private set; }
        public static int InstanceCount { get; set; }
        public bool LoggedIn { get; set; }

        public Programmer()
        {
            InstanceCount += 1;
            ProgrammerId = InstanceCount;
        }
        public Programmer(int instancecount)
        {
            InstanceCount = instancecount;
            FirstName = "Guest";
            LastName = "Gustav";
            Email = "Guest@gmail.com";
        }

        ///// <summary>
        ///// Checks if the user already have played the game, returns true or false.
        ///// </summary>
        ///// <param name="game"></param>
        ///// <returns></returns>
        //public bool HavePlayed(Game game)
        //{

        //    return AlreadyPlayed.Contains(game);

        //}



    }
}
