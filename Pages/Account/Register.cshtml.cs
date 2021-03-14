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
        [BindProperty] public string confirmationPW { get; set; }


        public RegisterModel(ProgrammerService programmerService)
        {
            this.programmerService = programmerService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (programmerService.IsEmailInUse(Programmer.Email)) // Checks if the email is not in use. DOES NOT SHOW THE TEXT ATM
            {
                ModelState.AddModelError(Programmer.Email, "Email is already in use!");
                return Page();
            }

            if (confirmationPW != Programmer.Password)
            {
                ModelState.AddModelError(Programmer.Password, "Passwords did not match");
                return Page();
            }

            if (!ModelState.IsValid) // Checks is user filled registration form correctly, returns the registration site if they did not.
            {
                return Page();
            }

            var hashed = programmerService.HashPassword(Programmer.Password);

            Programmer.Salt = hashed.Item1;
            Programmer.Password = hashed.Item2;
            programmerService.AddProgrammer(Programmer);

            return RedirectToPage("../Index");
        }
    }
}
