using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.LeaderLandingPage
{
    [Authorize(Roles = "Leader")]
    public class LeaderLandingPageModel : PageModel
    {

        #region Fields
        private UserService userService;
        private PaginationService<User> paginationService;
        #endregion

        #region Properties
        public Leader Leader { get; set; }
        [BindProperty] public User CreatedUser { get; set; }
        [BindProperty] public Employee Employee { get; set; }
        public bool IsLeader { get; set; }
        #endregion
      
        #region All Employees
        public List<User> Employees { get; set; }
        public List<User> PaginatedEmployees { get; set; }
        [BindProperty] public int PageIndexAllEmployees { get; set; }
        public int PageMaxAllEmployees { get; set; }
        public int MaxItemsAllEmployees { get; set; }
        #endregion

        #region Programme Employees
        public List<User> ProgrammeEmployees { get; set; }
        public List<User> PaginatedProgrammeEmployees { get; set; }
        [BindProperty] public int PageIndexProgrammeEmployees { get; set; }
        public int PageMaxProgrammeEmployees { get; set; }
        public int MaxItemsProgrammeEmployees { get; set; }
        #endregion

        #region Constructor
        public LeaderLandingPageModel(UserService us, PaginationService<User> ps)
        {

            CreatedUser = new Employee();

            userService = us;
            paginationService = ps;

            MaxItemsAllEmployees = 25;
            MaxItemsProgrammeEmployees = 25;

            Employees = userService.GetUsersByType(Models.User.UserType.Employee);

        }
        #endregion

        #region Methods

        /// <summary>
        /// Method that returns the Page.
        /// </summary>
        public IActionResult OnGet()
        {
        
            IsLeader = false;

            Setup();

            return Page();
            
        }

        /// <summary>
        /// Method that gets a paginated result of users, by setting up the PaginatationService & calling Paginate on it.
        /// </summary>
        public IActionResult OnPostPaginatedResult()
        {

            Setup();

            return Page();

        }

        public IActionResult OnPostCreateUser()
        {

            Setup();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            userService.CreateUser(CreatedUser);
            return RedirectToPage("/AddUserPage/AllUsers");

        }

        public void OnPostCheckType()
        {

            Setup();

            if (CreatedUser.Type == Models.User.UserType.Employee)
            {
                IsLeader = false;
            }

            else
            {
                IsLeader = true;
            }
        }

        #region Non-HTTP-RequestMethods
        /// <summary>
        /// Method that setups the pagination, and paginates the list of Employees.
        /// </summary>
        private void PaginationAllEmployees()
        {
            paginationService.Setup(Employees, MaxItemsAllEmployees);
            PaginatedEmployees = paginationService.Paginate(PageIndexAllEmployees);

            PageIndexAllEmployees = paginationService.PageIndex;
            PageMaxAllEmployees = paginationService.PageMax;
        }
        private void PaginationProgrammeEmployees()
        {
            paginationService.Setup(ProgrammeEmployees, MaxItemsProgrammeEmployees);
            PaginatedProgrammeEmployees = paginationService.Paginate(PageIndexProgrammeEmployees);

            PageIndexProgrammeEmployees = paginationService.PageIndex;
            MaxItemsProgrammeEmployees = paginationService.PageMax;
        }

        /// <summary>
        /// Methods that must with each request.
        /// </summary>
        private void Setup()
        {

            Leader = (Leader)userService.GetUserByID(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            ProgrammeEmployees = Leader.ProgrammeUsers;

            PaginationAllEmployees();
            PaginationProgrammeEmployees();

        }
        #endregion

        #endregion
    }
}
