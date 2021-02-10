using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages
{
    public class BacklogCreateUserStoryModel : PageModel
    {
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private UserStoryService userStoryService;

        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> StoryPoints { get; set; }

        public BacklogCreateUserStoryModel(UserStoryService userStoryService, IHtmlHelper htmlHelper)
        {
            this.userStoryService = userStoryService;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStoriesByColumn(Column.Backlog);
            UserStory = new UserStory();
            UserStory.Description = "As \nI want to \nSo \n\nAcceptance Criteria:\nGiven that \nWhen I \nThen I ";
            StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                UserStories = userStoryService.GetUserStories();
                StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
                return Page();
            }

            UserStory.Column = (Column)id;
            userStoryService.AddUserStory(UserStory);
            return RedirectToPage("Backlog");
        }
    }
}