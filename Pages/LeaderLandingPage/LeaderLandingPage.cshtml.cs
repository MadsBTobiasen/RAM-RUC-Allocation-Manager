using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.MockData;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
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
        #endregion

        #region Properties
        public Leader Leader => (Leader)userService.GetUserByID(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        [BindProperty] public User CreatedUser { get; set; }
        [BindProperty] public Employee Employee { get; set; }
        public bool IsLeader { get; set; }

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

        [BindProperty]
        public Models.User User { get; set; }

        [BindProperty]
        public Models.Employee Employee { get; set; }

        public bool IsLeader { get; set; }
        #endregion

        public LeaderLandingPageModel(UserService userService)
        {
            this.userService = userService;
        }
        
        public IActionResult OnGet()
        {
            IsLeader = false;
            
            Console.WriteLine(Leader.Id);
            return PageWithSortingSearchingAndPagination();

        }

        public IActionResult OnPost()
        {

            Console.WriteLine("PageSection: " + PageSection);

            return PageWithSortingSearchingAndPagination();

        }

        public IActionResult PageWithSortingSearchingAndPagination()
        {

            Searching();
            Sorting();
            Pagination();

            foreach(object o in RouteData.DataTokens)
            {
                Console.WriteLine("output: " + o);
            }

            return Page();

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

            switch(AllEmployeesSortingOption)
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
