using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.AddUser
{
    public class AddUserModel : PageModel
    {
        #region Fields
        private UserService userService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }

        [BindProperty]
        public Models.User User { get; set; }
        #endregion

        public AddUserModel(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult OnGet()
        {
            Users = userService.GetUsers();
            return Page();
        }
        #region Methods
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            userService.CreateUser(User);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");
        }
        #endregion
    }
}
