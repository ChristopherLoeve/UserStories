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
    public class EditAccountModel : PageModel
    {
        [BindProperty] public Programmer Programmer { get; set; }
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public string NewPassword { get; set; }
        [BindProperty] public string ConfirmNewPassword { get; set; }

        public EditAccountModel(ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
        }

        public void OnGet()
        {
            Programmer = ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name);
        }

        public IActionResult OnPost()
        {
            Programmer currentProgrammer = ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name);
            if (!ModelState.IsValid)
            {
                Programmer = currentProgrammer;
                return Page();
            }

            if (!ProgrammerService.ValidateLogin(Programmer.Email, Programmer.Password))
            {
                Programmer = currentProgrammer;
                ModelState.AddModelError(Programmer.Password, "Password was incorrect");
                return Page();
            }

            if (!String.IsNullOrEmpty(NewPassword))
            {
                if (NewPassword != ConfirmNewPassword)
                {
                    Programmer = currentProgrammer;
                    ModelState.AddModelError(NewPassword, "New password did not match confirmation");
                    return Page();
                }

                ProgrammerService.ChangePassword(currentProgrammer.ProgrammerId, NewPassword);
            }

            ProgrammerService.UpdateProgrammer(currentProgrammer.ProgrammerId, Programmer);
            return RedirectToPage("AccountPage");
        }
    }
}
