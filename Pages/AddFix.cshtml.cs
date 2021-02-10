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
    public class AddFixModel : PageModel
    {
        private FixesService fixesService; 
        
        [BindProperty] public Fix fix { get; set; }

        public AddFixModel(FixesService fixesService)
        {
            this.fixesService = fixesService;
        }

        public void OnGet()
        {
            fix = new Fix();
        }

        public IActionResult OnPost()
        {
            fixesService.AddFix(fix);
            return RedirectToPage("Fixes");
        }
    }
}
