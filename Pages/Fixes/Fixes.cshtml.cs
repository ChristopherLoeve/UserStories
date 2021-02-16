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
        private FixesService fixesService;
        public List<Fix> Fixes { get; private set; }

        public FixesModel(FixesService fixesService, ProgrammerService programmerService)
        {
            ProgrammerService = programmerService;
            this.fixesService = fixesService;
        }

        public void OnGet()
        {
            Fixes = fixesService.GetFixes();
        }
    }
}
