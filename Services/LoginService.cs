using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class LoginService
    {

        #region Fields
        private PasswordHasher<string> hasher;
        private UserService userService;
        #endregion

        #region Properties
        public HttpContext HttpContext { get; set; }
        private ClaimsPrincipal User { get { 
                try
                {
                    return HttpContext.User;
                } catch
                {
                    throw new Exception("HttpContext must be set.");
                }
            } 
        }
        #endregion

        #region Constructor
        public LoginService(UserService us)
        {
            userService = us;
            hasher = new PasswordHasher<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method ***
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Login(string enteredUsername, string enteredPassword)
        {

            foreach (User user in userService.Users)
            {

                if (enteredUsername.ToLower() == user.Username.ToLower())
                {

                    if (hasher.VerifyHashedPassword(null, user.Password, enteredPassword) == PasswordVerificationResult.Success)
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user.GetClaimsPrinciple());
                        return true;
                    }

                }
            }

            return false;

        }

        //Since only Employees, or Leaders of those employees may access a respective employees landing page. Several Assesments will be made below.
        /// <summary>
        /// Method that assess if the current user accesssing the page, has the authorization to do so.
        /// </summary>
        /// <param name="id">Id passed through the browser.</param>
        /// <returns>Bool if user has access, false if not.</returns>
        public bool AssessUser(int id, int loggedInUserId)
        {
            //If the passed id is -1. The id of the logged in user is used.
            //The value of -1, is typically when the user pressess the landing page button in the header, gets redirected, or enters an id in the browser.
            if (id == -1)
            {
                //Only allow the page to be shown, if the logged in user is an employee.
                if (User.HasClaim(ClaimTypes.Role, Models.User.UserType.Employee.ToString()))
                {
                    id = loggedInUserId;
                    return true;
                }

            }
            else
            //If a value that wasn't -1, was passed ,this indicates either a user trying to access a landing page through a link.
            //Only if the logged in user, and the id matches, or if the id passed, has the logged in user as a leader.
            {
                if (id == loggedInUserId && User.HasClaim(ClaimTypes.Role, Models.User.UserType.Employee.ToString()))
                {
                    //If there's a match with the id of the logged in user, and the id requested, and if the logged in user, is an employee, return true.
                    id = loggedInUserId;
                    return true;
                }
                else
                {
                    if (User.HasClaim(ClaimTypes.Role, Models.User.UserType.Leader.ToString()))
                    {

                        //Here we check if the Loggedin User has the Employee requested in one of it's programmes.
                        Leader leader = (Leader)userService.GetUserByID(loggedInUserId);
                        if (leader.HasEmployeeInProgrammeById((Employee)userService.GetUserByID(id)))
                        {
                            return true;
                        }

                    }
                }
            }

            return false;

        }
        #endregion

    }
}
