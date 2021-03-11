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
    public class AccountPageModel : PageModel
    {
        public Programmer Programmer;
        public ProgrammerService ProgrammerService { get; private set; }
        public AccountPageModel(ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
        }

        public void OnGet()
        {
            Programmer = ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name);
        }
    }
}
