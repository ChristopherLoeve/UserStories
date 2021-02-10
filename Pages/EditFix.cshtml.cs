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

        [BindProperty] public Fix fix { get; set; }
        public List<Fix> fixes { get; private set; }
        private FixesService fixesService;
        private readonly IHtmlHelper htmlHelper;

        public EditFixModel(FixesService fixesService, IHtmlHelper htmlHelper)
        {
            this.fixesService = fixesService;
            this.htmlHelper = htmlHelper;
        }
        public void OnGet(int id)
        {
            fix = fixesService.GetFix(id);
            fixesService.GetFixes();
        }

        public IActionResult OnPost(int id)
        {
            fixesService.UpdateFix(fix, id);
            return RedirectToPage("Fixes");
        }
    }
}
