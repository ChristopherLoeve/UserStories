using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using UserStories.Models;
using UserStories.Services;
using Microsoft.AspNetCore.Authorization;

namespace UserStories.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ProgrammerService programmerService;
        public new Programmer Programmer { get; set; }
        [Required, EmailAddress, BindProperty]
        public string Email { get; set; }
        [Required, BindProperty]
        public string Password { get; set; }
        [TempData]
        public string Message { get; set; }

        public LoginModel(ProgrammerService programmerService)
        {
            this.programmerService = programmerService;
        }

        public IActionResult OnPost()
        {
            bool doesProgrammerExist = programmerService.ValidateLogin(Email, Password);
            if (!doesProgrammerExist)
            {
                return Page();
            }
            TempData["LoginSuccess"] = "Login Successful!";

                var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

                var user = new ClaimsPrincipal
                (
                    new ClaimsIdentity
                    (
                            new [] { new Claim(ClaimTypes.Name, Email), },
                            scheme
                    )
                );
                return SignIn(user, scheme);
            
        }
    }
}
