using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Fixes
{
    public class EditFixModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }

        [BindProperty] public Fix Fix { get; set; }
        private CardService cardService;

        public EditFixModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }
        public void OnGet(int id)
        {
            Fix = (Fix)cardService.GetCard(id);
            cardService.GetFixes();
        }

        public IActionResult OnPost(int id)
        {
            cardService.UpdateCard(id, Fix);
            return RedirectToPage("Fixes");
        }
    }
}
