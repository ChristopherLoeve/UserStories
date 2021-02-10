using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages
{
    public class DeleteUserStoryModel : PageModel
    {
        public ProgrammerRepository ProgrammerRepository { get; private set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private UserStoryService userStoryService;
        public string LayoutPage { get; set; }

        public DeleteUserStoryModel(UserStoryService userStoryService, ProgrammerRepository programmerRepository)
        {
            ProgrammerRepository = programmerRepository;
            this.userStoryService = userStoryService;
        }

        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStories();
            UserStory = userStoryService.GetUserStory(id);
            LayoutPage = ProgrammerRepository.GetProgrammerLayout();
        }

        public IActionResult OnPost()
        {
            userStoryService.DeleteUserStory(UserStory.Id);
            return RedirectToPage("UserStories");
        }
    }
}