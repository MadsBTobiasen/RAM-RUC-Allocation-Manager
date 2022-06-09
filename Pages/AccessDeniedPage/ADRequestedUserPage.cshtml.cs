using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RAM___RUC_Allocation_Manager.Pages.AccessDeniedPage
{
    public class ADRequestedUserPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
