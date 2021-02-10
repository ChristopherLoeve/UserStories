using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ProgrammerRepository programmerRepository;
        public new Programmer Programmer { get; set; }
        [Required, EmailAddress, BindProperty]
        public string Email { get; set; }
        [Required, BindProperty]
        public string Password { get; set; }
        [TempData]
        public string Message { get; set; }

        public LoginModel(ProgrammerRepository programmerRepository)
        {
            this.programmerRepository = programmerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            bool doesProgrammerExist = programmerRepository.ValidateLogin(Email, Password);
            if (doesProgrammerExist)
            {
                TempData["LoginSuccess"] = "Login Successful!";
                return RedirectToPage("../Index");
            }
            TempData["Message"] = "Invalid email or password";
            return RedirectToPage("./Login");
        }
    }
}
