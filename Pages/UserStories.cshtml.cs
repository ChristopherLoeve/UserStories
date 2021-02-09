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
        private UserStoryService userStoryService;
        public List<UserStory> UserStories { get; private set; }
        

        public UserStoriesModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }


        public void OnGet()
        {
            UserStories = userStoryService.GetUserStories();
        }

        public void OnGetMoveLeft(int id)
        {
            userStoryService.MoveStoryLeft(id);
            UserStories = userStoryService.GetUserStories();
        }

        public void OnGetMoveRight(int id)
        {
            userStoryService.MoveStoryRight(id);
            UserStories = userStoryService.GetUserStories();
        }
    }
}
