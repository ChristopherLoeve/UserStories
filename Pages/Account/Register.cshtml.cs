using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ProgrammerService programmerService;

        [TempData] // Binds line 38 to Message property below, this ensures it will only show one time as TempData is cleared.
        public string Message { get; set; }
        [BindProperty]
        public Programmer Programmer { get; set; }


        public RegisterModel(ProgrammerService programmerService)
        {
            this.programmerService = programmerService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (programmerService.IsEmailInUse(Programmer.Email)) // Checks if the email is not in use. DOES NOT ACTUALLY WORK ATM
            {
                ModelState.AddModelError(Programmer.Email, "Email is already in use!");
                return Page();
            }

            if (!ModelState.IsValid) // Checks is user filled registration form correctly, returns the registration site if they did not.
            {
                return Page();
            }

            // HASHING PASSWORD FOR STORING
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Programmer.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            Programmer.Password = hashed;
            Programmer.Salt = salt;
            programmerService.AddProgrammer(Programmer);

            return RedirectToPage("../Index");
        }
    }
}
