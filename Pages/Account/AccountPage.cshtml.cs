using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Account
{
    public class AccountPageModel : PageModel
    {
        public Programmer Programmer;
        public ProgrammerService ProgrammerService { get; private set; }
        [BindProperty]
        public IFormFile Uploadfiles { get; set; }
        private readonly IWebHostEnvironment _he;



        public AccountPageModel(ProgrammerService programmerService, IWebHostEnvironment he)
        {
            ProgrammerService = programmerService;

            _he = he;
        }

        public void OnGet()
        {
            Programmer = ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Programmer = ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name);

            var Filupload = Path.Combine(_he.WebRootPath, "Images\\ProfilePictures", Programmer.Email + "." + Uploadfiles.ContentType.Remove(0,6));
            using (var Fs = new FileStream(Filupload, FileMode.Create))
            {
                await Uploadfiles.CopyToAsync(Fs);
                ViewData["Message"] = "the Selected File" + Uploadfiles.FileName + "Is uploaded succesfully...";
            }
            ProgrammerService.AddProfilePicture(Programmer.ProgrammerId, Programmer.Email + "." + Uploadfiles.ContentType.Remove(0,6));

            return Page();
        }

        public IActionResult OnGetDeletePicture()
        {
            Programmer = ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name);

            try
            {
                System.IO.File.Delete(Path.Combine(_he.WebRootPath, "Images/ProfilePictures", Programmer.ProfilePictureName));
            }
            catch (Exception e)
            {
                return Page();
            }

            ProgrammerService.AddProfilePicture(Programmer.ProgrammerId, "");
            return Page();
        }
    }
}
