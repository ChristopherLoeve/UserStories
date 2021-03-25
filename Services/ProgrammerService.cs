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
        private List<Programmer> programmers;
        private readonly DbService<Programmer> DbService;

        public ProgrammerService(DbService<Programmer> dbService)
        {
            DbService = dbService;
            programmers = DbService.GetObjects().Result;
        }

        public List<Programmer> GetProgrammers()
        {
            return programmers;
        }

        public async void AddProgrammer(Programmer programmer)
        {
            await DbService.AddObject(programmer);
            programmers = DbService.GetObjects().Result;
        }

        public bool ValidateLogin(string email, string password)
        {
            if (IsEmailInUse(email))
                return (FindProgrammerByEmail(email).ValidatePassword(password)); // returns true if email & password matches
            
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

        public async void DeleteProgrammer(int id)
        {
            await DbService.RemoveObject(FindProgrammerById(id));
            programmers = DbService.GetObjects().Result;
        }

        public async void AddProfilePicture(int id, string fileName)
        {
            var programmer = programmers[id];
            programmer.ProfilePictureName = fileName;
            UpdateProgrammer(id, programmer);
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
            var programmer = FindProgrammerById(id);
            programmer.Password = hashed.Item2;
            programmer.Salt = hashed.Item1;
            UpdateProgrammer(id, programmer);
        }

        public async void UpdateProgrammer(int id, Programmer programmer)
        {
            Programmer p = FindProgrammerById(id);
            p.FirstName = programmer.FirstName;
            p.LastName = programmer.LastName;
            p.Email = programmer.Email;
            await DbService.UpdateObject(p);
        }
    }
}