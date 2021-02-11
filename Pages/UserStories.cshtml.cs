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
    public class UserStoriesModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        public UserStoryService userStoryService;
        public List<UserStory> UserStories { get; private set; }
        public string LayoutPage { get; set; }
        public List<UserStory> ToDoStories { get; private set; }
        public List<UserStory> DoingStories { get; private set; }
        public List<UserStory> DoneStories { get; private set; }
        public List<UserStory> DoneDoneList { get; private set; }



        public UserStoriesModel(UserStoryService userStoryService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.userStoryService = userStoryService;
        }


        public void OnGet()
        {
            UserStories = userStoryService.GetUserStories();
            LayoutPage = ProgrammerService.GetProgrammerLayout();
        }

        public void OnGetMoveLeft(int id)
        {
            userStoryService.MoveStoryLeft(id);
            LayoutPage = ProgrammerService.GetProgrammerLayout();
            OnGet();
        }

        public void OnGetMoveRight(int id)
        {
            userStoryService.MoveStoryRight(id);
            LayoutPage = ProgrammerService.GetProgrammerLayout();
            OnGet();
        }
        
    }
}
