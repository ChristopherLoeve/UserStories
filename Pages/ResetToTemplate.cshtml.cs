using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Services;

namespace UserStories.Pages
{
    public class ResetToTemplateModel : PageModel
    {
        public ProgrammerRepository ProgrammerRepository { get; private set; }
        private UserStoryService userStoryService;
        public string LayoutPage { get; set; }
        public ResetToTemplateModel(UserStoryService userStoryService, ProgrammerRepository programmerRepository)
        {
            ProgrammerRepository = programmerRepository;
            this.userStoryService = userStoryService;
        }

        public IActionResult OnGet()
        {
            userStoryService.ResetToTemplate();
            LayoutPage = ProgrammerRepository.GetProgrammerLayout();
            return RedirectToPage("UserStories");
        }
    }
}
