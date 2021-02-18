using System.Collections.Generic;
using System.Linq;
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
        /// Gets current logged in user.
        /// </summary>
        /// <returns>User</returns>
        public Programmer GetLoggedInProgrammer()
        {
            return Programmer;
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
                if (programmers.Any(u => u.Password == password)) // Checks if password matches password.
                {
                    Programmer = programmers.SingleOrDefault(u => u.Email == email);
                    Programmer.LoggedIn = true;
                    Commit();
                }
            }
            return Programmer.LoggedIn;

        }
        /// <summary>
        /// Checks if email is already in use, returns true if it is.
        /// </summary>
        /// <param name="email">Email of the user trying to register.</param>
        /// <returns></returns>
        public bool IsEmailInUse(string email)
        {
            return programmers.Any(u => u.Email == email); // Checks all users in list "users" if incoming email matches one of them.
        }

        /// <summary>
        /// Gets the users layout, based on wether they're logged in or not.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetProgrammerLayout()
        {
            string LayoutPage = "./Shared/_Layout.cshtml";

            if (Programmer != null)
            {
                if (Programmer.LoggedIn)
                {
                    LayoutPage = "./Shared/_otherLayout.cshtml";
                }
            }
            return LayoutPage;
        }

        public void Commit()
        {
            JsonFileService.SaveProgrammers(programmers);
        }
    }
}