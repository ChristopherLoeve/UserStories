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
        private FixesService fixesService;
        public List<Fix> fixes { get; private set; }

        public DeleteFixModel(FixesService fixesService)
        {
            this.fixesService = fixesService;
        }

        public IActionResult OnGet(int id)
        {
            fixesService.GetFix(id);
            fixesService.DeleteFix(fixesService.GetFix(id));
            return RedirectToPage("Fixes");
        }

        public IActionResult OnPost(int id)
        {
            fixesService.DeleteFix(fixesService.GetFix(id));
            return RedirectToPage("Fixes");
        }
    }
}
