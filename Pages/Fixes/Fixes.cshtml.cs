using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Fixes
{
    public class FixesModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        private CardService cardService;
        public List<Fix> Fixes { get; private set; }

        public FixesModel(CardService cardService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.cardService = cardService;
        }

        public void OnGet()
        {
            Fixes = cardService.GetFixes();
        }
    }
}
