using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.UserStories
{
    public class CreateUserStoryTaskModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public Task Task { get; set; }
        public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        public List<Task> Tasks { get; private set; }
        private CardService cardService;

        public CreateUserStoryTaskModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }

        public void OnGet(int id)
        {
            UserStories = cardService.GetUserStories();
            Tasks = cardService.GetTasks();
            UserStory = (UserStory)cardService.GetCard(id);
        }

        public IActionResult OnPost(int id)
        {
            UserStory = (UserStory)cardService.GetCard(id);
            if (!ModelState.IsValid)
            {
                UserStories = cardService.GetUserStories();
                Tasks = cardService.GetTasks();
                UserStory = (UserStory)cardService.GetCard(id);
                return Page();
            }

            cardService.AddTask(Task, id);
            return RedirectToPage("UserStoryDetail", new {id = id});
        }
    }
}
