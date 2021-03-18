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
    public class UserStoryDetailModel : PageModel
    {
        [BindProperty] public Task Task { get; set; }
        [BindProperty] public UserStory UserStory { get; set; }
        public List<UserStory> UserStories { get; private set; }
        public List<Task> Tasks { get; set; }
        private CardService cardService;
        public ProgrammerService ProgrammerService { get; private set; }

        public UserStoryDetailModel(CardService cardService, ProgrammerService programmerService)
        {
            this.cardService = cardService;
            ProgrammerService = programmerService;
        }

        public void OnGet(int id)
        {
            Tasks = cardService.GetUserStoryTasks(id);
            UserStories = cardService.GetUserStories();
            UserStory = (UserStory)cardService.GetCard(id);
        }

        public void OnGetToggle(int id, int taskId)
        {
            cardService.TaskStatus(id, taskId);
            OnGet(id);
        }
    }
}
