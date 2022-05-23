using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.MockData;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.Email;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.SettingsPage
{

    [Authorize(Roles = "Adminstrator")]

    public class SettingsPageModel : PageModel
    {
        private List<Leader> _leaders;
        
        [BindProperty]
        public Programme NewProgramme { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        public LeaderProgramme NewLeaderProgramme { get; set; }
        public EmployeeProgramme NewEmployeeProgramme { get; set; }
        [BindProperty]
        public Leader Leader { get; set; }
      
        public ICollection<Programme> Programmes { get; set; }

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
        public DbService<Programme> dbService2 { get; set; }
        public DbService<EmployeeProgramme> dbService3 { get; set; }
        public DbService<Leader> dbService4 { get; set; }
        public UserService userService { get; set; }

        public List<BaseSettings> BaseSettingsList { get; set; }

        [BindProperty]
        public BaseSettings BaseSettings { get; set; }


        public SettingsPageModel(SettingsService settingsService, UserService userService, DbService<LeaderProgramme> dbService, DbService<Programme> dbservice2, DbService<EmployeeProgramme> dbservice3, DbService<Leader> dbService4)
        {

            this.settingsService = settingsService;
            this.userService = userService;

            this.dbService = dbService;
            this.dbService2 = dbservice2;
            this.dbService3 = dbservice3;
            this.dbService4 = dbService4;

        }

        public async void OnGet()
        {

            //Leaders = userService.GetLeaders();
            BaseSettings = settingsService.GetSettings(); 
            BaseSettingsList = settingsService.LoadSettings();
            FalkesMockdata falkesMockdata = new FalkesMockdata();
            falkesMockdata.CreateMockData();
            Programmes = falkesMockdata.GetProgrammes();
            //Leaders = await dbService2.GetObjectsAsync();
            //Users = userService.GetUsers();
            //Leaders = userService.GetUsers();
            //Leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();

        }

        public IActionResult OnPostSettings()
        {
        
            settingsService.ApplySetting(BaseSettings);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }

       

        public IActionResult OnPostLeaderProgramme()
        {
            NewProgramme = new Programme();
            
            NewProgramme.Name = ProgrammeName;

            NewProgramme.LeaderProgrammes.Add(new LeaderProgramme(){Leader = Leader, Programme = NewProgramme});

            NewProgramme.Users = new List<User>();

            //dbService.AddObjectAsync(NewProgramme);

            Programmes.Add(NewProgramme);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }
    }
}
