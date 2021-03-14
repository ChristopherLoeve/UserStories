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
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace UserStories.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ProgrammerService programmerService;
        public Programmer Programmer { get; set; }
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
            if (!programmerService.ValidateLogin(Email, Password))
            {
                ModelState.AddModelError("Email", "The email or password is incorrect");
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

        public IActionResult OnGetLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
