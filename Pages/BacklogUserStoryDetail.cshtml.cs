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
    public class BacklogUserStoryDetailModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private UserStoryService userStoryService;
        public string LayoutPage { get; set; }

        public BacklogUserStoryDetailModel(UserStoryService userStoryService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.userStoryService = userStoryService;
        }

        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStoriesByColumn(Column.Backlog);
            UserStory = userStoryService.GetUserStory(id);
            LayoutPage = ProgrammerService.GetProgrammerLayout();
        }
    }
}
