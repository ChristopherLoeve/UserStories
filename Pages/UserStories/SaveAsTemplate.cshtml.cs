using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Services;

namespace UserStories.Pages.UserStories
{
    public class SaveAsTemplateModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        private UserStoryService userStoryService;
        public SaveAsTemplateModel(UserStoryService userStoryService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.userStoryService = userStoryService;
        }

        public IActionResult OnGet()
        {
            userStoryService.SaveAsTemplate();
            return RedirectToPage("UserStories");
        }
    }
}
