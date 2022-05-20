using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.EditUser
{
    public class DeleteUserModel : PageModel
    {
        #region Fields
        private UserService userService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }

        [BindProperty]
        public Models.User User { get; set; }

        #endregion

        public DeleteUserModel(UserService userService)
        {
            this.userService = userService;
        }

        public void OnGet(int id)
        {
            Users = userService.GetUsers();
            User = userService.GetUserByID(id);

        }
        public IActionResult OnPostDeleteUser()
        {
         
            userService.DeleteUser(User);

            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");
        }
    }
}
