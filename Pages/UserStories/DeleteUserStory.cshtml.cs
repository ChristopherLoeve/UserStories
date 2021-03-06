using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.UserStories
{
    public class DeleteUserStoryModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private CardService cardService;

        public DeleteUserStoryModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }

        public void OnGet(int id)
        {
            UserStories = cardService.GetUserStories();
            UserStory = (UserStory)cardService.GetCard(id);
        }

        public IActionResult OnPost()
        {
            cardService.DeleteCard(UserStory.Id);
            return RedirectToPage("UserStories");
        }
    }
}