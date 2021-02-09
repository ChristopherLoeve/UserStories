using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ProgrammerRepository programmerRepository;

        [TempData] // Binds line 38 to Message property below, this ensures it will only show one time as TempData is cleared.
        public string Message { get; set; }
        [BindProperty]
        public new Programmer Programmer { get; set; }


        public RegisterModel(ProgrammerRepository programmerRepository)
        {
            this.programmerRepository = programmerRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid) // Checks is user filled registration form correctly, returns the registration site if they did not.
            {
                return Page();
            }
            bool isEmailInUse = programmerRepository.IsEmailInUse(Programmer.Email);
            if (isEmailInUse) // Checks if the email is not in use.
            {
                TempData["Message"] = "Email is already in use!";
                return Page();
            }
            programmerRepository.AddProgrammer(Programmer);
            if (true)
            {
                programmerRepository.ValidateLogin(Programmer.Email, Programmer.Password);
            }
            return RedirectToPage("../Index");
        }
    }
}
