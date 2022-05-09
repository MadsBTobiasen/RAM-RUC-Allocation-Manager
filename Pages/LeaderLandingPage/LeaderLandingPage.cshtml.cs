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
        public Leader Leader => (Leader)userService.GetUserByID(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        [BindProperty] public User CreatedUser { get; set; }
        [BindProperty] public Employee Employee { get; set; }
        public bool IsLeader { get; set; }
      
        #region All Employees
        public List<User> Employees => userService.GetUsersByType(Models.User.UserType.Employee);
        public List<User> PaginatedEmployees { get; set; }
        [BindProperty(SupportsGet = true)] public int PageIndexAllEmployees { get; set; }
        public int PageMaxAllEmployees { get; set; }
        public int MaxItemsAllEmployees { get; set; }
        #endregion

        #region Programme Employees
        public List<User> ProgrammeEmployees => Leader.ProgrammeUsers;
        public List<User> PaginatedProgrammeEmployees { get; set; }
        [BindProperty(SupportsGet = true)] public int PageIndexProgrammeEmployees { get; set; }
        public int PageMaxProgrammeEmployees { get; set; }
        public int MaxItemsProgrammeEmployees { get; set; }
        #endregion

        #region All Leaders
        public List<User> Leaders => userService.GetUsersByType(Models.User.UserType.Leader);
        public List<User> PaginatedLeaders { get; set; }
        [BindProperty(SupportsGet = true)] public int PageIndexAllLeaders { get; set; }
        public int PageMaxAllLeaders { get; set; }
        public int MaxItemsAllLeaders { get; set; }
        #endregion

        #endregion

        #region Constructor
        public LeaderLandingPageModel(UserService us, PaginationService<User> ps)
        {

            CreatedUser = new Employee();

            userService = us;
            paginationService = ps;

            MaxItemsAllEmployees = 10;
            MaxItemsProgrammeEmployees = 10;
            MaxItemsAllLeaders = 10;

        }
        #endregion

        #region Methods

        /// <summary>
        /// Method that returns the Page.
        /// </summary>
        public IActionResult OnGet()
        {
        
            IsLeader = false;

            Pagination();

            return Page();
            
        }

        /// <summary>
        /// Method that gets a paginated result of users, by setting up the PaginatationService & calling Paginate on it.
        /// </summary>
        public IActionResult OnGetPaginatedResult()
        {

            Pagination();

            return Page();

        }


        public IActionResult OnPostCreateUser()
        {

            Pagination();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            userService.CreateUser(CreatedUser);
            return RedirectToPage("/AddUserPage/AllUsers");

        }

        public void OnPostCheckType()
        {

            Pagination();

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
            PageMaxProgrammeEmployees = paginationService.PageMax;
        }

        private void PaginationAllLeaders()
        {
            paginationService.Setup(Leaders, MaxItemsAllLeaders);
            PaginatedLeaders = paginationService.Paginate(PageIndexAllLeaders);

            PageIndexAllLeaders = paginationService.PageIndex;
            PageMaxAllLeaders = paginationService.PageMax;
        }

        /// <summary>
        /// Methods that must with each request.
        /// </summary>
        private void Pagination()
        {

            PaginationAllEmployees();
            PaginationProgrammeEmployees();
            PaginationAllLeaders();

        }
        #endregion

        #endregion
    }
}
