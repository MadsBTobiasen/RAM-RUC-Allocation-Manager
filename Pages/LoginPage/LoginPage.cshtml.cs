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
        private PasswordHasher<string> hasher;
        private UserService userService;
        #endregion

        #region Properties
        [BindProperty] public string EnteredUsername { get; set; }
        [BindProperty] public string EnteredPassword { get; set; }
        public string ErrorMessage { get; set; }
        private List<User> Users { get; set; }
        #endregion

        #region Constructor

        public LoginPageModel(UserService us)
        {
            hasher = new PasswordHasher<string>();
            userService = us;
            Users = userService.GetUsers();
        }
        #endregion

        #region Methods
        public async Task<IActionResult> OnPostLogin()
        {
            
            foreach (User user in Users)
            {

                if (EnteredUsername.ToLower() == user.Username.ToLower())
                {
             
                    if(hasher.VerifyHashedPassword(null, user.Password, EnteredPassword) == PasswordVerificationResult.Success) 
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user.GetClaimsPrinciple());
                        return Redirect("/Index");
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
