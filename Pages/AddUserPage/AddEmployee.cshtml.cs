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
using static RAM___RUC_Allocation_Manager.Models.Employee;

namespace RAM___RUC_Allocation_Manager.Pages.AddUser
{
    public class AddEmployeeModel : PageModel
    {

        #region Fields
        private UserService userService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }
        public Employee Employee { get; set; }
        public List<SelectListItem> TitleSelectList { get; set; }

        #region New Employee Properties
        [BindProperty] [Required] [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
        /// <summary>
        /// The Email for any new Employee is always the same for this prototype,
        /// in practice, this will be user submitted.
        /// </summary>
        [BindProperty] [Required]
        public string Email { get; set; } = "RAM-Employee-Test@Tier1TCG.dk";
        /// <summary>
        /// Title has a length of minimum, such that a "choose title.." option can be added, with a string as a value, with a length less than one,
        /// such that when a valid title is chosen, it passes the validation, as the string length of value is 1 or higher.
        /// </summary>
        [BindProperty] [Required] [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [BindProperty] [Required] [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [BindProperty] [Required]
        public string Password { get; set; }
        [BindProperty] [Required] [Compare("Password", ErrorMessage = "Passwords er ikke ens. Prøv igen.")]
        public string ConfirmPassword { get; set; }
        #endregion

        #endregion

        #region Constructor
        public AddEmployeeModel(UserService userService)
        {
            
            this.userService = userService;

            TitleSelectList = new List<SelectListItem>()
            {
                new SelectListItem() { Value = $"", Text = $"Vælg en title for ny ansat.." },
                new SelectListItem() { Value = $"{(int)EmployeeTitle.Professor}", Text = $"{EmployeeTitle.Professor}" },
                new SelectListItem() { Value = $"{(int)EmployeeTitle.AssociateProfessor}", Text = $"{EmployeeTitle.AssociateProfessor}" },
                new SelectListItem() { Value = $"{(int)EmployeeTitle.AssistantProfessor}", Text = $"{EmployeeTitle.AssistantProfessor}" },
            };

        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns the Page().
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            Users = userService.GetUsers();
            return Page();
        }

        /// <summary>
        /// Method that validates the page, and if successfull, the added user gets added.
        /// </summary>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Employee = new Employee()
            {
                Name = Name,
                Email = Email,
                Title = (EmployeeTitle)Convert.ToInt32(Title),
                Username = Username,
                Password = Password
            };

            userService.CreateUser(Employee);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }
        #endregion
    }
}

