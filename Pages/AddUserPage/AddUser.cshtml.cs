using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;
using static RAM___RUC_Allocation_Manager.Models.User;

namespace RAM___RUC_Allocation_Manager.Pages.AddUser
{
    public class AddUserModel : PageModel
    {

        #region Fields
        private UserService userService;
        #endregion

        #region Properties
        public Leader Leader { get; set; }
        public List<SelectListItem> TypeSelectList { get; set; }

        #region New User Properties
        [BindProperty] [Required] [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
        /// <summary>
        /// The Email for any new Employee is always the same for this prototype,
        /// in practice, this will be user submitted.
        /// </summary>
        [BindProperty] [Required]
        public string Email { get; set; } = "RAM-Leader-Test@Tier1TCG.dk";
        /// <summary>
        /// Title has a length of minimum, such that a "choose title.." option can be added, with a string as a value, with a length less than one,
        /// such that when a valid title is chosen, it passes the validation, as the string length of value is 1 or higher.
        /// </summary>
        [BindProperty] [Required] [StringLength(100, MinimumLength = 1)]
        public string Type { get; set; }

        [BindProperty] [Required] [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [BindProperty] [Required]
        public string Password { get; set; }
        [BindProperty] [Required] [Compare("Password", ErrorMessage = "Password er ikke ens. Prøv igen.")]
        public string ConfirmPassword { get; set; }
        #endregion

        #endregion

        public AddUserModel(UserService userService)
        {
            this.userService = userService;

            TypeSelectList = new List<SelectListItem>()
            {
                new SelectListItem() { Value = $"", Text = $"Vælg en title for ny leder.." },
                new SelectListItem() { Value = $"{(int)UserType.Leader}", Text = $"{UserType.Leader}" },
                new SelectListItem() { Value = $"{(int)UserType.Adminstrator}", Text = $"{UserType.Adminstrator}" },
            };

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        #region Methods
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Leader = new Leader()
            {
                Name = Name,
                Email = Email,
                Type = (UserType)Convert.ToInt32(Type),
                Username = Username,
            };

            Leader.SetPassword(Password);

            userService.CreateUser(Leader);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }
        #endregion
    }
}
