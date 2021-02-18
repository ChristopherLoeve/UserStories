using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Backlog
{
    public class BacklogCreateUserStoryModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private CardService cardService;

        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> StoryPoints { get; set; }
        public string LayoutPage { get; set; }

        public BacklogCreateUserStoryModel(CardService cardService, IHtmlHelper htmlHelper, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet(int id)
        {
            UserStories = cardService.GetUserStoriesByColumn(Column.Backlog);
            UserStory.Description = "As \nI want to \nSo \n\nAcceptance Criteria:\nGiven that \nWhen I \nThen I ";
            StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                UserStories = cardService.GetUserStories();
                StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
                return Page();
            }

            UserStory.Column = (Column)id;
            cardService.AddCard(UserStory);
            return RedirectToPage("Backlog");
        }
    }
}