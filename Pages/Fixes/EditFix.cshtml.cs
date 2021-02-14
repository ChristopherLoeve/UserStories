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
        private FixesService fixesService;
        public string LayoutPage { get; set; }

        public EditFixModel(FixesService fixesService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.fixesService = fixesService;
        }
        public void OnGet(int id)
        {
            Fix = fixesService.GetFix(id);
            fixesService.GetFixes();
            LayoutPage = "." + ProgrammerService.GetProgrammerLayout();
        }

        public IActionResult OnPost(int id)
        {
            fixesService.UpdateFix(Fix, id);
            return RedirectToPage("Fixes");
        }
    }
}
