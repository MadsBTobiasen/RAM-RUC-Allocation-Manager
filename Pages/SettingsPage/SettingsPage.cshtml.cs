using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RAM___RUC_Allocation_Manager.Pages.SettingsPage
{

    [Authorize(Roles = "Leader")]

    public class SettingsPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
