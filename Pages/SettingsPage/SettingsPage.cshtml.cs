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
        private ProgrammeService programmeService;

        //[BindProperty]
        //public Programme NewProgramme { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        public LeaderProgramme NewLeaderProgramme { get; set; }
        public EmployeeProgramme NewEmployeeProgramme { get; set; }
        [BindProperty]
        public User Leader { get; set; }
      
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


        public SettingsPageModel(ProgrammeService programmeService, SettingsService settingsService, UserService userService, DbService<LeaderProgramme> dbService, DbService<Programme> dbservice2, DbService<EmployeeProgramme> dbservice3, DbService<Leader> dbService4)
        {

            this.settingsService = settingsService;
            this.userService = userService;

            this.dbService = dbService;
            this.dbService2 = dbservice2;
            this.dbService3 = dbservice3;
            this.dbService4 = dbService4;
            this.programmeService = programmeService;

        }

        public async void OnGet()
        {

            Leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();
            BaseSettings = settingsService.GetSettings(); 
            //BaseSettingsList = settingsService.LoadSettings();
            //FalkesMockdata falkesMockdata = new FalkesMockdata();
            //falkesMockdata.CreateMockData();
            //Programmes = falkesMockdata.GetProgrammes();
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

       

        public async Task<IActionResult> OnPostLeaderProgramme(int userId)
        {
            Programme NewProgramme = new Programme();

            Console.WriteLine(userId);
            
            NewProgramme.Name = ProgrammeName;

            await programmeService.CreateProgramme(NewProgramme);

            await dbService.AddObjectAsync(new LeaderProgramme
            { LeaderId = userService.GetUserByID(userId).Id, ProgrammeId = NewProgramme.Id });


            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");

        }
    }
}
