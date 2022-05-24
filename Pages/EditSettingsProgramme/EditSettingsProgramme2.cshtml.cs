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

namespace RAM___RUC_Allocation_Manager.Pages.EditSettingsProgramme
{
    [Authorize(Roles = "Adminstrator")]
    public class EditSettingsProgramme2Model : PageModel
    {
        private List<Leader> _leaders;
        private List<Employee> _employees;
        private ProgrammeService programmeService;
        private DbService<LeaderProgramme> lpService;
        private DbService<EmployeeProgramme> epService;

        //[BindProperty]
        //public Leader Leader { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        [BindProperty]
        public Employee Employee { get; set; }

        public List<Leader> Leaders { get; set; } = new List<Leader>();
        public List<Employee> Employees { get; set; } = new List<Employee>();

            [BindProperty]
        public Programme Programme { get; set; }
        public DbService<Programme> dbService { get; set; }
        public UserService userService { get; set; }

        public EditSettingsProgramme2Model(UserService userService, ProgrammeService programmeService, DbService<LeaderProgramme> lpService, DbService<EmployeeProgramme> epService)
        {
            this.programmeService = programmeService;
            this.lpService = lpService;
            this.epService = epService;
            this.userService = userService;
        }
        public void OnGet(int id)
        {
            //LeaderProgramme = MockData.MockLeaderProgrammes.CreateMockDataOneObj();
            //LeaderProgramme = await dbService.GetObjectByIdAsync(id);
            //Leaders = await dbService2.GetObjectsAsync();
            //Employees = await dbService3.GetObjectsAsync();
            Programme = programmeService.GeProgrammeWithNavPropById(id).Result;
            Leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();
            Employees = userService.GetUsersByType(Models.User.UserType.Employee).Cast<Employee>().ToList();
            ProgrammeName = Programme.Name;
        }

        public async Task<IActionResult> OnPostEdit(int programmeId)
        {
            Programme.Name = ProgrammeName;
            Programme.Id = programmeId;
            await programmeService.EditProgramme(Programme);

            return RedirectToPage("../SettingsPage/SettingsPage");

        }

        public async Task<IActionResult> OnPostAddUsers(int employeeId, int leaderId)
        {
            if(employeeId != -1)
                await epService.AddObjectAsync(new EmployeeProgramme { EmployeeId = employeeId, ProgrammeId = Programme.Id});
            if(leaderId != -1)
                await lpService.AddObjectAsync(new LeaderProgramme { LeaderId = leaderId, ProgrammeId = Programme.Id });

            return RedirectToPage("../SettingsPage/SettingsPage");


        }
    }
}
