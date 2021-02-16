using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStories.Models;
using UserStories.Services;

namespace UserStories.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly ProgrammerService programmerService;
        public string Message { get; set; }

        public LogoutModel(ProgrammerService programmerService)
        {
            this.programmerService = programmerService;
        }

    }
}
