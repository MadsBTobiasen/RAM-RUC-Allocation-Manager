using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.LoginPage
{
    public class LoginPageModel : PageModel
    {

        #region Fields
        private UserService userService;
        #endregion

        #region Properties
        [BindProperty] public string EnteredUsername { get; set; }
        [BindProperty] public string EnteredPassword { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Constructor

        public LoginPageModel(UserService userService)
        {
            this.userService = userService;
        }
        #endregion

        #region Methods
        public async Task<IActionResult> OnPostAsync()
        {
            List<User> users = userService.Users;
            foreach (User user in users)
            {
                if (EnteredUsername == user.Username)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    if (passwordHasher.VerifyHashedPassword(null, user.Password, EnteredPassword) ==
                        PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, EnteredUsername)
                        };

                        if(EnteredUsername == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/EmployeeLandingPage/EmployeeLandingPage");
                    }

                }
            }

            ErrorMessage = "Invalid attempt";
            return Page();
        }

        public void OnGet() { }
        #endregion
    }
}
