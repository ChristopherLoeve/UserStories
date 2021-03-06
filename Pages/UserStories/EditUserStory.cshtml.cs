using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.UserStories
{
    public class EditUserStoryModel : PageModel
    {
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private CardService cardService;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> StoryPoints { get; set; }
        public ProgrammerService ProgrammerService { get; private set; }

        public EditUserStoryModel(CardService cardService, IHtmlHelper htmlHelper, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet(int id)
        {
            UserStories = cardService.GetUserStories();
            UserStory = (UserStory)cardService.GetCard(id);
            StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                UserStories = cardService.GetUserStories();
                StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
                return Page();
            }

            cardService.UpdateCard(UserStory);

            return RedirectToPage("UserStories");
        }
    }
}