using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;
using Task = UserStories.Models.Task;

namespace UserStories.Pages.UserStories
{
    public class EditUserStoryTaskModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public Models.Task Task { get; set; }
        public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        public List<Task> Tasks { get; private set; }
        private CardService cardService;

        public EditUserStoryTaskModel(CardService cardService, ProgrammerService programmerService)
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

        public IActionResult OnPost(int userStory, int id)
        {
            UserStory = (UserStory)cardService.GetCard(id);
            if (!ModelState.IsValid)
            {
                Tasks = cardService.GetTasks();
                return Page();
            }

            cardService.UpdateUserStoryTask(Task, userStory, id);
            return RedirectToPage("UserStoryDetail", new { id = id });
        }
    }
}
