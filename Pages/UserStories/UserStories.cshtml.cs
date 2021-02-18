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
    public class UserStoriesModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        public CardService cardService;
        public List<UserStory> UserStories { get; private set; }
        public string LayoutPage { get; set; }
        public List<UserStory> ToDoStories { get; private set; }
        public List<UserStory> DoingStories { get; private set; }
        public List<UserStory> DoneStories { get; private set; }
        public List<UserStory> DoneDoneList { get; private set; }



        public UserStoriesModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }


        public void OnGet()
        {
            UserStories = cardService.GetUserStories();
            LayoutPage = "." + ProgrammerService.GetProgrammerLayout();
        }

        public void OnGetMoveLeft(int id)
        {
            cardService.MoveStoryLeft(id);
            OnGet();
        }

        public void OnGetMoveRight(int id)
        {
            cardService.MoveStoryRight(id);
            OnGet();
        }

        public IActionResult OnGetUpdateObject(int id, string column)
        {
            UserStories = cardService.GetUserStories();
            string columnName = string.Empty;
            foreach (char character in column)
            {
                if (char.IsLetter(character))
                {
                    columnName += character;
                } else
                {
                    if (character == '_')
                    {
                        columnName += character;
                    }
                }
            }

            cardService.UpdateCard(id, cardService.GetCard(id));
            return Page();
        }
        
    }
}
