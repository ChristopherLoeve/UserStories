using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Admin
{
    public class MemberlistModel : PageModel
    {
        public ProgrammerService ProgrammerService { get; private set; }
        public List<Programmer> Programmers { get; set; }
        private readonly IWebHostEnvironment _he;

        public MemberlistModel(ProgrammerService programmerService, IWebHostEnvironment he)
        {
            ProgrammerService = programmerService;
            _he = he;
        }

        public IActionResult OnGet()
        {
            Programmers = ProgrammerService.GetProgrammers();
            return Page();
        }

        public IActionResult OnGetDeletePicture(int id)
        {
            Programmers = ProgrammerService.GetProgrammers();
            if (ProgrammerService.FindProgrammerByEmail(HttpContext.User.Identity.Name).AccessLevel < 10)
                return Page();

            Programmer programmer = ProgrammerService.FindProgrammerById(id);
            try
            {
                System.IO.File.Delete(Path.Combine(_he.WebRootPath, "Images/ProfilePictures", programmer.ProfilePictureName));
            }
            catch (Exception e)
            {
                return Page();
            }

            ProgrammerService.AddProfilePicture(programmer.ProgrammerId, "");
            return Page();
        }
    }
}
