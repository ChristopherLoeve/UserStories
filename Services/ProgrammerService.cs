using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using UserStories.Models;

namespace UserStories.Services
{
    public class ProgrammerService
    {
        private readonly List<Programmer> programmers;
        public JsonFileService JsonFileService { get; set; }
        public static Programmer Programmer { get; set; }

        public ProgrammerService(JsonFileService jsonFileService)
        {
            JsonFileService = jsonFileService;

            programmers = JsonFileService.GetProgrammers().ToList();
        }

        /// <summary>
        /// Returns the list of users.
        /// </summary>
        /// <returns></returns>
        public List<Programmer> GetProgrammers()
        {
            return programmers;
        }

        /// <summary>
        /// Add and saves a new user.
        /// </summary>
        /// <param name="user"></param>
        public void AddProgrammer(Programmer programmer)
        {
            programmers.Add(programmer);
            JsonFileService.SaveProgrammers(programmers);
        }

        /// <summary>
        /// Validates if user entered correct password and username.
        /// Returns the User object, if it exists.
        /// </summary>
        /// <param name="Programmer"></param>
        /// <returns></returns>
        public bool ValidateLogin(string email, string password)
        {
            if (IsEmailInUse(email))
            {
                return (FindProgrammerByEmail(email).ValidatePassword(password));
            }
            return false;

        }

        public bool IsEmailInUse(string email)
        {
            return programmers.Any(u => u.Email == email); // Checks all users in list "users" if incoming email matches one of them.
        }

        public Programmer FindProgrammerByEmail(string email)
        {
            foreach (Programmer p in programmers)
            {
                if (p.Email == email) return p;
            }

            return null;
        }

        public Programmer FindProgrammerById(int id)
        {
            foreach (Programmer p in programmers)
            {
                if (p.ProgrammerId == id) return p;
            }

            return null;
        }

        public void DeleteProgrammer(int id)
        {
            programmers.Remove(FindProgrammerById(id));
            Commit();
        }

        public void AddProfilePicture(int id, string fileName)
        {
            programmers[id].ProfilePictureName = fileName;
            Commit();
        }

        public Tuple<byte[], string> HashPassword(string password)
        {
            // HASHING PASSWORD FOR STORING
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return Tuple.Create(salt, hashed);
        }

        public void ChangePassword(int id, string password)
        {
            var hashed = HashPassword(password);
            Programmer p = FindProgrammerById(id);
            p.Password = hashed.Item2;
            p.Salt = hashed.Item1;

            Commit();
        }

        public void UpdateProgrammer(int id, Programmer programmer)
        {
            Programmer p = FindProgrammerById(id);
            p.FirstName = programmer.FirstName;
            p.LastName = programmer.LastName;
            p.Email = programmer.Email;

            Commit();
        }

        public void Commit()
        {
            JsonFileService.SaveProgrammers(programmers);
        }
    }
}