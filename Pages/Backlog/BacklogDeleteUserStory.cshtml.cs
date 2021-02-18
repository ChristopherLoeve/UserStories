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
    public class BacklogDeleteUserStoryModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private CardService cardService;
        public string LayoutPage { get; set; }

        public BacklogDeleteUserStoryModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }

        public void OnGet(int id)
        {
            UserStories = cardService.GetUserStoriesByColumn(Column.Backlog);
            UserStory = (UserStory)cardService.GetCard(id);
            LayoutPage = "." + ProgrammerService.GetProgrammerLayout();
        }

        public IActionResult OnPost()
        {
            cardService.DeleteCard(UserStory.Id);
            return RedirectToPage("Backlog");
        }
    }
}