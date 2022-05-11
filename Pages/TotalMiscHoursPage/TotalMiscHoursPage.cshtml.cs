using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.TotalMiscHoursPage
{
    public class TotalMiscHoursPageModel : PageModel
    {
        #region Fields
        private UserService userService;
        private SettingsService settingsService;
        #endregion

        #region Properties
        public Employee Employee { get; set; }
        public BaseSettings BaseSettings { get; set; }
        public int TotalHiringCommitteeMinutes { get; set; }
        public int TotalPhdCommitteeMinutes { get; set; }
        public int TotalPromotionCommitteeMinutes { get; set; }
        public int TotalCustomCommitteeMinutes { get; set; }
        public int TotalCommittees { get; set; }
        #endregion

        #region Constructor

        public TotalMiscHoursPageModel(UserService userService, SettingsService settingsService)
        {
            this.userService = userService;
            this.settingsService = settingsService;
            BaseSettings = settingsService.GetSettings();
        }

        #endregion

        #region Methods
        public IActionResult OnGet(int id)
        {

            TotalHiringCommitteeMinutes = Employee.EmployeeHiringCommittees.Select(ehc =>
                ehc.HiringCommittee.PeopleToBeAssessed * BaseSettings.HourPerPersonHiringCommittee).Sum();
            TotalPhdCommitteeMinutes = Employee.PhdCommittees.Count * BaseSettings.PhdCommitteeHourValue;
            TotalPromotionCommitteeMinutes = Employee.PromotionCommittees.Select(pc =>
                pc.PeopleToBeAssessed * BaseSettings.HourPerPersonPromotionCommittee).Sum();
            TotalCustomCommitteeMinutes = Employee.EmployeeCustomCommittees.Select(ecc => ecc.CustomCommittee.MinuteWorth).Sum();
            TotalCommittees = Employee.EmployeeHiringCommittees.Count + Employee.PromotionCommittees.Count() +
                              Employee.PhdCommittees.Count() + Employee.EmployeeCustomCommittees.Count();
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
