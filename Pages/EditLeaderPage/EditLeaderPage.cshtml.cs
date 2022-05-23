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

namespace RAM___RUC_Allocation_Manager.Pages.EditLeaderPage
{
    public class EditLeaderPageModel : PageModel
    {
        #region Fields
        public UserService userService;
        private bool _debug = true;
        #endregion

        #region Properties
        public User UserToEdit { get; set; }
        public Leader UserEdited { get; set; }
        public List<SelectListItem> TypeSelectList { get; set; }

        #region Update User Properties
        [BindProperty] [Required]
        public int Id { get; set; }
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

        [BindProperty] [Display(Name = "Nyt Password")]
        public string Password { get; set; }
        [BindProperty] [Compare("Password", ErrorMessage = "Nyt password er ikke ens. Prøv igen.")]
        public string ConfirmPassword { get; set; }
        #endregion

        #endregion

        #region Constructor
        public EditLeaderPageModel(UserService userService)
        {

            this.userService = userService;

            //Role Change for Leaders disabled in the Prototype.
            TypeSelectList = new List<SelectListItem>()
            {
                new SelectListItem() { Value = $"{(int)UserType.Leader}", Text = $"{UserType.Leader}" },
                //new SelectListItem() { Value = $"{(int)UserType.Adminstrator}", Text = $"{UserType.Adminstrator}" },
            };

        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns the Page().
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        { 

            UserToEdit = userService.GetUserByID(id);
            Type = UserToEdit.Type.ToString();

            if (UserToEdit == null)
                return RedirectToPage("/NotFound");

            return Page();

        }

        /// <summary>
        /// Method that updates the user object.
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnPost(int id)
        {

            UserToEdit = userService.GetUserByID(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserEdited = new Leader()
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Type = (UserType)Convert.ToInt32(Type),
                Username = Username
            };

            //If password is not an empty string, apply the new password.
            if (!string.IsNullOrEmpty(Password))
            {
                UserEdited.SetPassword(Password);
            } else
            {
                UserEdited.Password = UserToEdit.Password;
            }

            //Debug showing edits & differences:
            if (_debug)
            {
                Console.WriteLine("to edit:     " + UserToEdit);
                Console.WriteLine("edited:      " + UserEdited);
            }

            UserEdited = (Leader)userService.EditUser(UserEdited).Result;

            if (UserEdited.Id != UserToEdit.Id)
            {
                throw new Exception("Error in updating user.");
            }

            //Debug showing edits & differences:
            if (_debug) Console.WriteLine("after edit:  " + UserEdited);

            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }
        #endregion
    }
}
