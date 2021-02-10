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
    public class BacklogEditUserStoryModel : PageModel
    {
        public ProgrammerRepository ProgrammerRepository { get; private set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        private UserStoryService userStoryService;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> StoryPoints { get; set; }
        public string LayoutPage { get; set; }

        public BacklogEditUserStoryModel(UserStoryService userStoryService, IHtmlHelper htmlHelper, ProgrammerRepository programmerRepository)
        {
            ProgrammerRepository = programmerRepository;
            this.userStoryService = userStoryService;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStoriesByColumn(Column.Backlog);
            UserStory = userStoryService.GetUserStory(id);
            StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
            LayoutPage = ProgrammerRepository.GetProgrammerLayout();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                UserStories = userStoryService.GetUserStories();
                StoryPoints = htmlHelper.GetEnumSelectList<StoryPoint>();
                return Page();
            }

            userStoryService.EditUserStory(UserStory.Id, UserStory);

            return RedirectToPage("Backlog");
        }
    }
}