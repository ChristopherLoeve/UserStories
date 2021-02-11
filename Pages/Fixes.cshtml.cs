using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Shared
{
    public class FixesModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        private FixesService fixesService;
        public List<Fix> Fixes { get; private set; }
        public string LayoutPage { get; set; }

        public FixesModel(FixesService fixesService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.fixesService = fixesService;
        }

        public void OnGet()
        {
            Fixes = fixesService.GetFixes();
            LayoutPage = ProgrammerService.GetProgrammerLayout();
        }
    }
}
