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
        private FixesService fixesService;
        public List<Fix> Fixes { get; private set; }

        public FixesModel(FixesService fixesService)
        {
            this.fixesService = fixesService;
        }

        public void OnGet()
        {
            Fixes = fixesService.GetFixes();
        }
    }
}
