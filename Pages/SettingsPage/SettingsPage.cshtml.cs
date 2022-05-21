using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.SettingsPage
{

    [Authorize(Roles = "Adminstrator")]

    public class SettingsPageModel : PageModel
    {
        private List<Leader> _leaders;
        
        public Programme NewProgramme { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        public LeaderProgramme NewLeaderProgramme { get; set; }
        public EmployeeProgramme NewEmployeeProgramme { get; set; }
        [BindProperty]
        public Leader Leader { get; set; }
      
        private SettingsService settingsService;

        public List<Leader> Leaders
        {
            get
            {
                if (_leaders == null) _leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();
                return _leaders;
            }
            set { _leaders = value; }
        }
        public List<User> Users { get; set; }

        public DbService<LeaderProgramme> dbService { get; set; }
        public DbService<Leader> dbService2 { get; set; }
        public UserService userService { get; set; }

        public List<BaseSettings> BaseSettingsList { get; set; }

        [BindProperty]
        public BaseSettings BaseSettings { get; set; }


        public SettingsPageModel(SettingsService settingsService, UserService userService, DbService<LeaderProgramme> dbService, DbService<Leader> dbService2)
        {
            this.settingsService = settingsService;
            this.dbService = dbService;
            this.dbService2 = dbService2;
            this.userService = userService;
        }

        public async void OnGet()
        {

            //Leaders = userService.GetLeaders();
            BaseSettings = settingsService.GetSettings(); 
            BaseSettingsList = settingsService.LoadSettings();
            //Leaders = await dbService2.GetObjectsAsync();
            //Users = userService.GetUsers();
           // Leaders = userService.GetUsers();
            //Leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();

        }

        public IActionResult OnPostSettings()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            settingsService.ApplySetting(BaseSettings);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }

        public IActionResult OnPostLeaderProgramme()
        {

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

            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");
            return Page();

        }
    }
}
