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
        public EmployeeLandingPageModel(UserService us, SettingsService ss)
        {
            userService = us;
            settingsService = ss;
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

            if(!AssessUser(id)) return Redirect("/Index");
            else return Page();

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
        //Since only Employees, or Leaders of those employees may access a respective employees landing page. Several Assesments will be made below.
        /// <summary>
        /// Method that assess if the current user accesssing the page, has the authorization to do so.
        /// </summary>
        /// <param name="id">Id passed through the browser.</param>
        /// <returns>Bool if user has access, false if not.</returns>
        private bool AssessUser(int id)
        {
            //If the passed id is -1. The id of the logged in user is used.
            //The value of -1, is typically when the user pressess the landing page button in the header, gets redirected, or enters an id in the browser.
            if (id == -1)
            {
                //Only allow the page to be shown, if the logged in user is an employee.
                if (User.HasClaim(ClaimTypes.Role, Models.User.UserType.Employee.ToString()))
                {
                    id = LoggedInUserId;
                    Employee = (Employee)userService.GetUserByID(id);
                    return true;
                }

            }
            else
            //If a value that wasn't -1, was passed ,this indicates either a user trying to access a landing page through a link.
            //Only if the logged in user, and the id matches, or if the id passed, has the logged in user as a leader.
            {
                if (id == LoggedInUserId && User.HasClaim(ClaimTypes.Role, Models.User.UserType.Employee.ToString()))
                {
                    //If there's a match with the id of the logged in user, and the id requested, and if the logged in user, is an employee, return true.
                    id = LoggedInUserId;
                    Employee = (Employee)userService.GetUserByID(id);
                    return true;
                }
                else
                {
                    if (User.HasClaim(ClaimTypes.Role, Models.User.UserType.Leader.ToString()))
                    {

                        //Here we check if the Loggedin User has the Employee requested in one of it's programmes.
                        Leader = (Leader)userService.GetUserByID(LoggedInUserId);
                        if (Leader.HasEmployeeInProgrammeById(id))
                        {
                            Employee = (Employee)userService.GetUserByID(id);
                            return true;
                        }

                    }
                }
            }

            return false;

        }
        #endregion

        #endregion

        #endregion
    }
}
