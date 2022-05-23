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

        #region Enumerations
        public enum PageSections
        {
            None,
            ProgrammeEmployees,
            AllEmployees,
            AllLeaders
        }
        #endregion

        #region Fields
        private UserService userService;

        private PaginationService<Employee> employeePaginationService;
        private PaginationService<Leader> leaderPaginationService;

        private List<Employee> _employees;
        private List<Employee> _programmeEmployees;
        private List<Leader> _leaders;
        #endregion

        #region Properties
        public Leader Leader => (Leader)userService.GetUserByID(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        [BindProperty] public User CreatedUser { get; set; }
        [BindProperty] public Employee Employee { get; set; }

        /// <summary>
        /// This property is used, to indicate which section of the page, the request should lead to.
        /// </summary>
        [BindProperty] public PageSections PageSection { get; set; } = PageSections.None;

        #region Search Options
        [BindProperty] public string AllEmployeesSearchString { get; set; }
        [BindProperty] public string ProgrammeEmployeesSearchString { get; set; }
        [BindProperty] public string AllLeadersSearchString { get; set; }
        #endregion

        #region Sorting Options
        [BindProperty] public Employee.SortingOptions AllEmployeesSortingOption { get; set; } = Employee.SortingOptions.NameASC;
        [BindProperty] public Employee.SortingOptions ProgrammeEmployeesSortingOption { get; set; } = Employee.SortingOptions.NameASC;
        [BindProperty] public Leader.SortingOptions AllLeadersSortingOption { get; set; } = Leader.SortingOptions.NameASC;
        #endregion

        #region Pagination Options

        #region All Employees
        public List<Employee> Employees
        {
            get
            {
                if (_employees == null) _employees = userService.GetUsersByType(Models.User.UserType.Employee).Cast<Employee>().ToList();
                return _employees;
            }
            set { _employees = value; }
        }
        public List<Employee> PaginatedEmployees { get; set; }
        [BindProperty] public int PageIndexAllEmployees { get; set; }
        public int PageMaxAllEmployees { get; set; }
        public int MaxItemsAllEmployees { get; set; }
        #endregion

        #region Programme Employees
        public List<Employee> ProgrammeEmployees
        {
            get
            {
                if (_programmeEmployees == null) _programmeEmployees = Leader.ProgrammeUsers;
                return _programmeEmployees;
            }
            set { _programmeEmployees = value; }
        }
        public List<Employee> PaginatedProgrammeEmployees { get; set; }
        [BindProperty] public int PageIndexProgrammeEmployees { get; set; }
        public int PageMaxProgrammeEmployees { get; set; }
        public int MaxItemsProgrammeEmployees { get; set; }
        #endregion

        #region All Leaders
        public List<Leader> Leaders
        {
            get
            {
                if (_leaders == null) _leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();
                return _leaders;
            }
            set { _leaders = value; }
        }
        public List<Leader> PaginatedLeaders { get; set; }
        [BindProperty] public int PageIndexAllLeaders { get; set; }
        public int PageMaxAllLeaders { get; set; }
        public int MaxItemsAllLeaders { get; set; }
        #endregion

        #endregion

        #endregion

        #region Constructor
        public LeaderLandingPageModel(UserService us, PaginationService<Employee> empps, PaginationService<Leader> leadsps)
        {

            CreatedUser = new Employee();

            userService = us;
            employeePaginationService = empps;
            leaderPaginationService = leadsps;

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
            return Page();
        }

        /// <summary>
        /// Method that paginates the respective list of users.
        /// </summary>
        public IActionResult OnPostPaginatedResult()
        {

            Console.WriteLine("PageSection: " + PageSection);

            return Page();

        }

        /// <summary>
        /// Method that ensures that the Pagination, Sorting and Searching happens before the Page is returned.
        /// </summary>
        /// <returns></returns>
        public override PageResult Page()
        {

            Searching();
            Sorting();
            Pagination();

            return base.Page();

        }

        #region Searching Methods
        /// <summary>
        /// Method that searches, and returns only matching names of professors and leaders in their respective lists.
        /// </summary>
        private void Searching()
        {

            if (string.IsNullOrEmpty(AllEmployeesSearchString)) AllEmployeesSearchString = "";
            if (string.IsNullOrEmpty(ProgrammeEmployeesSearchString)) ProgrammeEmployeesSearchString = "";
            if (string.IsNullOrEmpty(AllLeadersSearchString)) AllLeadersSearchString = "";

            Employees = (from emp in Employees where emp.Name.ToLower().Contains(AllEmployeesSearchString.ToLower()) select emp).ToList();
            ProgrammeEmployees = (from emp in ProgrammeEmployees where emp.Name.ToLower().Contains(ProgrammeEmployeesSearchString.ToLower()) select emp).ToList();
            Leaders = (from lead in Leaders where lead.Name.ToLower().Contains(AllLeadersSearchString.ToLower()) select lead).ToList();

        }
        #endregion

        #region Sorting Methods
        /// <summary>
        /// Method that applies the sorting according to what the properties indicate.
        /// </summary>
        private void Sorting()
        {

            switch (AllEmployeesSortingOption)
            {

                case Employee.SortingOptions.NameASC: Employees = Employees.OrderBy(e => e.Name).ToList(); break;
                case Employee.SortingOptions.NameDESC: Employees = Employees.OrderByDescending(e => e.Name).ToList(); break;

                case Employee.SortingOptions.TitleASC: Employees = Employees.OrderBy(e => e.Title).ToList(); break;
                case Employee.SortingOptions.TitleDESC: Employees = Employees.OrderByDescending(e => e.Title).ToList(); break;

            }

            switch (ProgrammeEmployeesSortingOption)
            {

                case Employee.SortingOptions.NameASC: ProgrammeEmployees = ProgrammeEmployees.OrderBy(e => e.Name).ToList(); break;
                case Employee.SortingOptions.NameDESC: ProgrammeEmployees = ProgrammeEmployees.OrderByDescending(e => e.Name).ToList(); break;

                case Employee.SortingOptions.TitleASC: ProgrammeEmployees = ProgrammeEmployees.OrderBy(e => e.Title).ToList(); break;
                case Employee.SortingOptions.TitleDESC: ProgrammeEmployees = ProgrammeEmployees.OrderByDescending(e => e.Title).ToList(); break;

            }

            switch (AllLeadersSortingOption)
            {

                case Leader.SortingOptions.NameASC: Leaders = Leaders.OrderBy(l => l.Name).ToList(); break;
                case Leader.SortingOptions.NameDESC: Leaders = Leaders.OrderByDescending(l => l.Name).ToList(); break;

            }

        }
        #endregion

        #region Pagination Methods
        /// <summary>
        /// Method that setups the pagination, and paginates the lists.
        /// </summary>
        private void PaginationAllEmployees()
        {
            employeePaginationService.Setup(Employees, MaxItemsAllEmployees);
            PaginatedEmployees = employeePaginationService.Paginate(PageIndexAllEmployees);

            PageIndexAllEmployees = employeePaginationService.PageIndex;
            PageMaxAllEmployees = employeePaginationService.PageMax;
        }

        private void PaginationProgrammeEmployees()
        {
            employeePaginationService.Setup(ProgrammeEmployees, MaxItemsProgrammeEmployees);
            PaginatedProgrammeEmployees = employeePaginationService.Paginate(PageIndexProgrammeEmployees);

            PageIndexProgrammeEmployees = employeePaginationService.PageIndex;
            PageMaxProgrammeEmployees = employeePaginationService.PageMax;
        }

        private void PaginationAllLeaders()
        {
            leaderPaginationService.Setup(Leaders, MaxItemsAllLeaders);
            PaginatedLeaders = leaderPaginationService.Paginate(PageIndexAllLeaders);

            PageIndexAllLeaders = leaderPaginationService.PageIndex;
            PageMaxAllLeaders = leaderPaginationService.PageMax;
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
