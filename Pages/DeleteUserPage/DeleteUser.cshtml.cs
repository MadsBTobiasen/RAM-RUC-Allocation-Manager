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

    [Authorize(Roles = "Adminstrator")]

    public class DeleteUserModel : PageModel
    {
        #region Fields
        private UserService userService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public Employee Employee { get; set; }


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
        public async Task<IActionResult> OnPost(int userId)
        {
            User = userService.GetUserByID(userId);
            await userService.DeleteUser(User);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");
        }
    }
}
