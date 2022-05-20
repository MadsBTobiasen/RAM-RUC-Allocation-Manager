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

    [Authorize(Roles = "Adminstrator")]

    public class SettingsPageModel : PageModel
    {
        
        public Programme NewProgramme { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        public LeaderProgramme NewLeaderProgramme { get; set; }
        public EmployeeProgramme NewEmployeeProgramme { get; set; }
        [BindProperty]
        public Leader Leader { get; set; }
      
        private SettingsService settingsService;

        public IEnumerable<Leader> Leaders { get; set; }

        public DbService<LeaderProgramme> dbService { get; set; }
        public DbService<Leader> dbService2 { get; set; }
        public UserService userService { get; set; }

        public List<BaseSettings> BaseSettingsList { get; set; }

        [BindProperty]
        public BaseSettings BaseSettings { get; set; }

        public SettingsPageModel(SettingsService settingsService)
        public SettingsPageModel(DbService<LeaderProgramme> dbservice, DbService<Leader> dbservice2, UserService userservice)
        {
            this.settingsService = settingsService;
            dbService = dbservice;
            dbService2 = dbservice2;
            userService = userservice;
        }

        public void OnGet()
        public IActionResult OnPost()
        {
            BaseSettings = settingsService.GetSettings(); 
            BaseSettingsList = settingsService.LoadSettings();

        }
            NewProgramme = new Programme();
            NewLeaderProgramme = new LeaderProgramme();
            NewEmployeeProgramme = new EmployeeProgramme();

            NewProgramme.Name = ProgrammeName;
            NewProgramme.EmployeeProgrammes.Add(NewEmployeeProgramme);
            NewProgramme.LeaderProgrammes.Add(NewLeaderProgramme);
            NewProgramme.Users = new List<User>();

            NewEmployeeProgramme.Programme = NewProgramme;
            NewEmployeeProgramme.Employee = new Employee();

            NewLeaderProgramme.Leader = Leader;
            NewLeaderProgramme.Programme = NewProgramme;
            
            dbService.AddObjectAsync(NewLeaderProgramme);


            return Page();
        }
        public async void OnGet()
        {
            Leaders = await dbService2.GetObjectsAsync();
            //Leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();
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
