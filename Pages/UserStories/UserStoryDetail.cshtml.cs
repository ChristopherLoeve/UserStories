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
    public class UserStoryDetailModel : PageModel
    {
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private CardService cardService;
        public ProgrammerService ProgrammerService { get; private set; }
        public string LayoutPage { get; set; }

        public UserStoryDetailModel(CardService cardService, ProgrammerService programmerService)
        {
            this.cardService = cardService;
            ProgrammerService = programmerService;
        }

        public void OnGet(int id)
        {
            UserStories = cardService.GetUserStories();
            UserStory = (UserStory)cardService.GetCard(id);
            LayoutPage = "." + ProgrammerService.GetProgrammerLayout();
        }
    }
}
