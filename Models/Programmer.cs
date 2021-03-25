using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace UserStories.Models
{
    public class Programmer
    {
        [Key] public int ProgrammerId { get; set; }

        [Required, StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required, StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(60, MinimumLength = 8)]
        public string Password { get; set; } 
        [Required] public byte[] Salt { get; set; }
        public static int InstanceCount { get; set; }
        public string ProfilePictureName { get; set; }
        public DateTime CreationTime { get; set; }
        [Required] public int AccessLevel { get; set; }

        public Programmer()
        {
            ProgrammerId = InstanceCount++;
            ProfilePictureName = "";
            CreationTime = DateTime.Now;
            AccessLevel = 1;
        }

        public bool ValidatePassword(string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (hashed == Password);
        }
    }
}
