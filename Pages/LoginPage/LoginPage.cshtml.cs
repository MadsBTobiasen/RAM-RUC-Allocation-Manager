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
        private LoginService loginService;
        #endregion

        #region Properties
        [BindProperty] public string EnteredUsername { get; set; }
        [BindProperty] public string EnteredPassword { get; set; }
        public string ErrorMessage { get; set; }
        private List<User> Users { get; set; }
        #endregion

        #region Constructor

        public LoginPageModel(UserService us, LoginService ls)
        {
            userService = us;
            Users = userService.GetUsers();

            loginService = ls;

        }
        #endregion

        #region Methods
        public async Task<IActionResult> OnPostLogin()
        {

            loginService.HttpContext = HttpContext;

            if (await loginService.Login(EnteredUsername, EnteredPassword)) return Redirect("/Index");
            else
            {
                ErrorMessage = "Invalid attempt";
                return Page();
            }

        }

        public void OnGet() { }
        #endregion
    }
}
