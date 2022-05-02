using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        #endregion

        #region Methods
        public void OnGet()
        {
        }

        public void OnPostLogin() { }
        #endregion
    }
}
