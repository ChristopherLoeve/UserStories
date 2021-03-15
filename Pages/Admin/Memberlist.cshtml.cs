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
    public class MemberlistModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        public List<Programmer> Programmers;

        public MemberlistModel(ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
        }

        public IActionResult OnGet()
        {
            if (ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name).AccessLevel < 10)
                return RedirectToPage("../index");

            Programmers = ProgrammerService.GetProgrammers();

            return Page();
        }
    }
}
