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
    public class BacklogDeleteUserStoryModel : PageModel
    {
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private UserStoryService userStoryService;

        public BacklogDeleteUserStoryModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }

        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStoriesByColumn(Column.Backlog);
            UserStory = userStoryService.GetUserStory(id);
        }

        public IActionResult OnPost()
        {
            userStoryService.DeleteUserStory(UserStory.Id);
            return RedirectToPage("Backlog");
        }
    }
}