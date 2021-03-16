using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Admin
{
    public class DeleteProgrammerModel : PageModel
    {
        public Programmer Programmer { get; set; }
        public ProgrammerService ProgrammerService { get; private set; }

        public DeleteProgrammerModel(ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
        }

        public IActionResult OnGet(int id)
        {
            if (ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name).AccessLevel < 10)
                return RedirectToPage("Memberlist");

            Programmer = ProgrammerService.FindProgrammerById(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            ProgrammerService.DeleteProgrammer(id);
            return RedirectToPage("Memberlist");
        }
    }
}
