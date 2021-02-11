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
    public class UserStoryDetailModel : PageModel
    {
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private UserStoryService userStoryService;
        public ProgrammerRepository ProgrammerRepository { get; private set; }
        public string LayoutPage { get; set; }

        public UserStoryDetailModel(UserStoryService userStoryService, ProgrammerRepository programmerRepository)
        {
            this.userStoryService = userStoryService;
            ProgrammerRepository = programmerRepository;
        }

        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStories();
            UserStory = userStoryService.GetUserStory(id);
            LayoutPage = ProgrammerRepository.GetProgrammerLayout();
        }
    }
}
