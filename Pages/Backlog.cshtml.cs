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
    public class BacklogModel : PageModel
    {
        public ProgrammerRepository ProgrammerRepository { get; private set; }
        private UserStoryService userStoryService;
        public List<UserStory> UserStories { get; private set; }
        public string LayoutPage { get; set; }

        public BacklogModel(UserStoryService userStoryService, ProgrammerRepository programmerRepository)
        {
            ProgrammerRepository = programmerRepository;
            this.userStoryService = userStoryService;
        }
        public void OnGet()
        {
            UserStories = userStoryService.GetUserStoriesByColumn(Column.Backlog);
            LayoutPage = ProgrammerRepository.GetProgrammerLayout();
        }

        public void OnGetMoveLeft(int id)
        {
            userStoryService.MoveStoryLeft(id);
            LayoutPage = ProgrammerRepository.GetProgrammerLayout();
            OnGet();
        }

        public void OnGetMoveRight(int id)
        {
            userStoryService.MoveStoryRight(id);
            LayoutPage = ProgrammerRepository.GetProgrammerLayout();
            OnGet();
        }
    }
}

