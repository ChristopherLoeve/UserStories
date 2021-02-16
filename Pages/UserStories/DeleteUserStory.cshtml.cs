using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.UserStories
{
    public class DeleteUserStoryModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private UserStoryService userStoryService;
        public string LayoutPage { get; set; }

        public DeleteUserStoryModel(UserStoryService userStoryService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.userStoryService = userStoryService;
        }

        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStories();
            UserStory = userStoryService.GetUserStory(id);
            LayoutPage = "." + ProgrammerService.GetProgrammerLayout();
        }

        public IActionResult OnPost()
        {
            userStoryService.DeleteUserStory(UserStory.Id);
            return RedirectToPage("UserStories");
        }
    }
}