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

        [BindProperty]
        public Leader Leader { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        [BindProperty]
        public Employee Employee { get; set; }

        public List<Leader> Leaders
        {
            get
            {
                if (_leaders == null) _leaders = userService.GetUsersByType(Models.User.UserType.Leader).Cast<Leader>().ToList();
                return _leaders;
            }
            set { _leaders = value; }
        }
        public List<Employee> Employees
        {
            get
            {
                if (_employees == null) _employees = userService.GetUsersByType(Models.User.UserType.Employee).Cast<Employee>().ToList();
                return _employees;
            }
            set { _employees = value; }
        }
        
        [BindProperty]
        public Programme Programme { get; set; }
        public DbService<Programme> dbService { get; set; }
        public UserService userService { get; set; }

        public EditSettingsProgramme2Model(UserService userservice, DbService<Programme> dbservice, ProgrammeService programmeService)
        {
            dbService = dbservice;
            userService = userservice;
            this.programmeService = programmeService;

        }
        public async void OnGet(int id)
        {
            //LeaderProgramme = MockData.MockLeaderProgrammes.CreateMockDataOneObj();
            //LeaderProgramme = await dbService.GetObjectByIdAsync(id);
            //Leaders = await dbService2.GetObjectsAsync();
            //Employees = await dbService3.GetObjectsAsync();
            Programme = programmeService.GeProgrammeWithNavPropById(id).Result;
        }

        public async void OnPostEdit()
        {
            Programme.Name = ProgrammeName;
            Programme.LeaderProgrammes.Add(new LeaderProgramme {Leader = Leader, Programme = Programme});
            //await dbService.UpdateObjectAsync(Programme);
        }

        public async void OnPostAddEmployee()
        {
            Programme.EmployeeProgrammes.Add(new EmployeeProgramme{Employee = Employee, Programme = Programme});
            await dbService.UpdateObjectAsync(Programme);
        }
    }
}
