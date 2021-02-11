using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages
{
    public class EditFixModel : PageModel
    {

        [BindProperty] public Fix Fix { get; set; }
        private FixesService fixesService;

        public EditFixModel(FixesService fixesService)
        {
            this.fixesService = fixesService;
        }
        public void OnGet(int id)
        {
            Fix = fixesService.GetFix(id);
            fixesService.GetFixes();
        }

        public IActionResult OnPost(int id)
        {
            fixesService.UpdateFix(Fix, id);
            return RedirectToPage("Fixes");
        }
    }
}
