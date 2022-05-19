using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.EditLeaderPage
{
    public class EditLeaderPageModel : PageModel
    {
        #region Fields
        public UserService userService;
        #endregion

        #region Properties

        public List<User> Users { get; set; }

        [BindProperty]
        public User UserToEdit { get; set; }

        public bool IsLeader { get; set; }
        #endregion

        public EditLeaderPageModel(UserService userService)
        {
            this.userService = userService;
        }

        #region Methods
        public IActionResult OnGet(int id)
        { 
            Users = userService.GetUsers();
            UserToEdit = userService.GetUserByID(id);

            if (UserToEdit == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            userService.EditUser(UserToEdit);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");
        }
        #endregion
    }
}
