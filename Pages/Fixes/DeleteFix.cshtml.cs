using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Fixes
{
    public class DeleteFixModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        private CardService cardService;

        public DeleteFixModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }

        public IActionResult OnGet(int id)
        {
            cardService.DeleteCard(id);
            return RedirectToPage("Fixes");
        }
    }
}
