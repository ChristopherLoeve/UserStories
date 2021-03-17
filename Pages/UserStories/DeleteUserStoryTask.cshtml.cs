using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.UserStories
{
    public class DeleteUserStoryTaskModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public Task Task { get; set; }
        public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; set; }
        public List<Task> Tasks { get; private set; }
        private CardService cardService;

        public DeleteUserStoryTaskModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }

        public void OnGet(int userStory, int id)
        {
            UserStories = cardService.GetUserStories();
            UserStory = (UserStory)cardService.GetCard(userStory);
            Tasks = cardService.GetUserStoryTasks(userStory);
            foreach (Task t in Tasks)
            {
                if (t.Id == id) Task = t;
            }
        }

        public IActionResult OnPost(int userStory, int id)
        {
            cardService.DeleteUserStoryTask(userStory, id);
            return RedirectToPage("UserStoryDetail", new {id = userStory});
        }
    }
}
