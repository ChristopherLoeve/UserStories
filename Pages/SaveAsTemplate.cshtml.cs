using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Services;

namespace UserStories.Pages
{
    public class SaveAsTemplateModel : PageModel
    {
        private UserStoryService userStoryService;
        public SaveAsTemplateModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }

        public IActionResult OnGet()
        {
            userStoryService.SaveAsTemplate();
            return RedirectToPage("UserStories");
        }
    }
}
