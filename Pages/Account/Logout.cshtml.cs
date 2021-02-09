using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly ProgrammerRepository programmerRepository;
        public string Message { get; set; }

        public LogoutModel(ProgrammerRepository programmerRepository)
        {
            this.programmerRepository = programmerRepository;
        }
        public void OnGet()
        {
            Programmer programmer = programmerRepository.GetLoggedInProgrammer();
            Message = $"{programmer.Email} has logged out!";
            programmer.LoggedIn = false;
            programmerRepository.Commit();
        }
    }
}
