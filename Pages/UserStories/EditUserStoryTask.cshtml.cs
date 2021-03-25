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
        public List<UserStory> UserStories { get; private set; }
        public static int UserStoryId { get; set; }
        private CardService cardService;

        public EditUserStoryTaskModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }
        public void OnGet(int userStoryId, int id)
        {
            UserStoryId = userStoryId;
            UserStories = cardService.GetUserStories();
            Task = (Task)cardService.GetCard(id);
        }

        public IActionResult OnPost(int id)
        {
            UserStory us = (UserStory)cardService.GetCard(UserStoryId);
            if (!ModelState.IsValid)
            {
                Task = (Task)cardService.GetCard(id);
                return Page();
            }

            cardService.UpdateUserStoryTask(Task, UserStoryId, id);
            return RedirectToPage("UserStoryDetail", new { id = UserStoryId });
        }
    }
}
