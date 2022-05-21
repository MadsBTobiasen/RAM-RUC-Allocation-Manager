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
        [BindProperty]
        public Leader Leader { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        [BindProperty]
        public Employee Employee { get; set; }

        public IEnumerable<Leader> Leaders { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public LeaderProgramme LeaderProgramme { get; set; }
        public DbService<LeaderProgramme> dbService { get; set; }
        public DbService<Leader> dbService2 { get; set; }
        public DbService<Employee> dbService3 { get; set; }
        public UserService userService { get; set; }

        public EditSettingsProgramme2Model(UserService userservice, DbService<LeaderProgramme> dbservice, DbService<Leader> dbservice2, DbService<Employee> dbservice3)
        {
            dbService = dbservice;
            dbService2 = dbservice2;
            dbService3 = dbservice3;
            userService = userservice;

        }
        public async void OnGet(int id)
        {
            //LeaderProgramme = MockData.MockLeaderProgrammes.CreateMockDataOneObj();
            LeaderProgramme = await dbService.GetObjectByIdAsync(id);
            Leaders = await dbService2.GetObjectsAsync();
            Employees = await dbService3.GetObjectsAsync();
            //Employees = MockData.MockLeaderProgrammes
            //Leaders = MockData.MockLeaderProgrammes.GetMockLeaders();
        }

        public void OnPost()
        {
            LeaderProgramme.Leader = Leader;
            LeaderProgramme.Programme.Name = ProgrammeName;
            dbService.UpdateObjectAsync(LeaderProgramme);
        }

        public void OnPostAddEmployee()
        {
            LeaderProgramme.Programme.Users.Add(Employee);
            dbService.UpdateObjectAsync(LeaderProgramme);
        }
    }
}
