using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAM___RUC_Allocation_Manager.MockData;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using RAM___RUC_Allocation_Manager.Services;
using static RAM___RUC_Allocation_Manager.Models.Employee;

namespace RAM___RUC_Allocation_Manager.Pages.EditEmployeePage
{
    public class EditEmployeePageModel : PageModel
    {

        #region Fields
        public UserService userService;
        private bool _debug = true;
        #endregion

        #region Properties
        public Employee EmployeeToEdit { get; set; }
        public Employee EmployeeEdited { get; set; }
        public List<SelectListItem> TitleSelectList { get; set; }

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
        public string Email { get; set; } = "RAM-Employee-Test@Tier1TCG.dk";
        /// <summary>
        /// Title has a length of minimum, such that a "choose title.." option can be added, with a string as a value, with a length less than one,
        /// such that when a valid title is chosen, it passes the validation, as the string length of value is 1 or higher.
        /// </summary>
        [BindProperty] [Required] [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [BindProperty] [Required] [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [BindProperty] [Display(Name = "Nyt Password")]
        public string Password { get; set; }
        [BindProperty] [Compare("Password", ErrorMessage = "Nyt password er ikke ens. Prøv igen.")]
        public string ConfirmPassword { get; set; }
        [BindProperty]
        public int AssistantProfessorSupervisions { get; set; }
        [BindProperty]
        public int SynopsisExaminations { get; set; }
        [BindProperty]
        public int PorfolioExaminations { get; set; }
        [BindProperty]
        public int PhdCommittees { get; set; }
        [BindProperty]
        public int Balance { get; set; }
        [BindProperty]
        public bool IsGroupLeader { get; set; }
        [BindProperty]
        public EmployeeSavings Savings { get; set; }
        #endregion

        #endregion

        #region Constructor
        public EditEmployeePageModel(UserService userService)
        {
            
            this.userService = userService;

            TitleSelectList = new List<SelectListItem>()
            {
                new SelectListItem() { Value = $"{(int)EmployeeTitle.Professor}", Text = $"{EmployeeTitle.Professor}" },
                new SelectListItem() { Value = $"{(int)EmployeeTitle.AssociateProfessor}", Text = $"{EmployeeTitle.AssociateProfessor}" },
                new SelectListItem() { Value = $"{(int)EmployeeTitle.AssistantProfessor}", Text = $"{EmployeeTitle.AssistantProfessor}" },
            };

        }
        #endregion

        #region Methods
        /// <summary>
        /// Meethod that returns the Page();
        /// </summary>
        public IActionResult OnGet(int id)
        {

            EmployeeToEdit = (Employee)userService.GetUserByID(id);
            Title = EmployeeToEdit.Title.ToString();

            if (EmployeeToEdit == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        /// <summary>
        /// Method that updates the user object.
        /// </summary>
        public IActionResult OnPost(int id)
        {

            EmployeeToEdit = (Employee)userService.GetUserByID(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            EmployeeEdited = new Employee()
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Title = (EmployeeTitle)Convert.ToInt32(Title),
                Username = Username,
                AssistantProfessorSupervisions = AssistantProfessorSupervisions,
                SynopsisExaminations = SynopsisExaminations,
                PortfolioExaminations = PorfolioExaminations,
                PhdCommittees = PhdCommittees,
                Balance = Balance,
                IsGroupLeader = IsGroupLeader,
                Savings = Savings
            };

            //If password is not an empty string, apply the new password.
            if (!string.IsNullOrEmpty(Password))
            {
                EmployeeEdited.SetPassword(Password);
            }
            else
            {
                EmployeeEdited.Password = EmployeeToEdit.Password;
            }

            //Debug showing edits & differences:
            if (_debug)
            {
                Console.WriteLine("to edit:     " + EmployeeToEdit);
                Console.WriteLine("edited:      " + EmployeeEdited);
            }

            EmployeeEdited = (Employee)userService.EditUser(EmployeeEdited).Result;

            if (EmployeeEdited.Id != EmployeeToEdit.Id)
            {
                throw new Exception("Error in updating user.");
            }

            //Debug showing edits & differences:
            if (_debug) Console.WriteLine("after edit:  " + EmployeeEdited);

            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }
        #endregion
    }
}
