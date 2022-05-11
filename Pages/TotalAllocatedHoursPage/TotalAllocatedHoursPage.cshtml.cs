using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.TotalAllocatedHoursPage
{
    public class TotalAllocatedHoursPageModel : PageModel
    {

        #region Fields
        private UserService userService;
        private SettingsService settingsService;
        private LoginService loginService;
        #endregion

        #region Properties
        public Employee Employee { get; set; }
        public BaseSettings BaseSettings { get; set; }
        public int EmployeeBaseMinutes { get; set; }
        public int LoggedInUserId
        {
            get
            {
                return Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }
        #endregion

        #region Constructor

        public TotalAllocatedHoursPageModel(UserService userService, SettingsService settingsService, LoginService loginService)
        {
            this.userService = userService;
            this.settingsService = settingsService;
            this.loginService = loginService;
            BaseSettings = settingsService.GetSettings();
        }

        #endregion

        #region Methods
        public IActionResult OnGet(int id)
        {
            loginService.HttpContext = HttpContext;
            if (!loginService.AssessUser(id, LoggedInUserId))
            {
                return Redirect("/Index");
            }

            if (id == -1) id = LoggedInUserId;
                Employee = (Employee)userService.GetUserByID(id);
            switch (Employee.Title)
            {
                case Employee.EmployeeTitle.AssistantProfessor:
                    EmployeeBaseMinutes = BaseSettings.BaseHoursForAssistantProfessor;
                    break;
                case Employee.EmployeeTitle.AssociateProfessor:
                    EmployeeBaseMinutes = BaseSettings.BaseHoursForAssociateProfessor;
                    break;
                case Employee.EmployeeTitle.Professor:
                    EmployeeBaseMinutes = BaseSettings.BaseHoursForProfessor;
                    break;
            }
            return Page();

        }
        #region Non-HTTP Requests
        /// <summary>
        /// Method that takes an integer of minutes, and converts it to a string, to be shown on the front end.
        /// </summary>
        /// <param name="minutes">Amount of minutes as an integer.</param>
        /// <returns>String representing hours & minutes.</returns>
        public string ConvertMinutesToHours(int minutes)
        {
            TimeSpan time = TimeSpan.FromMinutes(minutes);
            return string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
        }
        #endregion

        #endregion
    }
}
