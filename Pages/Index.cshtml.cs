using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RAM___RUC_Allocation_Manager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly ILogger<IndexModel> _logger;
        private UserService userService;
        #endregion

        public IndexModel(ILogger<IndexModel> logger, UserService us)
        {
            _logger = logger;
            userService = us;
        }

        /// <summary>
        /// OnGet to Redirect once a user hits the index.
        /// If the User is already logged in, it gets redirected to it's respective landingpage.
        /// If the User is not already logged in, it gets redirected to the login-page.
        /// </summary>
        public IActionResult OnGet()
        {
        
            if(User.Identity.IsAuthenticated)
            {
                //Authenticated
                if (User.HasClaim(ClaimTypes.Role, Models.User.UserType.Employee.ToString())) return Redirect($"/EmployeeLandingPage/EmployeeLandingPage/{Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))}");
                if (User.HasClaim(ClaimTypes.Role, Models.User.UserType.Leader.ToString())) return Redirect("/LeaderLandingPage/LeaderLandingPage");
            }

            return Redirect("/LoginPage/LoginPage");

        }

    }
}
