using System;
using System.Collections.Generic;
using System.Linq;
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
        #endregion

        #region Properties
        public Employee Employee { get; set; }
        public BaseSettings BaseSettings { get; set; }
        #endregion

        #region Constructor
        public EmployeeLandingPageModel(UserService us, SettingsService ss)
        {
            userService = us;
            settingsService = ss;
            BaseSettings = settingsService.GetSettings();
        }
        #endregion

        #region Methods
        public IActionResult OnGet(int id)
        {

            Employee = (Employee)userService.GetUserByID(id);
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
