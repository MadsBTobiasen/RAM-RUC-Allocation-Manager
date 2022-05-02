using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.EditEmployeePage
{
    public class EditEmployeePageModel : PageModel
    {

        #region Fields
        public UserService userService;
        #endregion

        #region Properties
        public Employee Employee { get; set; }
        #endregion

        #region Methods
        public void OnGet()
        {
        }
        #endregion
    }
}
