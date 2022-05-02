using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.LeaderLandingPage
{
    public class LeaderLandingPageModel : PageModel
    {
        #region Fields
        private UserService userService;
        #endregion

        #region Properties
        public Leader Leader { get; set; }
        #endregion

        public void OnGet()
        {
        }
    }
}
