using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages
{
    public class DeleteFixModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        private FixesService fixesService;
        public List<Fix> fixes { get; private set; }
        public string LayoutPage { get; set; }

        public DeleteFixModel(FixesService fixesService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.fixesService = fixesService;
        }

        public IActionResult OnGet(int id)
        {
            fixesService.GetFix(id);
            fixesService.DeleteFix(fixesService.GetFix(id));
            LayoutPage = ProgrammerService.GetProgrammerLayout();
            return RedirectToPage("Fixes");
        }

        public IActionResult OnPost(int id)
        {
            fixesService.DeleteFix(fixesService.GetFix(id));
            return RedirectToPage("Fixes");
        }
    }
}
