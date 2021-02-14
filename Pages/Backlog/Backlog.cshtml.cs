using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Backlog
{
    public class BacklogModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        private UserStoryService userStoryService;
        public List<UserStory> UserStories { get; private set; }
        public string LayoutPage { get; set; }

        public BacklogModel(UserStoryService userStoryService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.userStoryService = userStoryService;
        }
        public void OnGet()
        {
            UserStories = userStoryService.GetUserStoriesByColumn(Column.Backlog);
            LayoutPage = "." + ProgrammerService.GetProgrammerLayout();
        }

        public void OnGetMoveRight(int id)
        {
            userStoryService.MoveStoryRight(id);
            OnGet();
        }
    }
}

