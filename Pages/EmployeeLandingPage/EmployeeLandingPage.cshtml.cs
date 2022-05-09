using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.EmployeeLandingPage
{
    public class EmployeeLandingPageModel : PageModel
    {

        #region Fields
        private UserService userService;
        private SettingsService settingsService;
        private LoginService loginService;
        #endregion

        #region Properties
        public Employee Employee { get; set; }
        public Leader Leader { get; set; }
        public BaseSettings BaseSettings { get; set; }
        public int LoggedInUserId { get
            {
                return Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            } 
        }
        #endregion

        #region Constructor
        public EmployeeLandingPageModel(UserService us, SettingsService ss, LoginService ls)
        {
            userService = us;
            settingsService = ss;
            loginService = ls;
            BaseSettings = settingsService.GetSettings();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns the pageview.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {

            loginService.HttpContext = HttpContext;

            if(!loginService.AssessUser(id, LoggedInUserId))
            {
                return Redirect("/Index");
            } else
            {
                if (id == -1) id = LoggedInUserId;
                Employee = (Employee)userService.GetUserByID(id);
                return Page();
            }

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

        #region Methods for Assessing Access 

        #endregion

        #endregion

        #endregion
    }
}
