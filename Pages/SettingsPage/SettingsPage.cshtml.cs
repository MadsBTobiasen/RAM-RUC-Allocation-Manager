using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.SettingsPage
{
    public class SettingsPageModel : PageModel
    {
      
        private SettingsService settingsService;


        public List<BaseSettings> BaseSettingsList { get; set; }

        [BindProperty]
        public BaseSettings BaseSettings { get; set; }

        public SettingsPageModel(SettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public void OnGet()
        {
            BaseSettings = settingsService.GetSettings(); 
            BaseSettingsList = settingsService.LoadSettings();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            settingsService.ApplySetting(BaseSettings);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");
        }
    }
}
