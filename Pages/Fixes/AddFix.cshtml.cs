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
    public class AddFixModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        private CardService cardService;
        public string LayoutPage { get; set; }

        [BindProperty] public Fix fix { get; set; }

        public AddFixModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }

        public void OnGet()
        {
            fix = new Fix();
            LayoutPage = "." + ProgrammerService.GetProgrammerLayout();
        }

        public IActionResult OnPost()
        {
            cardService.AddCard(fix);
            return RedirectToPage("Fixes");
        }
    }
}
